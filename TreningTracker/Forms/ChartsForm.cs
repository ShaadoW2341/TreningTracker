using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using TreningTracker.Data;
using TreningTracker.Models;

namespace TreningTracker.Forms
{
    public partial class ChartsForm : Form
    {
        private AppDbContext _context;

        private int[] weeklySteps = new int[7];
        private string[] weeklyLabels = new string[7];
        private int[] monthlyCounts;
        private string[] monthlyLabels;

        public ChartsForm()
        {
            _context = new AppDbContext();
            InitializeComponent();
            PrepareData();
            pictureWeekly.Invalidate();
            pictureMonthly.Invalidate();
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

        private void PrepareData()
        {
            DateTime today = DateTime.Today.ToUniversalTime();

            int dow = (int)today.DayOfWeek;
            if (dow == 0) dow = 7;
            DateTime weekStart = today.AddDays(1 - dow).Date;
            for (int i = 0; i < 7; i++)
            {
                DateTime day = weekStart.AddDays(i);
                weeklyLabels[i] = day.ToString("ddd", new CultureInfo("pl-PL"));
                int steps = _context.TrainingSessions
                                    .Where(ts => ts.Date.Date == day.Date)
                                    .Sum(ts => ts.Steps);
                weeklySteps[i] = steps;
            }

            int year = today.Year;
            int months = today.Month;
            monthlyCounts = new int[months];
            monthlyLabels = new string[months];
            for (int m = 1; m <= months; m++)
            {
                monthlyLabels[m - 1] = new DateTime(year, m, 1)
                                            .ToString("MMM", new CultureInfo("pl-PL"));
                int count = _context.TrainingSessions
                                    .Count(ts => ts.Date.Year == year && ts.Date.Month == m);
                monthlyCounts[m - 1] = count;
            }
        }

        private void pictureWeekly_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            int w = pictureWeekly.ClientSize.Width;
            int h = pictureWeekly.ClientSize.Height;
            int margin = 30;
            int availableWidth = w - 2 * margin;
            int availableHeight = h - 2 * margin;

            int maxSteps = weeklySteps.Max();
            if (maxSteps == 0) maxSteps = 1;

            int barWidth = availableWidth / 7;
            for (int i = 0; i < 7; i++)
            {
                float barHeight = (float)weeklySteps[i] / maxSteps * (availableHeight - 20);
                float x = margin + i * barWidth;
                float y = margin + (availableHeight - barHeight);
                RectangleF rect = new RectangleF(x + 2, y, barWidth - 4, barHeight);
                g.FillRectangle(Brushes.SteelBlue, rect);
                g.DrawRectangle(Pens.Black, x + 2, y, barWidth - 4, barHeight);

                SizeF labelSize = g.MeasureString(weeklyLabels[i], this.Font);
                float lx = x + (barWidth - labelSize.Width) / 2;
                float ly = margin + availableHeight + 2;
                g.DrawString(weeklyLabels[i], this.Font, Brushes.Black, lx, ly);
            }

            g.DrawString("0", this.Font, Brushes.Black, 2, margin + availableHeight - 10);
            string maxLabel = maxSteps.ToString();
            SizeF maxSize = g.MeasureString(maxLabel, this.Font);
            g.DrawString(maxLabel, this.Font, Brushes.Black, 2, margin - maxSize.Height);
        }

        private void pictureMonthly_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            int w = pictureMonthly.ClientSize.Width;
            int h = pictureMonthly.ClientSize.Height;
            int margin = 30;
            int months = monthlyCounts.Length;
            int availableWidth = w - 2 * margin;
            int availableHeight = h - 2 * margin;

            int maxCount = monthlyCounts.Max();
            if (maxCount == 0) maxCount = 1;

            int barWidth = availableWidth / months;
            for (int i = 0; i < months; i++)
            {
                float barHeight = (float)monthlyCounts[i] / maxCount * (availableHeight - 20);
                float x = margin + i * barWidth;
                float y = margin + (availableHeight - barHeight);
                RectangleF rect = new RectangleF(x + 2, y, barWidth - 4, barHeight);
                g.FillRectangle(Brushes.DarkGreen, rect);
                g.DrawRectangle(Pens.Black, x + 2, y, barWidth - 4, barHeight);

                SizeF labelSize = g.MeasureString(monthlyLabels[i], this.Font);
                float lx = x + (barWidth - labelSize.Width) / 2;
                float ly = margin + availableHeight + 2;
                g.DrawString(monthlyLabels[i], this.Font, Brushes.Black, lx, ly);
            }

            g.DrawString("0", this.Font, Brushes.Black, 2, margin + availableHeight - 10);
            string maxLabel = maxCount.ToString();
            SizeF maxSize = g.MeasureString(maxLabel, this.Font);
            g.DrawString(maxLabel, this.Font, Brushes.Black, 2, margin - maxSize.Height);
        }
    }
}
