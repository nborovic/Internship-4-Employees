﻿namespace Employees.Presentation.Forms
{
    partial class CreateProject
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
            this.projectName = new System.Windows.Forms.TextBox();
            this.projectStart = new System.Windows.Forms.DateTimePicker();
            this.projectDeadline = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.weeklyWorkHours = new System.Windows.Forms.MaskedTextBox();
            this.addedEmployeesListBox = new System.Windows.Forms.ListBox();
            this.employeesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // projectName
            // 
            this.projectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectName.Location = new System.Drawing.Point(93, 38);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(228, 22);
            this.projectName.TabIndex = 0;
            // 
            // projectStart
            // 
            this.projectStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectStart.Location = new System.Drawing.Point(93, 83);
            this.projectStart.Name = "projectStart";
            this.projectStart.Size = new System.Drawing.Size(228, 22);
            this.projectStart.TabIndex = 1;
            // 
            // projectDeadline
            // 
            this.projectDeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectDeadline.Location = new System.Drawing.Point(93, 130);
            this.projectDeadline.Name = "projectDeadline";
            this.projectDeadline.Size = new System.Drawing.Size(228, 22);
            this.projectDeadline.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(90, 311);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "List of added employees";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(255, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Weekly work hours";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "List of all employees";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(142, 445);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(144, 38);
            this.saveButton.TabIndex = 24;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.Save);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(312, 330);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(22, 100);
            this.removeButton.TabIndex = 23;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.Remove);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(271, 248);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(95, 23);
            this.addButton.TabIndex = 22;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.Add);
            // 
            // weeklyWorkHours
            // 
            this.weeklyWorkHours.Location = new System.Drawing.Point(271, 222);
            this.weeklyWorkHours.Mask = "00";
            this.weeklyWorkHours.Name = "weeklyWorkHours";
            this.weeklyWorkHours.Size = new System.Drawing.Size(95, 20);
            this.weeklyWorkHours.TabIndex = 21;
            this.weeklyWorkHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // addedEmployeesListBox
            // 
            this.addedEmployeesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addedEmployeesListBox.FormattingEnabled = true;
            this.addedEmployeesListBox.ItemHeight = 16;
            this.addedEmployeesListBox.Location = new System.Drawing.Point(94, 330);
            this.addedEmployeesListBox.Name = "addedEmployeesListBox";
            this.addedEmployeesListBox.Size = new System.Drawing.Size(212, 100);
            this.addedEmployeesListBox.TabIndex = 20;
            // 
            // employeesListBox
            // 
            this.employeesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeesListBox.FormattingEnabled = true;
            this.employeesListBox.ItemHeight = 16;
            this.employeesListBox.Location = new System.Drawing.Point(36, 203);
            this.employeesListBox.Name = "employeesListBox";
            this.employeesListBox.Size = new System.Drawing.Size(212, 100);
            this.employeesListBox.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "Start";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(91, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Deadline";
            // 
            // CreateProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 500);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.weeklyWorkHours);
            this.Controls.Add(this.addedEmployeesListBox);
            this.Controls.Add(this.employeesListBox);
            this.Controls.Add(this.projectDeadline);
            this.Controls.Add(this.projectStart);
            this.Controls.Add(this.projectName);
            this.Name = "CreateProject";
            this.Text = "CreateProject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox projectName;
        private System.Windows.Forms.DateTimePicker projectStart;
        private System.Windows.Forms.DateTimePicker projectDeadline;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.MaskedTextBox weeklyWorkHours;
        private System.Windows.Forms.ListBox addedEmployeesListBox;
        private System.Windows.Forms.ListBox employeesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}