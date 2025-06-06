using System;
using System.Linq;
using System.Windows.Forms;
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
        private TrainingSession _editingSession;
        private bool _isEditMode = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DialogResult FormResult { get; private set; } = DialogResult.Cancel;

        public AddTrainingForm(TrainingSession session)
        {
            InitializeComponent();
            _context = new AppDbContext();
            _stopwatchTimer = new Timer { Interval = 1000 };
            _stopwatchTimer.Tick += StopwatchTimer_Tick;

            _editingSession = session;
            _isEditMode = session != null && session.Id != 0;

            var activityTypes = _context.ActivityTypes.ToList();
            comboActivityType.DataSource = activityTypes;
            comboActivityType.DisplayMember = "Name";
            comboActivityType.ValueMember = "Id";

            if (_isEditMode)
            {
                LoadSessionData();
            }
            else
            {
                dateTimePickerDate.Value = DateTime.Today;
                comboActivityType.SelectedIndex = 0;
            }

            comboActivityType_SelectedIndexChanged(null, null);
        }

        private void LoadSessionData()
        {
            if (_editingSession == null)
                return;

            dateTimePickerDate.Value = _editingSession.Date.ToLocalTime();
            numericDistance.Value = (decimal)_editingSession.Distance;
            numericHours.Value = _editingSession.Duration.Hours;
            numericMinutes.Value = _editingSession.Duration.Minutes;
            numericSeconds.Value = _editingSession.Duration.Seconds;
            numericCalories.Value = _editingSession.Calories;
            numericSteps.Value = _editingSession.Steps;
            comboActivityType.SelectedValue = _editingSession.ActivityTypeId;
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

            numericHours.Value = _stopwatchTime.Hours;
            numericMinutes.Value = _stopwatchTime.Minutes;
            numericSeconds.Value = _stopwatchTime.Seconds;
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

            TrainingSession sessionToSave = _isEditMode ? _context.TrainingSessions.Find(_editingSession.Id) : new TrainingSession();

            sessionToSave.Date = dateTimePickerDate.Value.Date.ToUniversalTime();
            sessionToSave.Distance = (double)numericDistance.Value;
            sessionToSave.Duration = new TimeSpan((int)numericHours.Value, (int)numericMinutes.Value, (int)numericSeconds.Value);
            sessionToSave.Calories = (int)numericCalories.Value;
            sessionToSave.Steps = (int)numericSteps.Value;
            sessionToSave.ActivityTypeId = comboActivityType.SelectedValue != null ? (int)comboActivityType.SelectedValue : 0;

            if (!_isEditMode)
                _context.TrainingSessions.Add(sessionToSave);

            _context.SaveChanges();

            var goal = _context.GoalSettings.FirstOrDefault();
            bool dailyGoalReached = false;
            bool weeklyGoalReached = false;

            if (goal != null)
            {
                var sessionDate = sessionToSave.Date;
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

            string message = _isEditMode ? "Trening został zaktualizowany." : "Trening dodany pomyślnie.";
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
