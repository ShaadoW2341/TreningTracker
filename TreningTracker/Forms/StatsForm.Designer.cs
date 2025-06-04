using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using TreningTracker.Data;
using TreningTracker.Models;

namespace TreningTracker
{
    public partial class StatsForm : Form
    {
        private AppDbContext _context;
        private System.ComponentModel.IContainer components = null;
        private Label labelStats;

        public StatsForm()
        {
            _context = new AppDbContext();
            InitializeComponent();
            // Obliczenie statystyk
            LoadStatistics();
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
            this.labelStats = new Label();
            this.SuspendLayout();
            // 
            // labelStats
            // 
            this.labelStats.AutoSize = true;
            this.labelStats.Location = new System.Drawing.Point(10, 10);
            this.labelStats.Name = "labelStats";
            this.labelStats.Size = new System.Drawing.Size(0, 15);
            this.labelStats.TabIndex = 0;
            // 
            // StatsForm
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.labelStats);
            this.Name = "StatsForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Statystyki ogólne";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Załadowanie i wyświetlenie statystyk
        private void LoadStatistics()
        {
            var sessions = _context.TrainingSessions.ToList();
            if (sessions.Count == 0)
            {
                labelStats.Text = "Brak danych do wyświetlenia statystyk.";
                return;
            }
            int totalTrainings = sessions.Count;
            double totalDistance = sessions.Sum(s => s.Distance);
            TimeSpan totalDuration = new TimeSpan(sessions.Sum(s => s.Duration.Ticks));
            int totalCalories = sessions.Sum(s => s.Calories);
            int totalSteps = sessions.Sum(s => s.Steps);
            double averageDistance = sessions.Average(s => s.Distance);
            TimeSpan averageDuration = new TimeSpan((long)(sessions.Average(s => s.Duration.Ticks)));
            double averageCalories = sessions.Average(s => s.Calories);
            double averageSteps = sessions.Average(s => s.Steps);
            double maxDistance = sessions.Max(s => s.Distance);
            TimeSpan longestDuration = sessions.Max(s => s.Duration);
            int maxCalories = sessions.Max(s => s.Calories);
            int maxSteps = sessions.Max(s => s.Steps);
            labelStats.Text = "";
            labelStats.Text += $"Łączna liczba treningów: {totalTrainings}\n";
            labelStats.Text += $"Łączny dystans: {totalDistance:F2} km\n";
            labelStats.Text += $"Łączny czas trwania: {totalDuration:hh\\:mm\\:ss}\n";
            labelStats.Text += $"Łączne kalorie: {totalCalories} kcal\n";
            labelStats.Text += $"Łączne kroki: {totalSteps}\n";
            labelStats.Text += $"Średni dystans na trening: {averageDistance:F2} km\n";
            labelStats.Text += $"Średni czas trwania treningu: {averageDuration:hh\\:mm\\:ss}\n";
            labelStats.Text += $"Średnia liczba kalorii na trening: {averageCalories:F1} kcal\n";
            labelStats.Text += $"Średnia liczba kroków na trening: {averageSteps:F0}\n";
            labelStats.Text += $"Najdłuższy dystans: {maxDistance:F2} km\n";
            labelStats.Text += $"Najdłuższy czas trwania: {longestDuration:hh\\:mm\\:ss}\n";
            labelStats.Text += $"Najwięcej kalorii w jednym treningu: {maxCalories} kcal\n";
            labelStats.Text += $"Najwięcej kroków w jednym treningu: {maxSteps}";
        }
    }
}
