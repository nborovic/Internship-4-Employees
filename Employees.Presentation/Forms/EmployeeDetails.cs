using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employees.Data.Enums;
using Employees.Data.Models;
using Employees.Domain.Repositories;

namespace Employees.Presentation.Forms
{
    public partial class EmployeeDetails : Form
    {
        private readonly EmployeesRepository _employeesRepository;
        private readonly ProjectsRepository _projectsRepository;
        public Employee Employee;

        public EmployeeDetails(Employee selectedEmployee)
        {
            InitializeComponent();
            Employee = selectedEmployee;
            _employeesRepository = new EmployeesRepository();
            _projectsRepository = new ProjectsRepository();
            employeeToStringTextBox.Text = selectedEmployee.ToString();
            employeeBirthdayTextBox.Text += selectedEmployee.Birthday.ToString("d");
            oibTextBox.Text += selectedEmployee.Oib;
            weeklyWorkHoursTextBox.Text += _employeesRepository.CountOfWeeklyWorkHours(Employee) + " hours";
            RefreshColorIndicator();
            RefreshProjectsList("All");
            RefreshProjectStateComboBox();
        }

        private void RefreshColorIndicator()
        {
            var weeklyWorkHoursAsInt = _employeesRepository.CountOfWeeklyWorkHours(Employee);

            if (weeklyWorkHoursAsInt >= 41)
                weeklyWorkHoursColoredIndicator.BackColor = Color.Red;
            else if (weeklyWorkHoursAsInt > 30)
                weeklyWorkHoursColoredIndicator.BackColor = Color.Green;
            else
                weeklyWorkHoursColoredIndicator.BackColor = Color.Yellow;
        }

        private void RefreshProjectsList(string state)
        {
            employeeProjectsListBox.Items.Clear();
            foreach (var relation in Employee.ProjectsList)
                if (state.Contains(relation.Project.State.ToString()))
                    employeeProjectsListBox.Items.Add(relation.Project);
                else if (state.Contains("All"))
                    employeeProjectsListBox.Items.Add(relation.Project);
        }

        private void RefreshProjectStateComboBox()
        {
            var allCount = 0;
            foreach (var state in (State[]) Enum.GetValues(typeof(State)))
                if (_projectsRepository.CountOfProjects(Employee, state) > 0) {          
                    statesComboBox.Items.Add($"{state} ({_projectsRepository.CountOfProjects(Employee, state)})");
                    allCount++;
                }

            statesComboBox.Items.Add($"All ({allCount})");
            statesComboBox.Text = $@"All ({allCount})";
        }

        private void StatesComboBoxChanged(object sender, EventArgs e)
        {
            RefreshProjectsList(statesComboBox.Text);
        }
    }
}