using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using TreningTracker.Data;
using TreningTracker.Models;

namespace TreningTracker.Forms
{
    public partial class HistoryForm : Form
    {
        private AppDbContext _context;
        private List<TrainingSession> _allSessions;

        public HistoryForm()
        {
            _context = new AppDbContext();
            InitializeComponent();

            _allSessions = _context.TrainingSessions
                                   .Include(ts => ts.ActivityType)
                                   .ToList();

            var types = _context.ActivityTypes.ToList();

            types.Insert(0, new ActivityType { Id = 0, Name = "Wszystkie" });

            comboTypeFilter.DataSource = types;
            comboTypeFilter.DisplayMember = "Name";
            comboTypeFilter.ValueMember = "Id";
            comboTypeFilter.SelectedIndex = 0;

            checkBoxDateFilter.Checked = false;
            dateTimePickerFilter.Enabled = false;

            ApplyFilters();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void ApplyFilters()
        {
            IEnumerable<TrainingSession> query = _allSessions;

            if (checkBoxDateFilter.Checked)
            {
                DateTime selectedDate = dateTimePickerFilter.Value.Date;
                query = query.Where(ts => ts.Date.Date == selectedDate);
            }

            int selectedTypeId = 0;
            if (comboTypeFilter.SelectedValue != null)
            {
                if (comboTypeFilter.SelectedValue is int intValue)
                {
                    selectedTypeId = intValue;
                }
                else if (comboTypeFilter.SelectedValue is ActivityType activityType)
                {
                    selectedTypeId = activityType.Id;
                }
            }

            if (selectedTypeId != 0)
            {
                query = query.Where(ts => ts.ActivityTypeId == selectedTypeId);
            }

            var filteredList = query.ToList();

            if (dataGridView.Columns.Count == 0)
            {
                dataGridView.Columns.Add("colId", "Id");
                dataGridView.Columns.Add("colDate", "Data");
                dataGridView.Columns.Add("colType", "Aktywność");
                dataGridView.Columns.Add("colDistance", "Dystans (km)");
                dataGridView.Columns.Add("colDuration", "Czas trwania");
                dataGridView.Columns.Add("colCalories", "Kalorie");
                dataGridView.Columns.Add("colSteps", "Kroki");
                dataGridView.Columns["colId"].Visible = false;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView.RowHeadersVisible = false;
            }

            dataGridView.Rows.Clear();
            foreach (var ts in filteredList)
            {
                string durationStr = ts.Duration.ToString(@"hh\:mm\:ss");
                dataGridView.Rows.Add(
                    ts.Id,
                    ts.Date.ToShortDateString(),
                    ts.ActivityType != null ? ts.ActivityType.Name : "",
                    ts.Distance,
                    durationStr,
                    ts.Calories,
                    ts.Steps
                );
            }
        }

        private void checkBoxDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerFilter.Enabled = checkBoxDateFilter.Checked;
            ApplyFilters();
        }

        private void filterControlChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0 && dataGridView.SelectedCells.Count == 0)
            {
                MessageBox.Show("Zaznacz rekord do usunięcia.", "Informacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowIndex = dataGridView.SelectedCells[0].RowIndex;

            int sessionId = Convert.ToInt32(dataGridView.Rows[rowIndex].Cells["colId"].Value);

            var result = MessageBox.Show("Czy na pewno chcesz usunąć wybraną sesję treningową?",
                "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var session = _context.TrainingSessions.Find(sessionId);
                    if (session != null)
                    {
                        _context.TrainingSessions.Remove(session);
                        _context.SaveChanges();

                        _allSessions.RemoveAll(s => s.Id == sessionId);

                        ApplyFilters();

                        MessageBox.Show("Sesja treningowa została usunięta.", "Sukces",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas usuwania: {ex.Message}", "Błąd",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
