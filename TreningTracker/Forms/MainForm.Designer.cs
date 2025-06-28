using System.ComponentModel;
using System.Windows.Forms;

namespace TreningTracker.Forms
{
    partial class MainForm
    {
        private GroupBox groupDaily;
        private GroupBox groupWeekly;
        private Label labelDaySteps;
        private Label labelDayTrainings;
        private Label labelWeekSteps;
        private Label labelWeekTrainings;
        private Button buttonAddTraining;
        private Button buttonHistory;
        private Button buttonStats;
        private Button buttonGoals;

        private void InitializeComponent()
        {
            groupDaily = new GroupBox();
            labelDaySteps = new Label();
            labelDayTrainings = new Label();
            groupWeekly = new GroupBox();
            labelWeekSteps = new Label();
            labelWeekTrainings = new Label();
            buttonAddTraining = new Button();
            buttonHistory = new Button();
            buttonStats = new Button();
            buttonGoals = new Button();
            button1 = new Button();
            groupDaily.SuspendLayout();
            groupWeekly.SuspendLayout();
            SuspendLayout();
            // 
            // groupDaily
            // 
            groupDaily.Controls.Add(labelDaySteps);
            groupDaily.Controls.Add(labelDayTrainings);
            groupDaily.Location = new Point(11, 13);
            groupDaily.Margin = new Padding(3, 4, 3, 4);
            groupDaily.Name = "groupDaily";
            groupDaily.Padding = new Padding(3, 4, 3, 4);
            groupDaily.Size = new Size(423, 107);
            groupDaily.TabIndex = 0;
            groupDaily.TabStop = false;
            groupDaily.Text = "Podsumowanie dnia";
            // 
            // labelDaySteps
            // 
            labelDaySteps.AutoSize = true;
            labelDaySteps.Location = new Point(11, 33);
            labelDaySteps.Name = "labelDaySteps";
            labelDaySteps.Size = new Size(0, 20);
            labelDaySteps.TabIndex = 0;
            // 
            // labelDayTrainings
            // 
            labelDayTrainings.AutoSize = true;
            labelDayTrainings.Location = new Point(11, 67);
            labelDayTrainings.Name = "labelDayTrainings";
            labelDayTrainings.Size = new Size(0, 20);
            labelDayTrainings.TabIndex = 1;
            // 
            // groupWeekly
            // 
            groupWeekly.Controls.Add(labelWeekSteps);
            groupWeekly.Controls.Add(labelWeekTrainings);
            groupWeekly.Location = new Point(446, 13);
            groupWeekly.Margin = new Padding(3, 4, 3, 4);
            groupWeekly.Name = "groupWeekly";
            groupWeekly.Padding = new Padding(3, 4, 3, 4);
            groupWeekly.Size = new Size(423, 107);
            groupWeekly.TabIndex = 1;
            groupWeekly.TabStop = false;
            groupWeekly.Text = "Podsumowanie tygodnia";
            // 
            // labelWeekSteps
            // 
            labelWeekSteps.AutoSize = true;
            labelWeekSteps.Location = new Point(11, 33);
            labelWeekSteps.Name = "labelWeekSteps";
            labelWeekSteps.Size = new Size(0, 20);
            labelWeekSteps.TabIndex = 0;
            // 
            // labelWeekTrainings
            // 
            labelWeekTrainings.AutoSize = true;
            labelWeekTrainings.Location = new Point(11, 67);
            labelWeekTrainings.Name = "labelWeekTrainings";
            labelWeekTrainings.Size = new Size(0, 20);
            labelWeekTrainings.TabIndex = 1;
            // 
            // buttonAddTraining
            // 
            buttonAddTraining.Location = new Point(11, 133);
            buttonAddTraining.Margin = new Padding(3, 4, 3, 4);
            buttonAddTraining.Name = "buttonAddTraining";
            buttonAddTraining.Size = new Size(137, 40);
            buttonAddTraining.TabIndex = 2;
            buttonAddTraining.Text = "Dodaj trening";
            buttonAddTraining.UseVisualStyleBackColor = true;
            buttonAddTraining.Click += buttonAddTraining_Click;
            // 
            // buttonHistory
            // 
            buttonHistory.Location = new Point(160, 133);
            buttonHistory.Margin = new Padding(3, 4, 3, 4);
            buttonHistory.Name = "buttonHistory";
            buttonHistory.Size = new Size(137, 40);
            buttonHistory.TabIndex = 3;
            buttonHistory.Text = "Historia";
            buttonHistory.UseVisualStyleBackColor = true;
            buttonHistory.Click += buttonHistory_Click;
            // 
            // buttonStats
            // 
            buttonStats.Location = new Point(309, 133);
            buttonStats.Margin = new Padding(3, 4, 3, 4);
            buttonStats.Name = "buttonStats";
            buttonStats.Size = new Size(137, 40);
            buttonStats.TabIndex = 4;
            buttonStats.Text = "Statystyki";
            buttonStats.UseVisualStyleBackColor = true;
            buttonStats.Click += buttonStats_Click;
            // 
            // buttonGoals
            // 
            buttonGoals.Location = new Point(457, 133);
            buttonGoals.Margin = new Padding(3, 4, 3, 4);
            buttonGoals.Name = "buttonGoals";
            buttonGoals.Size = new Size(137, 40);
            buttonGoals.TabIndex = 6;
            buttonGoals.Text = "Cele";
            buttonGoals.UseVisualStyleBackColor = true;
            buttonGoals.Click += buttonGoals_Click;
            // 
            // button1
            // 
            button1.Location = new Point(678, 151);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "jabko";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 200);
            Controls.Add(button1);
            Controls.Add(groupDaily);
            Controls.Add(groupWeekly);
            Controls.Add(buttonAddTraining);
            Controls.Add(buttonHistory);
            Controls.Add(buttonStats);
            Controls.Add(buttonGoals);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trening Tracker";
            groupDaily.ResumeLayout(false);
            groupDaily.PerformLayout();
            groupWeekly.ResumeLayout(false);
            groupWeekly.PerformLayout();
            ResumeLayout(false);
        }
        private Button button1;
    }
}
