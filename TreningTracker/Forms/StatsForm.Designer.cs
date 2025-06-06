using System.ComponentModel;
using System.Windows.Forms;

namespace TreningTracker.Forms
{
    partial class StatsForm
    {
        private IContainer components = null;
        private Label labelStats;


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
    }
}
