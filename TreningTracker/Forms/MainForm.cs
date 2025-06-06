using System;
using System.Linq;
using System.Windows.Forms;
using TreningTracker.Data;
using TreningTracker.Models;

namespace TreningTracker.Forms
{
    public partial class MainForm : Form
    {
        private AppDbContext _context;
        private System.ComponentModel.IContainer components = null;

        public MainForm()
        {
            _context = new AppDbContext();
            InitializeComponent();
            RefreshSummaryData();
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

        public void RefreshSummaryData()
        {
            var goal = _context.GoalSettings.FirstOrDefault();
            int dailyGoal = goal != null ? goal.DailyStepsGoal : 0;
            int weeklyGoal = goal != null ? goal.WeeklyTrainingsGoal : 0;

            DateTime todayUtc = DateTime.Today.ToUniversalTime();

            int dow = (int)todayUtc.DayOfWeek;
            if (dow == 0) dow = 7;
            DateTime weekStartUtc = todayUtc.AddDays(1 - dow).Date;
            DateTime weekEndUtc = weekStartUtc.AddDays(6).Date;

            var sessions = _context.TrainingSessions.ToList();
            
            var todaySessions = sessions.Where(ts => ts.Date.Date == todayUtc.Date).ToList();
            var weekSessions = sessions.Where(ts => 
                ts.Date.Date >= weekStartUtc.Date && 
                ts.Date.Date <= weekEndUtc.Date).ToList();
            
            int stepsToday = todaySessions.Sum(ts => ts.Steps);
            int trainingsToday = todaySessions.Count;
            
            int stepsThisWeek = weekSessions.Sum(ts => ts.Steps);
            int trainingsThisWeek = weekSessions.Count;

            labelDaySteps.Text = $"Kroki dzisiaj: {stepsToday} / {dailyGoal}"
                + (stepsToday >= dailyGoal && dailyGoal > 0 ? " (cel osiągnięty)" : "");
            labelDayTrainings.Text = $"Dzisiejsze treningi: {trainingsToday}";

            labelWeekSteps.Text = $"Kroki w tym tygodniu: {stepsThisWeek}";
            labelWeekTrainings.Text = $"Treningi w tym tygodniu: {trainingsThisWeek} / {weeklyGoal}"
                + (trainingsThisWeek >= weeklyGoal && weeklyGoal > 0 ? " (cel osiągnięty)" : "");
        }

        private void buttonAddTraining_Click(object sender, EventArgs e)
        {
            using (var form = new AddTrainingForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)  
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                    }
                    _context = new AppDbContext();
                    RefreshSummaryData();
                }
            }
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            var form = new HistoryForm();
            form.Show();
        }

        private void buttonStats_Click(object sender, EventArgs e)
        {
            var form = new StatsForm();
            form.Show();
        }

        private void buttonCharts_Click(object sender, EventArgs e)
        {
            var form = new ChartsForm();
            form.Show();
        }

        private void buttonGoals_Click(object sender, EventArgs e)
        {
            using (var form = new GoalsForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                    }
                    _context = new AppDbContext();
                    RefreshSummaryData();
                }
            }
        }
    }
}
