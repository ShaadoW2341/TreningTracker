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
        private Button buttonCharts;
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
            buttonCharts = new Button();
            buttonGoals = new Button();
            groupDaily.SuspendLayout();
            groupWeekly.SuspendLayout();
            SuspendLayout();
            // 
            // groupDaily
            // 
            groupDaily.Controls.Add(labelDaySteps);
            groupDaily.Controls.Add(labelDayTrainings);
            groupDaily.Location = new Point(10, 10);
            groupDaily.Name = "groupDaily";
            groupDaily.Size = new Size(370, 80);
            groupDaily.TabIndex = 0;
            groupDaily.TabStop = false;
            groupDaily.Text = "Podsumowanie dnia";
            // 
            // labelDaySteps
            // 
            labelDaySteps.AutoSize = true;
            labelDaySteps.Location = new Point(10, 25);
            labelDaySteps.Name = "labelDaySteps";
            labelDaySteps.Size = new Size(0, 15);
            labelDaySteps.TabIndex = 0;
            // 
            // labelDayTrainings
            // 
            labelDayTrainings.AutoSize = true;
            labelDayTrainings.Location = new Point(10, 50);
            labelDayTrainings.Name = "labelDayTrainings";
            labelDayTrainings.Size = new Size(0, 15);
            labelDayTrainings.TabIndex = 1;
            // 
            // groupWeekly
            // 
            groupWeekly.Controls.Add(labelWeekSteps);
            groupWeekly.Controls.Add(labelWeekTrainings);
            groupWeekly.Location = new Point(390, 10);
            groupWeekly.Name = "groupWeekly";
            groupWeekly.Size = new Size(370, 80);
            groupWeekly.TabIndex = 1;
            groupWeekly.TabStop = false;
            groupWeekly.Text = "Podsumowanie tygodnia";
            // 
            // labelWeekSteps
            // 
            labelWeekSteps.AutoSize = true;
            labelWeekSteps.Location = new Point(10, 25);
            labelWeekSteps.Name = "labelWeekSteps";
            labelWeekSteps.Size = new Size(0, 15);
            labelWeekSteps.TabIndex = 0;
            // 
            // labelWeekTrainings
            // 
            labelWeekTrainings.AutoSize = true;
            labelWeekTrainings.Location = new Point(10, 50);
            labelWeekTrainings.Name = "labelWeekTrainings";
            labelWeekTrainings.Size = new Size(0, 15);
            labelWeekTrainings.TabIndex = 1;
            // 
            // buttonAddTraining
            // 
            buttonAddTraining.Location = new Point(10, 100);
            buttonAddTraining.Name = "buttonAddTraining";
            buttonAddTraining.Size = new Size(120, 30);
            buttonAddTraining.TabIndex = 2;
            buttonAddTraining.Text = "Dodaj trening";
            buttonAddTraining.UseVisualStyleBackColor = true;
            buttonAddTraining.Click += buttonAddTraining_Click;
            // 
            // buttonHistory
            // 
            buttonHistory.Location = new Point(140, 100);
            buttonHistory.Name = "buttonHistory";
            buttonHistory.Size = new Size(120, 30);
            buttonHistory.TabIndex = 3;
            buttonHistory.Text = "Historia";
            buttonHistory.UseVisualStyleBackColor = true;
            buttonHistory.Click += buttonHistory_Click;
            // 
            // buttonStats
            // 
            buttonStats.Location = new Point(270, 100);
            buttonStats.Name = "buttonStats";
            buttonStats.Size = new Size(120, 30);
            buttonStats.TabIndex = 4;
            buttonStats.Text = "Statystyki";
            buttonStats.UseVisualStyleBackColor = true;
            buttonStats.Click += buttonStats_Click;
            // 
            // buttonCharts
            // 
            buttonCharts.Location = new Point(400, 100);
            buttonCharts.Name = "buttonCharts";
            buttonCharts.Size = new Size(120, 30);
            buttonCharts.TabIndex = 5;
            buttonCharts.Text = "Wykresy";
            buttonCharts.UseVisualStyleBackColor = true;
            buttonCharts.Click += buttonCharts_Click;
            // 
            // buttonGoals
            // 
            buttonGoals.Location = new Point(530, 100);
            buttonGoals.Name = "buttonGoals";
            buttonGoals.Size = new Size(120, 30);
            buttonGoals.TabIndex = 6;
            buttonGoals.Text = "Cele";
            buttonGoals.UseVisualStyleBackColor = true;
            buttonGoals.Click += buttonGoals_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 150);
            Controls.Add(groupDaily);
            Controls.Add(groupWeekly);
            Controls.Add(buttonAddTraining);
            Controls.Add(buttonHistory);
            Controls.Add(buttonStats);
            Controls.Add(buttonCharts);
            Controls.Add(buttonGoals);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trening Tracker";
            groupDaily.ResumeLayout(false);
            groupDaily.PerformLayout();
            groupWeekly.ResumeLayout(false);
            groupWeekly.PerformLayout();
            ResumeLayout(false);
        }
    }
}
