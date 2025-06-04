using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using TreningTracker.Data;
using TreningTracker.Models;
using System.Windows.Forms.DataVisualization.Charting;

namespace TreningTracker
{
    public partial class ChartsForm : Form
    {
        private AppDbContext _context;
        private System.ComponentModel.IContainer components = null;
        private Chart chartWeekly;
        private Chart chartMonthly;

        public ChartsForm()
        {
            _context = new AppDbContext();
            InitializeComponent();
            // Załaduj dane do wykresów
            LoadChartsData();
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
            this.chartWeekly = new Chart();
            this.chartMonthly = new Chart();
            ChartArea chartArea1 = new ChartArea();
            ChartArea chartArea2 = new ChartArea();
            Series series1 = new Series();
            Series series2 = new Series();
            this.SuspendLayout();
            // 
            // chartWeekly
            // 
            chartArea1.Name = "ChartArea1";
            this.chartWeekly.ChartAreas.Add(chartArea1);
            this.chartWeekly.Legends.Clear();
            this.chartWeekly.Location = new System.Drawing.Point(10, 10);
            this.chartWeekly.Name = "chartWeekly";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = SeriesChartType.Column;
            series1.Name = "Series1";
            this.chartWeekly.Series.Add(series1);
            this.chartWeekly.Size = new System.Drawing.Size(760, 240);
            this.chartWeekly.TabIndex = 0;
            this.chartWeekly.Titles.Add("Aktualny tydzień");
            // 
            // chartMonthly
            // 
            chartArea2.Name = "ChartArea2";
            this.chartMonthly.ChartAreas.Add(chartArea2);
            this.chartMonthly.Legends.Clear();
            this.chartMonthly.Location = new System.Drawing.Point(10, 270);
            this.chartMonthly.Name = "chartMonthly";
            series2.ChartArea = "ChartArea2";
            series2.ChartType = SeriesChartType.Column;
            series2.Name = "Series1";
            this.chartMonthly.Series.Add(series2);
            this.chartMonthly.Size = new System.Drawing.Size(760, 240);
            this.chartMonthly.TabIndex = 1;
            this.chartMonthly.Titles.Add("Bieżący rok");
            // 
            // ChartsForm
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.chartWeekly);
            this.Controls.Add(this.chartMonthly);
            this.Name = "ChartsForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Wykresy";
            this.ResumeLayout(false);
        }

        #endregion

        // Załadowanie danych do wykresów
        private void LoadChartsData()
        {
            // Dane do wykresu tygodniowego (bieżący tydzień)
            DateTime today = DateTime.Today;
            int dow = (int)today.DayOfWeek;
            if (dow == 0) dow = 7;
            DateTime weekStart = today.AddDays(1 - dow).Date;
            DateTime weekEnd = weekStart.AddDays(6).Date;
            var weekSessions = _context.TrainingSessions.Where(ts => ts.Date.Date >= weekStart && ts.Date.Date <= weekEnd).ToList();
            Series weeklySeries = this.chartWeekly.Series[0];
            weeklySeries.Points.Clear();
            for (int i = 0; i < 7; i++)
            {
                DateTime day = weekStart.AddDays(i);
                int steps = weekSessions.Where(ts => ts.Date.Date == day.Date).Sum(ts => ts.Steps);
                // Użyj skrótu dnia tygodnia jako etykiety (Pon, Wt, etc.)
                string dayLabel = day.ToString("ddd", new CultureInfo("pl-PL"));
                weeklySeries.Points.AddXY(dayLabel, steps);
            }
            // Dane do wykresu miesięcznego (bieżący rok)
            int year = today.Year;
            var yearSessions = _context.TrainingSessions.Where(ts => ts.Date.Year == year).ToList();
            Series monthlySeries = this.chartMonthly.Series[0];
            monthlySeries.Points.Clear();
            for (int month = 1; month <= today.Month; month++)
            {
                int count = yearSessions.Count(ts => ts.Date.Year == year && ts.Date.Month == month);
                string monthName = new DateTime(year, month, 1).ToString("MMM", new CultureInfo("pl-PL"));
                monthlySeries.Points.AddXY(monthName, count);
            }
        }
    }
}
