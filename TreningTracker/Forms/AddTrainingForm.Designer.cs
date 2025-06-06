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
            this.components = new Container();
            this.labelDate = new Label();
            this.labelType = new Label();
            this.labelDistance = new Label();
            this.labelDuration = new Label();
            this.labelCalories = new Label();
            this.labelSteps = new Label();
            this.dateTimePickerDate = new DateTimePicker();
            this.comboActivityType = new ComboBox();
            this.numericDistance = new NumericUpDown();
            this.numericHours = new NumericUpDown();
            this.numericMinutes = new NumericUpDown();
            this.numericSeconds = new NumericUpDown();
            this.labelHours = new Label();
            this.labelMinutes = new Label();
            this.labelSeconds = new Label();
            this.buttonStopwatch = new Button();
            this.numericCalories = new NumericUpDown();
            this.numericSteps = new NumericUpDown();
            this.buttonSave = new Button();
            this.buttonCancel = new Button();
            ((ISupportInitialize)(this.numericDistance)).BeginInit();
            ((ISupportInitialize)(this.numericHours)).BeginInit();
            ((ISupportInitialize)(this.numericMinutes)).BeginInit();
            ((ISupportInitialize)(this.numericSeconds)).BeginInit();
            ((ISupportInitialize)(this.numericCalories)).BeginInit();
            ((ISupportInitialize)(this.numericSteps)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(10, 20);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(33, 15);
            this.labelDate.TabIndex = 0;
            this.labelDate.Text = "Data:";
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Format = DateTimePickerFormat.Short;
            this.dateTimePickerDate.Location = new System.Drawing.Point(150, 18);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerDate.TabIndex = 1;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(10, 60);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(84, 15);
            this.labelType.TabIndex = 2;
            this.labelType.Text = "Typ aktywności:";
            // 
            // comboActivityType
            // 
            this.comboActivityType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboActivityType.Location = new System.Drawing.Point(150, 58);
            this.comboActivityType.Name = "comboActivityType";
            this.comboActivityType.Size = new System.Drawing.Size(180, 23);
            this.comboActivityType.TabIndex = 3;
            this.comboActivityType.SelectedIndexChanged += new System.EventHandler(this.comboActivityType_SelectedIndexChanged);
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(10, 100);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(77, 15);
            this.labelDistance.TabIndex = 4;
            this.labelDistance.Text = "Dystans (km):";
            // 
            // numericDistance
            // 
            this.numericDistance.DecimalPlaces = 2;
            this.numericDistance.Location = new System.Drawing.Point(150, 98);
            this.numericDistance.Maximum = new decimal(new int[] {
                1000,
                0,
                0,
                0});
            this.numericDistance.Name = "numericDistance";
            this.numericDistance.Size = new System.Drawing.Size(80, 23);
            this.numericDistance.TabIndex = 5;
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(10, 140);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(80, 15);
            this.labelDuration.TabIndex = 6;
            this.labelDuration.Text = "Czas trwania:";
            // 
            // numericHours
            // 
            this.numericHours.Location = new System.Drawing.Point(150, 138);
            this.numericHours.Maximum = new decimal(new int[] {
                23,
                0,
                0,
                0});
            this.numericHours.Name = "numericHours";
            this.numericHours.Size = new System.Drawing.Size(50, 23);
            this.numericHours.TabIndex = 7;
            // 
            // labelHours
            // 
            this.labelHours.AutoSize = true;
            this.labelHours.Location = new System.Drawing.Point(205, 140);
            this.labelHours.Name = "labelHours";
            this.labelHours.Size = new System.Drawing.Size(15, 15);
            this.labelHours.TabIndex = 8;
            this.labelHours.Text = "h";
            // 
            // numericMinutes
            // 
            this.numericMinutes.Location = new System.Drawing.Point(230, 138);
            this.numericMinutes.Maximum = new decimal(new int[] {
                59,
                0,
                0,
                0});
            this.numericMinutes.Name = "numericMinutes";
            this.numericMinutes.Size = new System.Drawing.Size(50, 23);
            this.numericMinutes.TabIndex = 9;
            // 
            // labelMinutes
            // 
            this.labelMinutes.AutoSize = true;
            this.labelMinutes.Location = new System.Drawing.Point(285, 140);
            this.labelMinutes.Name = "labelMinutes";
            this.labelMinutes.Size = new System.Drawing.Size(25, 15);
            this.labelMinutes.TabIndex = 10;
            this.labelMinutes.Text = "min";
            // 
            // numericSeconds
            // 
            this.numericSeconds.Location = new System.Drawing.Point(320, 138);
            this.numericSeconds.Maximum = new decimal(new int[] {
                59,
                0,
                0,
                0});
            this.numericSeconds.Name = "numericSeconds";
            this.numericSeconds.Size = new System.Drawing.Size(50, 23);
            this.numericSeconds.TabIndex = 11;
            this.numericSeconds.Visible = false;
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.Location = new System.Drawing.Point(375, 140);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(15, 15);
            this.labelSeconds.TabIndex = 12;
            this.labelSeconds.Text = "s";
            this.labelSeconds.Visible = false;
            // 
            // buttonStopwatch
            // 
            this.buttonStopwatch.Location = new System.Drawing.Point(150, 170);
            this.buttonStopwatch.Name = "buttonStopwatch";
            this.buttonStopwatch.Size = new System.Drawing.Size(80, 25);
            this.buttonStopwatch.TabIndex = 13;
            this.buttonStopwatch.Text = "Stoper";
            this.buttonStopwatch.UseVisualStyleBackColor = true;
            this.buttonStopwatch.Click += new System.EventHandler(this.buttonStopwatch_Click);
            // 
            // labelCalories
            // 
            this.labelCalories.AutoSize = true;
            this.labelCalories.Location = new System.Drawing.Point(10, 210);
            this.labelCalories.Name = "labelCalories";
            this.labelCalories.Size = new System.Drawing.Size(50, 15);
            this.labelCalories.TabIndex = 14;
            this.labelCalories.Text = "Kalorie:";
            // 
            // numericCalories
            // 
            this.numericCalories.Location = new System.Drawing.Point(150, 208);
            this.numericCalories.Maximum = new decimal(new int[] {
                10000,
                0,
                0,
                0});
            this.numericCalories.Name = "numericCalories";
            this.numericCalories.Size = new System.Drawing.Size(80, 23);
            this.numericCalories.TabIndex = 15;
            // 
            // labelSteps
            // 
            this.labelSteps.AutoSize = true;
            this.labelSteps.Location = new System.Drawing.Point(10, 250);
            this.labelSteps.Name = "labelSteps";
            this.labelSteps.Size = new System.Drawing.Size(41, 15);
            this.labelSteps.TabIndex = 16;
            this.labelSteps.Text = "Kroki:";
            // 
            // numericSteps
            // 
            this.numericSteps.Location = new System.Drawing.Point(150, 248);
            this.numericSteps.Maximum = new decimal(new int[] {
                100000,
                0,
                0,
                0});
            this.numericSteps.Name = "numericSteps";
            this.numericSteps.Size = new System.Drawing.Size(100, 23);
            this.numericSteps.TabIndex = 17;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(220, 290);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(80, 30);
            this.buttonSave.TabIndex = 18;
            this.buttonSave.Text = "Zapisz";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(310, 290);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 30);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AddTrainingForm
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 340);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.comboActivityType);
            this.Controls.Add(this.labelDistance);
            this.Controls.Add(this.numericDistance);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.numericHours);
            this.Controls.Add(this.labelHours);
            this.Controls.Add(this.numericMinutes);
            this.Controls.Add(this.labelMinutes);
            this.Controls.Add(this.numericSeconds);
            this.Controls.Add(this.labelSeconds);
            this.Controls.Add(this.buttonStopwatch);
            this.Controls.Add(this.labelCalories);
            this.Controls.Add(this.numericCalories);
            this.Controls.Add(this.labelSteps);
            this.Controls.Add(this.numericSteps);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Name = "AddTrainingForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Dodaj trening";
            ((ISupportInitialize)(this.numericDistance)).EndInit();
            ((ISupportInitialize)(this.numericHours)).EndInit();
            ((ISupportInitialize)(this.numericMinutes)).EndInit();
            ((ISupportInitialize)(this.numericSeconds)).EndInit();
            ((ISupportInitialize)(this.numericCalories)).EndInit();
            ((ISupportInitialize)(this.numericSteps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
