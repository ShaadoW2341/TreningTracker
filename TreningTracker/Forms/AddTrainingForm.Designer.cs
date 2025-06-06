using System.ComponentModel;
using System.Windows.Forms;

namespace TreningTracker.Forms
{
    partial class AddTrainingForm
    {
        private IContainer components = null;
        private Label labelDate;
        private Label labelType;
        private Label labelDistance;
        private Label labelDuration;
        private Label labelCalories;
        private Label labelSteps;
        private DateTimePicker dateTimePickerDate;
        private ComboBox comboActivityType;
        private NumericUpDown numericDistance;
        private NumericUpDown numericHours;
        private NumericUpDown numericMinutes;
        private NumericUpDown numericSeconds;
        private Label labelHours;
        private Label labelMinutes;
        private Label labelSeconds;
        private Button buttonStopwatch;
        private NumericUpDown numericCalories;
        private NumericUpDown numericSteps;
        private Button buttonSave;
        private Button buttonCancel;

        private void InitializeComponent()
        {
            labelDate = new Label();
            labelType = new Label();
            labelDistance = new Label();
            labelDuration = new Label();
            labelCalories = new Label();
            labelSteps = new Label();
            dateTimePickerDate = new DateTimePicker();
            comboActivityType = new ComboBox();
            numericDistance = new NumericUpDown();
            numericHours = new NumericUpDown();
            numericMinutes = new NumericUpDown();
            numericSeconds = new NumericUpDown();
            labelHours = new Label();
            labelMinutes = new Label();
            labelSeconds = new Label();
            buttonStopwatch = new Button();
            numericCalories = new NumericUpDown();
            numericSteps = new NumericUpDown();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((ISupportInitialize)numericDistance).BeginInit();
            ((ISupportInitialize)numericHours).BeginInit();
            ((ISupportInitialize)numericMinutes).BeginInit();
            ((ISupportInitialize)numericSeconds).BeginInit();
            ((ISupportInitialize)numericCalories).BeginInit();
            ((ISupportInitialize)numericSteps).BeginInit();
            SuspendLayout();
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(10, 20);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(44, 20);
            labelDate.TabIndex = 0;
            labelDate.Text = "Data:";
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(10, 60);
            labelType.Name = "labelType";
            labelType.Size = new Size(111, 20);
            labelType.TabIndex = 2;
            labelType.Text = "Typ aktywności:";
            // 
            // labelDistance
            // 
            labelDistance.AutoSize = true;
            labelDistance.Location = new Point(10, 100);
            labelDistance.Name = "labelDistance";
            labelDistance.Size = new Size(97, 20);
            labelDistance.TabIndex = 4;
            labelDistance.Text = "Dystans (km):";
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.Location = new Point(10, 140);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(95, 20);
            labelDuration.TabIndex = 6;
            labelDuration.Text = "Czas trwania:";
            // 
            // labelCalories
            // 
            labelCalories.AutoSize = true;
            labelCalories.Location = new Point(10, 210);
            labelCalories.Name = "labelCalories";
            labelCalories.Size = new Size(59, 20);
            labelCalories.TabIndex = 14;
            labelCalories.Text = "Kalorie:";
            // 
            // labelSteps
            // 
            labelSteps.AutoSize = true;
            labelSteps.Location = new Point(10, 250);
            labelSteps.Name = "labelSteps";
            labelSteps.Size = new Size(46, 20);
            labelSteps.TabIndex = 16;
            labelSteps.Text = "Kroki:";
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Format = DateTimePickerFormat.Short;
            dateTimePickerDate.Location = new Point(150, 18);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(120, 27);
            dateTimePickerDate.TabIndex = 1;
            dateTimePickerDate.Value = new DateTime(2025, 6, 6, 15, 37, 55, 0);
            // 
            // comboActivityType
            // 
            comboActivityType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboActivityType.Location = new Point(150, 58);
            comboActivityType.Name = "comboActivityType";
            comboActivityType.Size = new Size(180, 28);
            comboActivityType.TabIndex = 3;
            comboActivityType.SelectedIndexChanged += comboActivityType_SelectedIndexChanged;
            // 
            // numericDistance
            // 
            numericDistance.DecimalPlaces = 2;
            numericDistance.Location = new Point(150, 98);
            numericDistance.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericDistance.Name = "numericDistance";
            numericDistance.Size = new Size(80, 27);
            numericDistance.TabIndex = 5;
            // 
            // numericHours
            // 
            numericHours.Location = new Point(150, 138);
            numericHours.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            numericHours.Name = "numericHours";
            numericHours.Size = new Size(50, 27);
            numericHours.TabIndex = 7;
            // 
            // numericMinutes
            // 
            numericMinutes.Location = new Point(230, 138);
            numericMinutes.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            numericMinutes.Name = "numericMinutes";
            numericMinutes.Size = new Size(50, 27);
            numericMinutes.TabIndex = 9;
            // 
            // numericSeconds
            // 
            numericSeconds.Location = new Point(320, 138);
            numericSeconds.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            numericSeconds.Name = "numericSeconds";
            numericSeconds.Size = new Size(50, 27);
            numericSeconds.TabIndex = 11;
            numericSeconds.Visible = false;
            // 
            // labelHours
            // 
            labelHours.AutoSize = true;
            labelHours.Location = new Point(205, 140);
            labelHours.Name = "labelHours";
            labelHours.Size = new Size(17, 20);
            labelHours.TabIndex = 8;
            labelHours.Text = "h";
            // 
            // labelMinutes
            // 
            labelMinutes.AutoSize = true;
            labelMinutes.Location = new Point(285, 140);
            labelMinutes.Name = "labelMinutes";
            labelMinutes.Size = new Size(34, 20);
            labelMinutes.TabIndex = 10;
            labelMinutes.Text = "min";
            // 
            // labelSeconds
            // 
            labelSeconds.AutoSize = true;
            labelSeconds.Location = new Point(375, 140);
            labelSeconds.Name = "labelSeconds";
            labelSeconds.Size = new Size(15, 20);
            labelSeconds.TabIndex = 12;
            labelSeconds.Text = "s";
            labelSeconds.Visible = false;
            // 
            // buttonStopwatch
            // 
            buttonStopwatch.Location = new Point(150, 170);
            buttonStopwatch.Name = "buttonStopwatch";
            buttonStopwatch.Size = new Size(80, 25);
            buttonStopwatch.TabIndex = 13;
            buttonStopwatch.Text = "Stoper";
            buttonStopwatch.UseVisualStyleBackColor = true;
            buttonStopwatch.Click += buttonStopwatch_Click;
            // 
            // numericCalories
            // 
            numericCalories.Location = new Point(150, 208);
            numericCalories.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericCalories.Name = "numericCalories";
            numericCalories.Size = new Size(80, 27);
            numericCalories.TabIndex = 15;
            // 
            // numericSteps
            // 
            numericSteps.Location = new Point(150, 248);
            numericSteps.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericSteps.Name = "numericSteps";
            numericSteps.Size = new Size(100, 27);
            numericSteps.TabIndex = 17;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(220, 290);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(80, 30);
            buttonSave.TabIndex = 18;
            buttonSave.Text = "Zapisz";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(310, 290);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(80, 30);
            buttonCancel.TabIndex = 19;
            buttonCancel.Text = "Anuluj";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // AddTrainingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 340);
            Controls.Add(labelDate);
            Controls.Add(dateTimePickerDate);
            Controls.Add(labelType);
            Controls.Add(comboActivityType);
            Controls.Add(labelDistance);
            Controls.Add(numericDistance);
            Controls.Add(labelDuration);
            Controls.Add(numericHours);
            Controls.Add(labelHours);
            Controls.Add(numericMinutes);
            Controls.Add(labelMinutes);
            Controls.Add(numericSeconds);
            Controls.Add(labelSeconds);
            Controls.Add(buttonStopwatch);
            Controls.Add(labelCalories);
            Controls.Add(numericCalories);
            Controls.Add(labelSteps);
            Controls.Add(numericSteps);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            Name = "AddTrainingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dodaj trening";
            ((ISupportInitialize)numericDistance).EndInit();
            ((ISupportInitialize)numericHours).EndInit();
            ((ISupportInitialize)numericMinutes).EndInit();
            ((ISupportInitialize)numericSeconds).EndInit();
            ((ISupportInitialize)numericCalories).EndInit();
            ((ISupportInitialize)numericSteps).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
