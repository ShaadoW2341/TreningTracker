using TreningTracker.Data;

namespace TreningTracker
{
    public partial class MainForm : Form
    {
        // Pola prywatne
        private AppDbContext _context;
        private System.ComponentModel.IContainer components = null;
        private GroupBox groupDaily;
        private GroupBox groupWeekly;
        private Label labelDaySteps;
        private Label labelDayTrainings;
        private Label labelWeekSteps;
        private Label labelWeekTrainings;
        private Button buttonAddTraining;
        private Button buttonHistory;
        private Button buttonStats;
        private Button buttonCharts;
        private Button buttonGoals;

        public MainForm()
        {
            _context = new AppDbContext();
            InitializeComponent();
            // Załaduj dane podsumowania dnia i tygodnia
            RefreshSummaryData();
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
            this.groupDaily = new GroupBox();
            this.groupWeekly = new GroupBox();
            this.labelDaySteps = new Label();
            this.labelDayTrainings = new Label();
            this.labelWeekSteps = new Label();
            this.labelWeekTrainings = new Label();
            this.buttonAddTraining = new Button();
            this.buttonHistory = new Button();
            this.buttonStats = new Button();
            this.buttonCharts = new Button();
            this.buttonGoals = new Button();
            this.SuspendLayout();
            // 
            // groupDaily
            // 
            this.groupDaily.Controls.Add(this.labelDaySteps);
            this.groupDaily.Controls.Add(this.labelDayTrainings);
            this.groupDaily.Location = new System.Drawing.Point(10, 10);
            this.groupDaily.Name = "groupDaily";
            this.groupDaily.Size = new System.Drawing.Size(370, 80);
            this.groupDaily.TabIndex = 0;
            this.groupDaily.TabStop = false;
            this.groupDaily.Text = "Podsumowanie dnia";
            // 
            // labelDaySteps
            // 
            this.labelDaySteps.AutoSize = true;
            this.labelDaySteps.Location = new System.Drawing.Point(10, 25);
            this.labelDaySteps.Name = "labelDaySteps";
            this.labelDaySteps.Size = new System.Drawing.Size(0, 15);
            this.labelDaySteps.TabIndex = 0;
            // 
            // labelDayTrainings
            // 
            this.labelDayTrainings.AutoSize = true;
            this.labelDayTrainings.Location = new System.Drawing.Point(10, 50);
            this.labelDayTrainings.Name = "labelDayTrainings";
            this.labelDayTrainings.Size = new System.Drawing.Size(0, 15);
            this.labelDayTrainings.TabIndex = 1;
            // 
            // groupWeekly
            // 
            this.groupWeekly.Controls.Add(this.labelWeekSteps);
            this.groupWeekly.Controls.Add(this.labelWeekTrainings);
            this.groupWeekly.Location = new System.Drawing.Point(390, 10);
            this.groupWeekly.Name = "groupWeekly";
            this.groupWeekly.Size = new System.Drawing.Size(370, 80);
            this.groupWeekly.TabIndex = 1;
            this.groupWeekly.TabStop = false;
            this.groupWeekly.Text = "Podsumowanie tygodnia";
            // 
            // labelWeekSteps
            // 
            this.labelWeekSteps.AutoSize = true;
            this.labelWeekSteps.Location = new System.Drawing.Point(10, 25);
            this.labelWeekSteps.Name = "labelWeekSteps";
            this.labelWeekSteps.Size = new System.Drawing.Size(0, 15);
            this.labelWeekSteps.TabIndex = 0;
            // 
            // labelWeekTrainings
            // 
            this.labelWeekTrainings.AutoSize = true;
            this.labelWeekTrainings.Location = new System.Drawing.Point(10, 50);
            this.labelWeekTrainings.Name = "labelWeekTrainings";
            this.labelWeekTrainings.Size = new System.Drawing.Size(0, 15);
            this.labelWeekTrainings.TabIndex = 1;
            // 
            // buttonAddTraining
            // 
            this.buttonAddTraining.Location = new System.Drawing.Point(10, 100);
            this.buttonAddTraining.Name = "buttonAddTraining";
            this.buttonAddTraining.Size = new System.Drawing.Size(120, 30);
            this.buttonAddTraining.TabIndex = 2;
            this.buttonAddTraining.Text = "Dodaj trening";
            this.buttonAddTraining.UseVisualStyleBackColor = true;
            this.buttonAddTraining.Click += new System.EventHandler(this.buttonAddTraining_Click);
            // 
            // buttonHistory
            // 
            this.buttonHistory.Location = new System.Drawing.Point(140, 100);
            this.buttonHistory.Name = "buttonHistory";
            this.buttonHistory.Size = new System.Drawing.Size(120, 30);
            this.buttonHistory.TabIndex = 3;
            this.buttonHistory.Text = "Historia";
            this.buttonHistory.UseVisualStyleBackColor = true;
            this.buttonHistory.Click += new System.EventHandler(this.buttonHistory_Click);
            // 
            // buttonStats
            // 
            this.buttonStats.Location = new System.Drawing.Point(270, 100);
            this.buttonStats.Name = "buttonStats";
            this.buttonStats.Size = new System.Drawing.Size(120, 30);
            this.buttonStats.TabIndex = 4;
            this.buttonStats.Text = "Statystyki";
            this.buttonStats.UseVisualStyleBackColor = true;
            this.buttonStats.Click += new System.EventHandler(this.buttonStats_Click);
            // 
            // buttonCharts
            // 
            this.buttonCharts.Location = new System.Drawing.Point(400, 100);
            this.buttonCharts.Name = "buttonCharts";
            this.buttonCharts.Size = new System.Drawing.Size(120, 30);
            this.buttonCharts.TabIndex = 5;
            this.buttonCharts.Text = "Wykresy";
            this.buttonCharts.UseVisualStyleBackColor = true;
            this.buttonCharts.Click += new System.EventHandler(this.buttonCharts_Click);
            // 
            // buttonGoals
            // 
            this.buttonGoals.Location = new System.Drawing.Point(530, 100);
            this.buttonGoals.Name = "buttonGoals";
            this.buttonGoals.Size = new System.Drawing.Size(120, 30);
            this.buttonGoals.TabIndex = 6;
            this.buttonGoals.Text = "Cele";
            this.buttonGoals.UseVisualStyleBackColor = true;
            this.buttonGoals.Click += new System.EventHandler(this.buttonGoals_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 150);
            this.Controls.Add(this.groupDaily);
            this.Controls.Add(this.groupWeekly);
            this.Controls.Add(this.buttonAddTraining);
            this.Controls.Add(this.buttonHistory);
            this.Controls.Add(this.buttonStats);
            this.Controls.Add(this.buttonCharts);
            this.Controls.Add(this.buttonGoals);
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Trening Tracker";
            this.ResumeLayout(false);
        }

        #endregion

        // Odświeżenie danych podsumowania dnia i tygodnia
        private void RefreshSummaryData()
        {
            // Pobranie celów
            var goal = _context.GoalSettings.FirstOrDefault();
            int dailyGoal = goal != null ? goal.DailyStepsGoal : 0;
            int weeklyGoal = goal != null ? goal.WeeklyTrainingsGoal : 0;
            // Dzisiejsza data bez czasu
            DateTime today = DateTime.Today;
            // Początek i koniec bieżącego tygodnia (poniedziałek - niedziela)
            int dow = (int)today.DayOfWeek;
            if (dow == 0) dow = 7; // niedziela jako 7
            DateTime weekStart = today.AddDays(1 - dow).Date;
            DateTime weekEnd = weekStart.AddDays(6).Date;
            // Obliczenia podsumowania
            int stepsToday = _context.TrainingSessions.Where(ts => ts.Date.Date == today).Sum(ts => ts.Steps);
            int trainingsToday = _context.TrainingSessions.Count(ts => ts.Date.Date == today);
            int stepsThisWeek = _context.TrainingSessions.Where(ts => ts.Date.Date >= weekStart && ts.Date.Date <= weekEnd).Sum(ts => ts.Steps);
            int trainingsThisWeek = _context.TrainingSessions.Count(ts => ts.Date.Date >= weekStart && ts.Date.Date <= weekEnd);
            // Ustawienie tekstów etykiet
            this.labelDaySteps.Text = $"Kroki dzisiaj: {stepsToday} / {dailyGoal}" + (stepsToday >= dailyGoal && dailyGoal > 0 ? " (cel osiągnięty)" : "");
            this.labelDayTrainings.Text = $"Dzisiejsze treningi: {trainingsToday}";
            this.labelWeekSteps.Text = $"Kroki w tym tygodniu: {stepsThisWeek}";
            this.labelWeekTrainings.Text = $"Treningi w tym tygodniu: {trainingsThisWeek} / {weeklyGoal}" + (trainingsThisWeek >= weeklyGoal && weeklyGoal > 0 ? " (cel osiągnięty)" : "");
        }

        // Obsługa kliknięcia przycisku Dodaj trening
        private void buttonAddTraining_Click(object sender, EventArgs e)
        {
            using (var form = new AddTrainingForm())
            {
                form.ShowDialog();
            }
            // Po zamknięciu okna dodawania odśwież podsumowanie (mogły się zmienić dane)
            RefreshSummaryData();
        }

        // Obsługa kliknięcia przycisku Historia
        private void buttonHistory_Click(object sender, EventArgs e)
        {
            var form = new HistoryForm();
            form.Show();
        }

        // Obsługa kliknięcia przycisku Statystyki
        private void buttonStats_Click(object sender, EventArgs e)
        {
            var form = new StatsForm();
            form.Show();
        }

        // Obsługa kliknięcia przycisku Wykresy
        private void buttonCharts_Click(object sender, EventArgs e)
        {
            var form = new ChartsForm();
            form.Show();
        }

        // Obsługa kliknięcia przycisku Cele
        private void buttonGoals_Click(object sender, EventArgs e)
        {
            using (var form = new GoalsForm())
            {
                form.ShowDialog();
            }
            // Po zamknięciu okna celów odśwież wartości celów w podsumowaniu
            RefreshSummaryData();
        }
    }
}
