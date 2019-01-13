namespace Employees.Presentation.Forms
{
    partial class ProjectDetails
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
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.projectStartDeadlineTextBox = new System.Windows.Forms.TextBox();
            this.employeesListBox = new System.Windows.Forms.ListBox();
            this.rolesComboBox = new System.Windows.Forms.ComboBox();
            this.editButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projectNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectNameTextBox.Location = new System.Drawing.Point(50, 12);
            this.projectNameTextBox.Multiline = true;
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.ReadOnly = true;
            this.projectNameTextBox.Size = new System.Drawing.Size(401, 39);
            this.projectNameTextBox.TabIndex = 0;
            this.projectNameTextBox.Text = "placeholder";
            this.projectNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // projectStartDeadlineTextBox
            // 
            this.projectStartDeadlineTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projectStartDeadlineTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectStartDeadlineTextBox.Location = new System.Drawing.Point(50, 43);
            this.projectStartDeadlineTextBox.Multiline = true;
            this.projectStartDeadlineTextBox.Name = "projectStartDeadlineTextBox";
            this.projectStartDeadlineTextBox.ReadOnly = true;
            this.projectStartDeadlineTextBox.Size = new System.Drawing.Size(401, 38);
            this.projectStartDeadlineTextBox.TabIndex = 1;
            this.projectStartDeadlineTextBox.Text = "placeholder";
            this.projectStartDeadlineTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // employeesListBox
            // 
            this.employeesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeesListBox.FormattingEnabled = true;
            this.employeesListBox.ItemHeight = 20;
            this.employeesListBox.Location = new System.Drawing.Point(50, 87);
            this.employeesListBox.Name = "employeesListBox";
            this.employeesListBox.Size = new System.Drawing.Size(401, 224);
            this.employeesListBox.TabIndex = 2;
            // 
            // rolesComboBox
            // 
            this.rolesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rolesComboBox.FormattingEnabled = true;
            this.rolesComboBox.Location = new System.Drawing.Point(147, 329);
            this.rolesComboBox.Name = "rolesComboBox";
            this.rolesComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rolesComboBox.Size = new System.Drawing.Size(201, 21);
            this.rolesComboBox.TabIndex = 3;
            this.rolesComboBox.SelectionChangeCommitted += new System.EventHandler(this.RolesComboBoxChanged);
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Location = new System.Drawing.Point(189, 365);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(112, 34);
            this.editButton.TabIndex = 4;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.Edit);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(12, 383);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(57, 32);
            this.backButton.TabIndex = 22;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.Back);
            // 
            // ProjectDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 427);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.rolesComboBox);
            this.Controls.Add(this.employeesListBox);
            this.Controls.Add(this.projectStartDeadlineTextBox);
            this.Controls.Add(this.projectNameTextBox);
            this.Name = "ProjectDetails";
            this.Text = "ProjectDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.TextBox projectStartDeadlineTextBox;
        private System.Windows.Forms.ListBox employeesListBox;
        private System.Windows.Forms.ComboBox rolesComboBox;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button backButton;
    }
}