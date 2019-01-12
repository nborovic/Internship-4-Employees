namespace Employees.Presentation.Forms
{
    partial class CreateEmployee
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
            this.employeeFirstName = new System.Windows.Forms.TextBox();
            this.employeeLastName = new System.Windows.Forms.TextBox();
            this.employeeBirthday = new System.Windows.Forms.DateTimePicker();
            this.employeeRole = new System.Windows.Forms.ComboBox();
            this.projectsListBox = new System.Windows.Forms.ListBox();
            this.addedProjectsListBox = new System.Windows.Forms.ListBox();
            this.weeklyWorkHours = new System.Windows.Forms.MaskedTextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.employeeOib = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // employeeFirstName
            // 
            this.employeeFirstName.Location = new System.Drawing.Point(111, 35);
            this.employeeFirstName.Name = "employeeFirstName";
            this.employeeFirstName.Size = new System.Drawing.Size(184, 20);
            this.employeeFirstName.TabIndex = 0;
            // 
            // employeeLastName
            // 
            this.employeeLastName.Location = new System.Drawing.Point(111, 61);
            this.employeeLastName.Name = "employeeLastName";
            this.employeeLastName.Size = new System.Drawing.Size(184, 20);
            this.employeeLastName.TabIndex = 1;
            // 
            // employeeBirthday
            // 
            this.employeeBirthday.Location = new System.Drawing.Point(111, 113);
            this.employeeBirthday.Name = "employeeBirthday";
            this.employeeBirthday.Size = new System.Drawing.Size(184, 20);
            this.employeeBirthday.TabIndex = 3;
            // 
            // employeeRole
            // 
            this.employeeRole.FormattingEnabled = true;
            this.employeeRole.Location = new System.Drawing.Point(111, 140);
            this.employeeRole.Name = "employeeRole";
            this.employeeRole.Size = new System.Drawing.Size(184, 21);
            this.employeeRole.TabIndex = 4;
            // 
            // projectsListBox
            // 
            this.projectsListBox.FormattingEnabled = true;
            this.projectsListBox.Location = new System.Drawing.Point(67, 179);
            this.projectsListBox.Name = "projectsListBox";
            this.projectsListBox.Size = new System.Drawing.Size(212, 95);
            this.projectsListBox.TabIndex = 5;
            // 
            // addedProjectsListBox
            // 
            this.addedProjectsListBox.FormattingEnabled = true;
            this.addedProjectsListBox.Location = new System.Drawing.Point(67, 280);
            this.addedProjectsListBox.Name = "addedProjectsListBox";
            this.addedProjectsListBox.Size = new System.Drawing.Size(212, 95);
            this.addedProjectsListBox.TabIndex = 6;
            // 
            // weeklyWorkHours
            // 
            this.weeklyWorkHours.Location = new System.Drawing.Point(285, 204);
            this.weeklyWorkHours.Mask = "00";
            this.weeklyWorkHours.Name = "weeklyWorkHours";
            this.weeklyWorkHours.Size = new System.Drawing.Size(95, 20);
            this.weeklyWorkHours.TabIndex = 7;
            this.weeklyWorkHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(285, 230);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(95, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.Add);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(285, 314);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(95, 23);
            this.removeButton.TabIndex = 9;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.Remove);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(159, 393);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.Save);
            // 
            // employeeOib
            // 
            this.employeeOib.Location = new System.Drawing.Point(111, 88);
            this.employeeOib.Mask = "00000000000";
            this.employeeOib.Name = "employeeOib";
            this.employeeOib.Size = new System.Drawing.Size(184, 20);
            this.employeeOib.TabIndex = 11;
            // 
            // CreateEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 513);
            this.Controls.Add(this.employeeOib);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.weeklyWorkHours);
            this.Controls.Add(this.addedProjectsListBox);
            this.Controls.Add(this.projectsListBox);
            this.Controls.Add(this.employeeRole);
            this.Controls.Add(this.employeeBirthday);
            this.Controls.Add(this.employeeLastName);
            this.Controls.Add(this.employeeFirstName);
            this.Name = "CreateEmployee";
            this.Text = "CreateEmployee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox employeeFirstName;
        private System.Windows.Forms.TextBox employeeLastName;
        private System.Windows.Forms.DateTimePicker employeeBirthday;
        private System.Windows.Forms.ComboBox employeeRole;
        private System.Windows.Forms.ListBox projectsListBox;
        private System.Windows.Forms.ListBox addedProjectsListBox;
        private System.Windows.Forms.MaskedTextBox weeklyWorkHours;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.MaskedTextBox employeeOib;
    }
}