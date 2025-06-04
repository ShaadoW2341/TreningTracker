using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TreningTracker.Data;
using TreningTracker.Models;

namespace TreningTracker
{
    public partial class HistoryForm : Form
    {
        private AppDbContext _context;
        private System.ComponentModel.IContainer components = null;
        private CheckBox checkBoxDateFilter;
        private DateTimePicker dateTimePickerFilter;
        private Label labelTypeFilter;
        private ComboBox comboTypeFilter;
        private DataGridView dataGridView;
        // Lista wszystkich treningów (do filtrowania w pamięci)
        private List<TrainingSession> _allSessions;

        public HistoryForm()
        {
            _context = new AppDbContext();
            InitializeComponent();
            // Załaduj dane treningów i typów aktywności
            _allSessions = _context.TrainingSessions.Include(ts => ts.ActivityType).ToList();
            var types = _context.ActivityTypes.ToList();
            // Dodaj opcję "Wszystkie" na początek listy typów
            types.Insert(0, new ActivityType { Id = 0, Name = "Wszystkie" });
            this.comboTypeFilter.DataSource = types;
            this.comboTypeFilter.DisplayMember = "Name";
            this.comboTypeFilter.ValueMember = "Id";
            this.comboTypeFilter.SelectedIndex = 0;
            // Ustawienie domyślne - brak filtrowania daty
            this.checkBoxDateFilter.Checked = false;
            this.dateTimePickerFilter.Enabled = false;
            // Wyświetl wszystkie dane początkowo
            ApplyFilters();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null) _context.Dispose();
                if (components != null) components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.checkBoxDateFilter = new CheckBox();
            this.dateTimePickerFilter = new DateTimePicker();
            this.labelTypeFilter = new Label();
            this.comboTypeFilter = new ComboBox();
            this.dataGridView = new DataGridView();
            this.SuspendLayout();
            // 
            // checkBoxDateFilter
            // 
            this.checkBoxDateFilter.AutoSize = true;
            this.checkBoxDateFilter.Location = new System.Drawing.Point(10, 20);
            this.checkBoxDateFilter.Name = "checkBoxDateFilter";
            this.checkBoxDateFilter.Size = new System.Drawing.Size(108, 19);
            this.checkBoxDateFilter.TabIndex = 0;
            this.checkBoxDateFilter.Text = "Filtruj po dacie";
            this.checkBoxDateFilter.UseVisualStyleBackColor = true;
            this.checkBoxDateFilter.CheckedChanged += new System.EventHandler(this.checkBoxDateFilter_CheckedChanged);
            // 
            // dateTimePickerFilter
            // 
            this.dateTimePickerFilter.Format = DateTimePickerFormat.Short;
            this.dateTimePickerFilter.Location = new System.Drawing.Point(180, 18);
            this.dateTimePickerFilter.Name = "dateTimePickerFilter";
            this.dateTimePickerFilter.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerFilter.TabIndex = 1;
            this.dateTimePickerFilter.ValueChanged += new System.EventHandler(this.filterControlChanged);
            // 
            // labelTypeFilter
            // 
            this.labelTypeFilter.AutoSize = true;
            this.labelTypeFilter.Location = new System.Drawing.Point(400, 22);
            this.labelTypeFilter.Name = "labelTypeFilter";
            this.labelTypeFilter.Size = new System.Drawing.Size(94, 15);
            this.labelTypeFilter.TabIndex = 2;
            this.labelTypeFilter.Text = "Typ aktywności:";
            // 
            // comboTypeFilter
            // 
            this.comboTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboTypeFilter.Location = new System.Drawing.Point(500, 18);
            this.comboTypeFilter.Name = "comboTypeFilter";
            this.comboTypeFilter.Size = new System.Drawing.Size(150, 23);
            this.comboTypeFilter.TabIndex = 3;
            this.comboTypeFilter.SelectedIndexChanged += new System.EventHandler(this.filterControlChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Location = new System.Drawing.Point(10, 60);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(760, 380);
            this.dataGridView.TabIndex = 4;
            // 
            // HistoryForm
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxDateFilter);
            this.Controls.Add(this.dateTimePickerFilter);
            this.Controls.Add(this.labelTypeFilter);
            this.Controls.Add(this.comboTypeFilter);
            this.Controls.Add(this.dataGridView);
            this.Name = "HistoryForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Historia aktywności";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Zastosuj filtry i wyświetl wyniki w tabeli
        private void ApplyFilters()
        {
            IEnumerable<TrainingSession> query = _allSessions;
            if (checkBoxDateFilter.Checked)
            {
                DateTime selectedDate = dateTimePickerFilter.Value.Date;
                query = query.Where(ts => ts.Date.Date == selectedDate);
            }
            int selectedTypeId = comboTypeFilter.SelectedValue != null ? (int)comboTypeFilter.SelectedValue : 0;
            if (selectedTypeId != 0)
            {
                query = query.Where(ts => ts.ActivityTypeId == selectedTypeId);
            }
            var filteredList = query.ToList();
            // Konfiguracja kolumn DataGridView (jeśli jeszcze nie skonfigurowane)
            if (dataGridView.Columns.Count == 0)
            {
                dataGridView.Columns.Add("colDate", "Data");
                dataGridView.Columns.Add("colType", "Aktywność");
                dataGridView.Columns.Add("colDistance", "Dystans (km)");
                dataGridView.Columns.Add("colDuration", "Czas trwania");
                dataGridView.Columns.Add("colCalories", "Kalorie");
                dataGridView.Columns.Add("colSteps", "Kroki");
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView.RowHeadersVisible = false;
            }
            // Wyczyść i dodaj przefiltrowane wiersze
            dataGridView.Rows.Clear();
            foreach (var ts in filteredList)
            {
                string durationStr = ts.Duration.ToString(@"hh\:mm\:ss");
                dataGridView.Rows.Add(ts.Date.ToShortDateString(), ts.ActivityType != null ? ts.ActivityType.Name : "", ts.Distance, durationStr, ts.Calories, ts.Steps);
            }
        }

        // Obsługa zmiany stanu checkboxa filtrowania daty
        private void checkBoxDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerFilter.Enabled = checkBoxDateFilter.Checked;
            ApplyFilters();
        }

        // Obsługa zmiany filtrów (typ aktywności lub data)
        private void filterControlChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}
