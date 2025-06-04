using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using TreningTracker.Data;
using TreningTracker.Models;

namespace TreningTracker
{
    public partial class AddTrainingForm : Form
    {
        private AppDbContext _context;
        private System.ComponentModel.IContainer components = null;
        private Label labelDate;
        private Label labelType;
        private Label labelDistance;
        private Label labelDuration;
        private Label labelCalories;
        private Label labelSteps;
        private DateTimePicker dateTimePickerDate;
        private ComboBox comboActivityType;
        private NumericUpDown numericDistance;
        private NumericUpDown numericHours;
        private NumericUpDown numericMinutes;
        private NumericUpDown numericCalories;
        private NumericUpDown numericSteps;
        private Button buttonSave;
        private Button buttonCancel;

        public AddTrainingForm()
        {
            _context = new AppDbContext();
            InitializeComponent();
            // Ustawienia pól domyślne
            this.dateTimePickerDate.Value = DateTime.Today;
            // Załaduj listę typów aktywności do pola wyboru
            var activityTypes = _context.ActivityTypes.ToList();
            if (activityTypes.Count > 0)
            {
                this.comboActivityType.DataSource = activityTypes;
                this.comboActivityType.DisplayMember = "Name";
                this.comboActivityType.ValueMember = "Id";
                this.comboActivityType.SelectedIndex = 0;
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
            this.labelDate = new Label();
            this.labelType = new Label();
            this.labelDistance = new Label();
            this.labelDuration = new Label();
            this.labelCalories = new Label();
            this.labelSteps = new Label();
            this.dateTimePickerDate = new DateTimePicker();
            this.comboActivityType = new ComboBox();
            this.numericDistance = new NumericUpDown();
            this.numericHours = new NumericUpDown();
            this.numericMinutes = new NumericUpDown();
            this.numericCalories = new NumericUpDown();
            this.numericSteps = new NumericUpDown();
            this.buttonSave = new Button();
            this.buttonCancel = new Button();
            this.SuspendLayout();
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(10, 20);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(33, 15);
            this.labelDate.TabIndex = 0;
            this.labelDate.Text = "Data:";
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Format = DateTimePickerFormat.Short;
            this.dateTimePickerDate.Location = new System.Drawing.Point(150, 18);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerDate.TabIndex = 1;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(10, 60);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(84, 15);
            this.labelType.TabIndex = 2;
            this.labelType.Text = "Typ aktywności:";
            // 
            // comboActivityType
            // 
            this.comboActivityType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboActivityType.Location = new System.Drawing.Point(150, 58);
            this.comboActivityType.Name = "comboActivityType";
            this.comboActivityType.Size = new System.Drawing.Size(180, 23);
            this.comboActivityType.TabIndex = 3;
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(10, 100);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(77, 15);
            this.labelDistance.TabIndex = 4;
            this.labelDistance.Text = "Dystans (km):";
            // 
            // numericDistance
            // 
            this.numericDistance.DecimalPlaces = 2;
            this.numericDistance.Location = new System.Drawing.Point(150, 98);
            this.numericDistance.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericDistance.Name = "numericDistance";
            this.numericDistance.Size = new System.Drawing.Size(80, 23);
            this.numericDistance.TabIndex = 5;
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(10, 140);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(80, 15);
            this.labelDuration.TabIndex = 6;
            this.labelDuration.Text = "Czas trwania:";
            // 
            // numericHours
            // 
            this.numericHours.Location = new System.Drawing.Point(150, 138);
            this.numericHours.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericHours.Name = "numericHours";
            this.numericHours.Size = new System.Drawing.Size(50, 23);
            this.numericHours.TabIndex = 7;
            // 
            // numericMinutes
            // 
            this.numericMinutes.Location = new System.Drawing.Point(250, 138);
            this.numericMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericMinutes.Name = "numericMinutes";
            this.numericMinutes.Size = new System.Drawing.Size(50, 23);
            this.numericMinutes.TabIndex = 8;
            // 
            // labelCalories
            // 
            this.labelCalories.AutoSize = true;
            this.labelCalories.Location = new System.Drawing.Point(10, 180);
            this.labelCalories.Name = "labelCalories";
            this.labelCalories.Size = new System.Drawing.Size(50, 15);
            this.labelCalories.TabIndex = 9;
            this.labelCalories.Text = "Kalorie:";
            // 
            // numericCalories
            // 
            this.numericCalories.Location = new System.Drawing.Point(150, 178);
            this.numericCalories.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericCalories.Name = "numericCalories";
            this.numericCalories.Size = new System.Drawing.Size(80, 23);
            this.numericCalories.TabIndex = 10;
            // 
            // labelSteps
            // 
            this.labelSteps.AutoSize = true;
            this.labelSteps.Location = new System.Drawing.Point(10, 220);
            this.labelSteps.Name = "labelSteps";
            this.labelSteps.Size = new System.Drawing.Size(41, 15);
            this.labelSteps.TabIndex = 11;
            this.labelSteps.Text = "Kroki:";
            // 
            // numericSteps
            // 
            this.numericSteps.Location = new System.Drawing.Point(150, 218);
            this.numericSteps.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericSteps.Name = "numericSteps";
            this.numericSteps.Size = new System.Drawing.Size(100, 23);
            this.numericSteps.TabIndex = 12;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(220, 270);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(80, 30);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Zapisz";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(310, 270);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 30);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AddTrainingForm
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.comboActivityType);
            this.Controls.Add(this.labelDistance);
            this.Controls.Add(this.numericDistance);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.numericHours);
            this.Controls.Add(this.numericMinutes);
            this.Controls.Add(this.labelCalories);
            this.Controls.Add(this.numericCalories);
            this.Controls.Add(this.labelSteps);
            this.Controls.Add(this.numericSteps);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Name = "AddTrainingForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Dodaj trening";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Obsługa kliknięcia przycisku Zapisz
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Walidacja danych wejściowych
            if (numericHours.Value == 0 && numericMinutes.Value == 0)
            {
                MessageBox.Show("Czas trwania treningu musi być dłuższy niż 0.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Utworzenie nowego obiektu treningu
            TrainingSession newSession = new TrainingSession();
            newSession.Date = dateTimePickerDate.Value.Date;
            newSession.Distance = (double)numericDistance.Value;
            newSession.Duration = new TimeSpan((int)numericHours.Value, (int)numericMinutes.Value, 0);
            newSession.Calories = (int)numericCalories.Value;
            newSession.Steps = (int)numericSteps.Value;
            newSession.ActivityTypeId = comboActivityType.SelectedValue != null ? (int)comboActivityType.SelectedValue : 0;
            // Zapis do bazy danych
            _context.TrainingSessions.Add(newSession);
            _context.SaveChanges();
            // Sprawdzenie realizacji celów
            var goal = _context.GoalSettings.FirstOrDefault();
            bool dailyGoalReached = false;
            bool weeklyGoalReached = false;
            if (goal != null)
            {
                // Suma kroków w dniu treningu
                DateTime sessionDate = newSession.Date;
                int totalStepsThatDay = _context.TrainingSessions.Where(ts => ts.Date.Date == sessionDate).Sum(ts => ts.Steps);
                if (totalStepsThatDay >= goal.DailyStepsGoal) dailyGoalReached = true;
                // Liczba treningów w tygodniu treningu
                int dow = (int)sessionDate.DayOfWeek;
                if (dow == 0) dow = 7;
                DateTime startOfWeek = sessionDate.AddDays(1 - dow).Date;
                DateTime endOfWeek = startOfWeek.AddDays(6);
                int totalTrainingsThatWeek = _context.TrainingSessions.Count(ts => ts.Date.Date >= startOfWeek && ts.Date.Date <= endOfWeek);
                if (totalTrainingsThatWeek >= goal.WeeklyTrainingsGoal) weeklyGoalReached = true;
            }
            // Komunikat o zapisaniu i ewentualnej realizacji celów
            string message = "Trening dodany pomyślnie.";
            if (dailyGoalReached && weeklyGoalReached)
                message += "\nGratulacje! Zrealizowano dzisiejszy cel kroków oraz tygodniowy cel treningów.";
            else if (dailyGoalReached)
                message += "\nGratulacje! Dzisiejszy cel kroków został osiągnięty.";
            else if (weeklyGoalReached)
                message += "\nGratulacje! Tygodniowy cel treningów został osiągnięty.";
            MessageBox.Show(message, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Zamknięcie formularza
            this.Close();
        }

        // Obsługa kliknięcia przycisku Anuluj
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
