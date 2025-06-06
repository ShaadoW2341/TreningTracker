using System;
using System.Linq;
using System.Windows.Forms;
using TreningTracker.Data;
using TreningTracker.Models;

namespace TreningTracker.Forms
{
    public partial class GoalsForm : Form
    {
        private AppDbContext _context;
        private GoalSetting currentGoals;

        public GoalsForm()
        {
            _context = new AppDbContext();
            InitializeComponent();

            currentGoals = _context.GoalSettings.FirstOrDefault();
            if (currentGoals == null)
            {
                numericDailyGoal.Value = currentGoals.DailyStepsGoal;
                numericWeeklyGoal.Value = currentGoals.WeeklyTrainingsGoal;
            }
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (currentGoals == null)
            {
                currentGoals = new GoalSetting();
                _context.GoalSettings.Add(currentGoals);
            }
            
            currentGoals.DailyStepsGoal = (int)numericDailyGoal.Value;
            currentGoals.WeeklyTrainingsGoal = (int)numericWeeklyGoal.Value;
            _context.SaveChanges();
            MessageBox.Show("Cele zostały zapisane.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
