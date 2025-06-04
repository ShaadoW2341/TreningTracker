using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using TreningTracker.Data;
using TreningTracker.Models;

namespace TreningTracker
{
    public partial class GoalsForm : Form
    {
        private AppDbContext _context;
        private System.ComponentModel.IContainer components = null;
        private Label labelDailyGoal;
        private NumericUpDown numericDailyGoal;
        private Label labelWeeklyGoal;
        private NumericUpDown numericWeeklyGoal;
        private Button buttonSave;
        private Button buttonCancel;
        // Bieżące ustawienie celów
        private GoalSetting currentGoals;

        public GoalsForm()
        {
            _context = new AppDbContext();
            InitializeComponent();
            // Wczytaj bieżące cele z bazy
            currentGoals = _context.GoalSettings.FirstOrDefault();
            if (currentGoals != null)
            {
                numericDailyGoal.Value = currentGoals.DailyStepsGoal;
                numericWeeklyGoal.Value = currentGoals.WeeklyTrainingsGoal;
            }
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
            this.labelDailyGoal = new Label();
            this.numericDailyGoal = new NumericUpDown();
            this.labelWeeklyGoal = new Label();
            this.numericWeeklyGoal = new NumericUpDown();
            this.buttonSave = new Button();
            this.buttonCancel = new Button();
            this.SuspendLayout();
            // 
            // labelDailyGoal
            // 
            this.labelDailyGoal.AutoSize = true;
            this.labelDailyGoal.Location = new System.Drawing.Point(10, 20);
            this.labelDailyGoal.Name = "labelDailyGoal";
            this.labelDailyGoal.Size = new System.Drawing.Size(110, 15);
            this.labelDailyGoal.TabIndex = 0;
            this.labelDailyGoal.Text = "Dzienny cel kroków:";
            // 
            // numericDailyGoal
            // 
            this.numericDailyGoal.Location = new System.Drawing.Point(220, 18);
            this.numericDailyGoal.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericDailyGoal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDailyGoal.Name = "numericDailyGoal";
            this.numericDailyGoal.Size = new System.Drawing.Size(80, 23);
            this.numericDailyGoal.TabIndex = 1;
            this.numericDailyGoal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelWeeklyGoal
            // 
            this.labelWeeklyGoal.AutoSize = true;
            this.labelWeeklyGoal.Location = new System.Drawing.Point(10, 60);
            this.labelWeeklyGoal.Name = "labelWeeklyGoal";
            this.labelWeeklyGoal.Size = new System.Drawing.Size(149, 15);
            this.labelWeeklyGoal.TabIndex = 2;
            this.labelWeeklyGoal.Text = "Tygodniowy cel treningów:";
            // 
            // numericWeeklyGoal
            // 
            this.numericWeeklyGoal.Location = new System.Drawing.Point(220, 58);
            this.numericWeeklyGoal.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.numericWeeklyGoal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWeeklyGoal.Name = "numericWeeklyGoal";
            this.numericWeeklyGoal.Size = new System.Drawing.Size(80, 23);
            this.numericWeeklyGoal.TabIndex = 3;
            this.numericWeeklyGoal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(140, 100);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(80, 30);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Zapisz";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(230, 100);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 30);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // GoalsForm
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 160);
            this.Controls.Add(this.labelDailyGoal);
            this.Controls.Add(this.numericDailyGoal);
            this.Controls.Add(this.labelWeeklyGoal);
            this.Controls.Add(this.numericWeeklyGoal);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Name = "GoalsForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Konfiguracja celów";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Obsługa kliknięcia przycisku Zapisz
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (currentGoals == null)
            {
                // Jeśli brak rekordu celów, utwórz nowy
                currentGoals = new GoalSetting();
                _context.GoalSettings.Add(currentGoals);
            }
            currentGoals.DailyStepsGoal = (int)numericDailyGoal.Value;
            currentGoals.WeeklyTrainingsGoal = (int)numericWeeklyGoal.Value;
            _context.SaveChanges();
            MessageBox.Show("Cele zostały zapisane.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        // Obsługa kliknięcia przycisku Anuluj
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
