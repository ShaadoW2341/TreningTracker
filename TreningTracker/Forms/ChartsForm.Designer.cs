using System.ComponentModel;
using System.Windows.Forms;

namespace TreningTracker.Forms
{
    partial class ChartsForm
    {
        private IContainer components = null;

        private PictureBox pictureWeekly;
        private PictureBox pictureMonthly;

        private void InitializeComponent()
        {
            this.pictureWeekly = new PictureBox();
            this.pictureMonthly = new PictureBox();
            ((ISupportInitialize)(this.pictureWeekly)).BeginInit();
            ((ISupportInitialize)(this.pictureMonthly)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureWeekly
            // 
            this.pictureWeekly.BackColor = System.Drawing.Color.White;
            this.pictureWeekly.Location = new System.Drawing.Point(10, 10);
            this.pictureWeekly.Name = "pictureWeekly";
            this.pictureWeekly.Size = new System.Drawing.Size(760, 240);
            this.pictureWeekly.TabIndex = 0;
            this.pictureWeekly.TabStop = false;
            this.pictureWeekly.Paint += new PaintEventHandler(this.pictureWeekly_Paint);
            // 
            // pictureMonthly
            // 
            this.pictureMonthly.BackColor = System.Drawing.Color.White;
            this.pictureMonthly.Location = new System.Drawing.Point(10, 270);
            this.pictureMonthly.Name = "pictureMonthly";
            this.pictureMonthly.Size = new System.Drawing.Size(760, 240);
            this.pictureMonthly.TabIndex = 1;
            this.pictureMonthly.TabStop = false;
            this.pictureMonthly.Paint += new PaintEventHandler(this.pictureMonthly_Paint);
            // 
            // ChartsForm
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.pictureWeekly);
            this.Controls.Add(this.pictureMonthly);
            this.Name = "ChartsForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Wykresy";
            ((ISupportInitialize)(this.pictureWeekly)).EndInit();
            ((ISupportInitialize)(this.pictureMonthly)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
