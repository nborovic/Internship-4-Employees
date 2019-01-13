using System;
using System.Windows.Forms;
using Employees.Data.Enums;
using Employees.Data.Models;
using Employees.Domain.Repositories;

namespace Employees.Presentation.Forms
{
    public partial class ProjectDetails : Form
    {
        private readonly EmployeesRepository _employeesRepository;
        private readonly Project _selectedProject;

        public ProjectDetails(Project selectedProject)
        {
            InitializeComponent();
            _selectedProject = selectedProject;
            _employeesRepository = new EmployeesRepository();
            projectNameTextBox.Text = _selectedProject.Name;
            projectStartDeadlineTextBox.Text = $@"{_selectedProject.Start:d} - {_selectedProject.Deadline:d}";
            RefreshEmployeesListBox("All");
            RefreshRolesComboBox();
        }

        public void RefreshEmployeesListBox(string role)
        {
            employeesListBox.Items.Clear();
                    foreach (var relation in _selectedProject.EmployeesList)
                        if (role.Contains("All"))
                            employeesListBox.Items.Add($"{relation.Employee} - {relation.WeeklyWorkHours} hours");
                        else if (role.Contains(relation.Employee.Role.ToString()))
                            employeesListBox.Items.Add($"{relation.Employee} - {relation.WeeklyWorkHours} hours");
        }

        public void RefreshRolesComboBox()
        {
            var allCount = 0;
            foreach (var role in (Role[]) Enum.GetValues(typeof(Role)))
                if (_employeesRepository.CountOfEmployees(_selectedProject, role) > 0) { 
                    rolesComboBox.Items.Add($"{role} ({_employeesRepository.CountOfEmployees(_selectedProject, role)})");
                    allCount += _employeesRepository.CountOfEmployees(_selectedProject, role);
                }

            rolesComboBox.Items.Add($"All ({allCount})");
            rolesComboBox.Text = $@"All ({allCount})";
        }

        private void RolesComboBoxChanged(object sender, EventArgs e)
        {
            RefreshEmployeesListBox(rolesComboBox.Text);
        }

        private void Edit(object sender, EventArgs e)
        {
            Hide();
            var editWindow = new CreateEditProject(_selectedProject);
            editWindow.Closed += (s, args) => Close();
            editWindow.ShowDialog();
        }

        private void Back(object sender, EventArgs e)
        {
            Close();
        }
    }
}