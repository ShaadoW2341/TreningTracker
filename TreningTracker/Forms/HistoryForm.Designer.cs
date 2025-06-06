using System.ComponentModel;
using System.Windows.Forms;

namespace TreningTracker.Forms
{
    partial class HistoryForm
    {
        private IContainer components = null;
        private CheckBox checkBoxDateFilter;
        private DateTimePicker dateTimePickerFilter;
        private Label labelTypeFilter;
        private ComboBox comboTypeFilter;
        private DataGridView dataGridView;
        private Button buttonDelete;

        private void InitializeComponent()
        {
            checkBoxDateFilter = new CheckBox();
            dateTimePickerFilter = new DateTimePicker();
            labelTypeFilter = new Label();
            comboTypeFilter = new ComboBox();
            dataGridView = new DataGridView();
            buttonDelete = new Button();
            ((ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // checkBoxDateFilter
            // 
            checkBoxDateFilter.AutoSize = true;
            checkBoxDateFilter.Location = new Point(10, 20);
            checkBoxDateFilter.Name = "checkBoxDateFilter";
            checkBoxDateFilter.Size = new Size(104, 19);
            checkBoxDateFilter.TabIndex = 0;
            checkBoxDateFilter.Text = "Filtruj po dacie";
            checkBoxDateFilter.UseVisualStyleBackColor = true;
            checkBoxDateFilter.CheckedChanged += checkBoxDateFilter_CheckedChanged;
            // 
            // dateTimePickerFilter
            // 
            dateTimePickerFilter.Format = DateTimePickerFormat.Short;
            dateTimePickerFilter.Location = new Point(180, 18);
            dateTimePickerFilter.Name = "dateTimePickerFilter";
            dateTimePickerFilter.Size = new Size(120, 23);
            dateTimePickerFilter.TabIndex = 1;
            dateTimePickerFilter.ValueChanged += filterControlChanged;
            // 
            // labelTypeFilter
            // 
            labelTypeFilter.AutoSize = true;
            labelTypeFilter.Location = new Point(400, 22);
            labelTypeFilter.Name = "labelTypeFilter";
            labelTypeFilter.Size = new Size(90, 15);
            labelTypeFilter.TabIndex = 2;
            labelTypeFilter.Text = "Typ aktywności:";
            // 
            // comboTypeFilter
            // 
            comboTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTypeFilter.Location = new Point(500, 18);
            comboTypeFilter.Name = "comboTypeFilter";
            comboTypeFilter.Size = new Size(150, 23);
            comboTypeFilter.TabIndex = 3;
            comboTypeFilter.SelectedIndexChanged += filterControlChanged;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Location = new Point(10, 60);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.Size = new Size(760, 380);
            dataGridView.TabIndex = 4;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(10, 450);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(100, 30);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "Usuń";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 490);
            Controls.Add(checkBoxDateFilter);
            Controls.Add(dateTimePickerFilter);
            Controls.Add(labelTypeFilter);
            Controls.Add(comboTypeFilter);
            Controls.Add(dataGridView);
            Controls.Add(buttonDelete);
            Name = "HistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historia aktywności";
            ((ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
