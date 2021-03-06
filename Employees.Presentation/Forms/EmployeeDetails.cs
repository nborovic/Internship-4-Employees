﻿using System;
using System.Drawing;
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
        private readonly Employee _selectedEmployee;

        public EmployeeDetails(Employee selectedEmployee)
        {
            InitializeComponent();
            _selectedEmployee = selectedEmployee;
            _employeesRepository = new EmployeesRepository();
            _projectsRepository = new ProjectsRepository();
            employeeToStringTextBox.Text = selectedEmployee.ToString();
            employeeBirthdayTextBox.Text += selectedEmployee.Birthday.ToString("d");
            oibTextBox.Text += selectedEmployee.Oib;
            weeklyWorkHoursTextBox.Text += _employeesRepository.CountOfWeeklyWorkHours(_selectedEmployee) + @" hours";
            RefreshColorIndicator();
            RefreshProjectsList("All");
            RefreshProjectStateComboBox();
        }

        private void RefreshColorIndicator()
        {
            var weeklyWorkHoursAsInt = _employeesRepository.CountOfWeeklyWorkHours(_selectedEmployee);

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
            foreach (var relation in _selectedEmployee.ProjectsList)
                if (state.Contains(relation.Project.State.ToString()))
                    employeeProjectsListBox.Items.Add($"{relation.Project} - {relation.WeeklyWorkHours} hours");
                else if (state.Contains("All"))
                    employeeProjectsListBox.Items.Add($"{relation.Project} - {relation.WeeklyWorkHours} hours");
        }

        private void RefreshProjectStateComboBox()
        {
            var allCount = 0;

            foreach (var state in (State[]) Enum.GetValues(typeof(State)))
                if (_projectsRepository.CountOfProjects(_selectedEmployee, state) > 0) {          
                    statesComboBox.Items.Add($"{state} ({_projectsRepository.CountOfProjects(_selectedEmployee, state)})");
                    allCount += _projectsRepository.CountOfProjects(_selectedEmployee, state);
                }

            statesComboBox.Items.Add($"All ({allCount})");
            statesComboBox.Text = $@"All ({allCount})";
        }

        private void StatesComboBoxChanged(object sender, EventArgs e)
        {
            RefreshProjectsList(statesComboBox.Text);
        }

        private void Edit(object sender, EventArgs e)
        {
            Hide();
            var editWindow = new CreateEditEmployee(_selectedEmployee);
            editWindow.Closed += (s, args) => Close();
            editWindow.ShowDialog();
        }

        private void Back(object sender, EventArgs e)
        {
            Close();
        }
    }
}