namespace Employees.Presentation.Forms
{
    partial class EmployeeDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.employeeToStringTextBox = new System.Windows.Forms.MaskedTextBox();
            this.employeeBirthdayTextBox = new System.Windows.Forms.MaskedTextBox();
            this.oibTextBox = new System.Windows.Forms.MaskedTextBox();
            this.weeklyWorkHoursTextBox = new System.Windows.Forms.MaskedTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.weeklyWorkHoursColoredIndicator = new System.Windows.Forms.ListBox();
            this.employeeProjectsListBox = new System.Windows.Forms.ListBox();
            this.statesComboBox = new System.Windows.Forms.ComboBox();
            this.editButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // employeeToStringTextBox
            // 
            this.employeeToStringTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.employeeToStringTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.employeeToStringTextBox.Location = new System.Drawing.Point(40, 12);
            this.employeeToStringTextBox.Name = "employeeToStringTextBox";
            this.employeeToStringTextBox.ReadOnly = true;
            this.employeeToStringTextBox.Size = new System.Drawing.Size(382, 24);
            this.employeeToStringTextBox.TabIndex = 0;
            this.employeeToStringTextBox.Text = "placeholder";
            this.employeeToStringTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // employeeBirthdayTextBox
            // 
            this.employeeBirthdayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.employeeBirthdayTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.employeeBirthdayTextBox.Location = new System.Drawing.Point(40, 79);
            this.employeeBirthdayTextBox.Name = "employeeBirthdayTextBox";
            this.employeeBirthdayTextBox.ReadOnly = true;
            this.employeeBirthdayTextBox.Size = new System.Drawing.Size(298, 19);
            this.employeeBirthdayTextBox.TabIndex = 1;
            this.employeeBirthdayTextBox.Text = "Birthday: ";
            // 
            // oibTextBox
            // 
            this.oibTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.oibTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.oibTextBox.Location = new System.Drawing.Point(40, 54);
            this.oibTextBox.Name = "oibTextBox";
            this.oibTextBox.ReadOnly = true;
            this.oibTextBox.Size = new System.Drawing.Size(298, 19);
            this.oibTextBox.TabIndex = 2;
            this.oibTextBox.Text = "OIB: ";
            // 
            // weeklyWorkHoursTextBox
            // 
            this.weeklyWorkHoursTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.weeklyWorkHoursTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.weeklyWorkHoursTextBox.Location = new System.Drawing.Point(40, 104);
            this.weeklyWorkHoursTextBox.Name = "weeklyWorkHoursTextBox";
            this.weeklyWorkHoursTextBox.ReadOnly = true;
            this.weeklyWorkHoursTextBox.Size = new System.Drawing.Size(298, 19);
            this.weeklyWorkHoursTextBox.TabIndex = 3;
            this.weeklyWorkHoursTextBox.Text = "Weekly work hours: ";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Lime;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(166, 150);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(227, 0);
            this.listBox1.TabIndex = 4;
            // 
            // weeklyWorkHoursColoredIndicator
            // 
            this.weeklyWorkHoursColoredIndicator.FormattingEnabled = true;
            this.weeklyWorkHoursColoredIndicator.Location = new System.Drawing.Point(404, 106);
            this.weeklyWorkHoursColoredIndicator.Name = "weeklyWorkHoursColoredIndicator";
            this.weeklyWorkHoursColoredIndicator.Size = new System.Drawing.Size(18, 17);
            this.weeklyWorkHoursColoredIndicator.TabIndex = 5;
            // 
            // employeeProjectsListBox
            // 
            this.employeeProjectsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.employeeProjectsListBox.FormattingEnabled = true;
            this.employeeProjectsListBox.ItemHeight = 20;
            this.employeeProjectsListBox.Location = new System.Drawing.Point(40, 129);
            this.employeeProjectsListBox.Name = "employeeProjectsListBox";
            this.employeeProjectsListBox.Size = new System.Drawing.Size(382, 184);
            this.employeeProjectsListBox.Sorted = true;
            this.employeeProjectsListBox.TabIndex = 6;
            // 
            // statesComboBox
            // 
            this.statesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statesComboBox.FormattingEnabled = true;
            this.statesComboBox.Location = new System.Drawing.Point(151, 319);
            this.statesComboBox.Name = "statesComboBox";
            this.statesComboBox.Size = new System.Drawing.Size(178, 21);
            this.statesComboBox.TabIndex = 7;
            this.statesComboBox.SelectionChangeCommitted += new System.EventHandler(this.StatesComboBoxChanged);
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Location = new System.Drawing.Point(193, 357);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(99, 32);
            this.editButton.TabIndex = 8;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.Edit);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(12, 357);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(57, 32);
            this.backButton.TabIndex = 21;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.Back);
            // 
            // EmployeeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 409);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.statesComboBox);
            this.Controls.Add(this.employeeProjectsListBox);
            this.Controls.Add(this.weeklyWorkHoursColoredIndicator);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.weeklyWorkHoursTextBox);
            this.Controls.Add(this.oibTextBox);
            this.Controls.Add(this.employeeBirthdayTextBox);
            this.Controls.Add(this.employeeToStringTextBox);
            this.Name = "EmployeeDetails";
            this.Text = "EmployeeDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox employeeToStringTextBox;
        private System.Windows.Forms.MaskedTextBox employeeBirthdayTextBox;
        private System.Windows.Forms.MaskedTextBox oibTextBox;
        private System.Windows.Forms.MaskedTextBox weeklyWorkHoursTextBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox weeklyWorkHoursColoredIndicator;
        private System.Windows.Forms.ListBox employeeProjectsListBox;
        private System.Windows.Forms.ComboBox statesComboBox;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button backButton;
    }
}