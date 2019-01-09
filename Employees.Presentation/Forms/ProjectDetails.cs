using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employees.Data.Enums;
using Employees.Data.Models;
using Employees.Domain.Repositories;

namespace Employees.Presentation.Forms
{
    public partial class ProjectDetails : Form
    {
        private readonly RelationalRepository _relationalRepository;
        private readonly Project _selectedProject;

        public ProjectDetails(Project selectedProject)
        {
            InitializeComponent();
            _selectedProject = selectedProject;
            _relationalRepository = new RelationalRepository();
            projectNameTextBox.Text = _selectedProject.Name;
            projectStartDeadlineTextBox.Text = $"{_selectedProject.Start:d} - {_selectedProject.Deadline:d}";
            RefreshEmployeesListBox();
            RefreshRolesComboBox();
        }

        public void RefreshEmployeesListBox(string role = "All")
        {
            employeesListBox.Items.Clear();
            foreach (var relation in _relationalRepository.GetAll())
                if (_selectedProject.Equals(relation.Item1))
                    foreach (var employee in relation.Item2)
                        if (role.Contains("All"))
                            employeesListBox.Items.Add($"{employee.Item1} - {employee.Item2} weekly work hours");
                        else if (role.Contains(employee.Item1.Role.ToString()))
                            employeesListBox.Items.Add($"{employee.Item1} - {employee.Item2} weekly work hours");
        }

        public void RefreshRolesComboBox()
        {
            var allCount = 0;
            foreach (var role in (Role[]) Enum.GetValues(typeof(Role)))
                if (_relationalRepository.CountOf(_selectedProject, role) > 0) { 
                    rolesComboBox.Items.Add($"{role} ({_relationalRepository.CountOf(_selectedProject, role)})");
                    allCount++;
            }
            rolesComboBox.Items.Add($"All ({allCount})");
            rolesComboBox.Text = $"All ({allCount})";
        }

        private void RolesComboBoxChanged(object sender, EventArgs e)
        {
            RefreshEmployeesListBox(rolesComboBox.Text);
        }
    }
}