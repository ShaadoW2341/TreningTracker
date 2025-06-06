using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using TreningTracker.Data;
using TreningTracker.Models;
using Timer = System.Windows.Forms.Timer;
using System.ComponentModel;

namespace TreningTracker.Forms
{
    public partial class AddTrainingForm : Form
    {
        private AppDbContext _context;
        private Timer _stopwatchTimer;
        private TimeSpan _stopwatchTime;
        private bool _stopwatchRunning = false;
        private MainForm refresh;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DialogResult FormResult { get; private set; } = DialogResult.Cancel;

        public AddTrainingForm()
        {
            refresh = new MainForm();
            _context = new AppDbContext();
            InitializeComponent();

            _stopwatchTimer = new System.Windows.Forms.Timer(); 
            _stopwatchTimer.Interval = 1000; 
            _stopwatchTimer.Tick += StopwatchTimer_Tick;

            dateTimePickerDate.Value = DateTime.Today.ToUniversalTime();

            var activityTypes = _context.ActivityTypes.ToList();
            if (activityTypes.Count > 0)
            {
                comboActivityType.DataSource = activityTypes;
                comboActivityType.DisplayMember = "Name";
                comboActivityType.ValueMember = "Id";
                comboActivityType.SelectedIndex = 0;
            }

            comboActivityType_SelectedIndexChanged(null, null);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_stopwatchTimer != null)
                {
                    _stopwatchTimer.Dispose();
                    _stopwatchTimer = null;
                }
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

        private void comboActivityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboActivityType.SelectedItem is not ActivityType selected)
                return;

            string name = selected.Name;

            switch (name)
            {
                case "Spacer":
                    labelDistance.Visible = numericDistance.Visible = true;
                    labelSteps.Visible = numericSteps.Visible = true;
                    break;

                case "Bieganie":
                case "Rower":
                    labelDistance.Visible = numericDistance.Visible = true;
                    labelSteps.Visible = numericSteps.Visible = false;
                    numericSteps.Value = 0;
                    break;

                case "Siłownia":
                    labelDistance.Visible = numericDistance.Visible = false;
                    labelSteps.Visible = numericSteps.Visible = false;
                    numericDistance.Value = 0;
                    numericSteps.Value = 0;
                    break;

                default:
                    labelDistance.Visible = numericDistance.Visible = false;
                    labelSteps.Visible = numericSteps.Visible = false;
                    numericDistance.Value = 0;
                    numericSteps.Value = 0;
                    break;
            }
        }


        private void StopwatchTimer_Tick(object sender, EventArgs e)
        {
            _stopwatchTime = _stopwatchTime.Add(TimeSpan.FromSeconds(1));

            int hours = _stopwatchTime.Hours;
            int minutes = _stopwatchTime.Minutes;
            int seconds = _stopwatchTime.Seconds;

            numericHours.Value = hours;
            numericMinutes.Value = minutes;
            numericSeconds.Value = seconds;
        }

        private void buttonStopwatch_Click(object sender, EventArgs e)
        {
            if (!_stopwatchRunning)
            {
                _stopwatchTime = TimeSpan.Zero;
                numericHours.Value = 0;
                numericMinutes.Value = 0;
                numericSeconds.Value = 0;

                numericSeconds.Visible = true;
                labelSeconds.Visible = true;

                _stopwatchTimer.Start();
                _stopwatchRunning = true;
                buttonStopwatch.Text = "Stop";
            }
            else
            {
                _stopwatchTimer.Stop();
                _stopwatchRunning = false;
                buttonStopwatch.Text = "Stoper";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (numericHours.Value == 0 && numericMinutes.Value == 0 && numericSeconds.Value == 0)
            {
                MessageBox.Show("Czas trwania treningu musi być dłuższy niż 0.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newSession = new TrainingSession
            {
                Date = dateTimePickerDate.Value.Date.ToUniversalTime(),
                Distance = (double)numericDistance.Value,
                Duration = new TimeSpan((int)numericHours.Value, (int)numericMinutes.Value, (int)numericSeconds.Value),
                Calories = (int)numericCalories.Value,
                Steps = (int)numericSteps.Value,
                ActivityTypeId = comboActivityType.SelectedValue != null ? (int)comboActivityType.SelectedValue : 0
            };

            _context.TrainingSessions.Add(newSession);
            _context.SaveChanges();

            var goal = _context.GoalSettings.FirstOrDefault();
            bool dailyGoalReached = false;
            bool weeklyGoalReached = false;

            if (goal != null)
            {
                var sessionDate = newSession.Date;
                int totalStepsThatDay = _context.TrainingSessions
                                                .Where(ts => ts.Date.Date == sessionDate.Date)
                                                .Sum(ts => ts.Steps);
                if (totalStepsThatDay >= goal.DailyStepsGoal)
                    dailyGoalReached = true;

                int dow = (int)sessionDate.DayOfWeek;
                if (dow == 0) dow = 7;
                var startOfWeek = sessionDate.AddDays(1 - dow).Date;
                var endOfWeek = startOfWeek.AddDays(6);
                int totalTrainingsThatWeek = _context.TrainingSessions
                                                     .Count(ts => ts.Date.Date >= startOfWeek && ts.Date.Date <= endOfWeek);
                if (totalTrainingsThatWeek >= goal.WeeklyTrainingsGoal)
                    weeklyGoalReached = true;
            }

            string message = "Trening dodany pomyślnie.";
            if (dailyGoalReached && weeklyGoalReached)
                message += "\nGratulacje! Zrealizowano dzisiejszy cel kroków oraz tygodniowy cel treningów.";
            else if (dailyGoalReached)
                message += "\nGratulacje! Dzisiejszy cel kroków został osiągnięty.";
            else if (weeklyGoalReached)
                message += "\nGratulacje! Tygodniowy cel treningów został osiągnięty.";

            MessageBox.Show(message, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            this.FormResult = DialogResult.OK;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (_stopwatchRunning)
            {
                _stopwatchTimer.Stop();
                _stopwatchRunning = false;
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
