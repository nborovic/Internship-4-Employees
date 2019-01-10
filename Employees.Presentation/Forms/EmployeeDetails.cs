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
        private readonly RelationalRepository _relationalRepository;
        public Employee Employee;

        public EmployeeDetails(Employee selectedEmployee)
        {
            InitializeComponent();
            Employee = selectedEmployee;
            _relationalRepository = new RelationalRepository();
            employeeToStringTextBox.Text = selectedEmployee.ToString();
            employeeBirthdayTextBox.Text += selectedEmployee.Birthday.ToString("d");
            oibTextBox.Text += selectedEmployee.Oib;
            weeklyWorkHoursTextBox.Text += _relationalRepository.CountOfWeeklyWorkHours(Employee) + " hours";
            RefreshColorIndicator();
            RefreshProjectsList("All");
            RefreshProjectStateComboBox();
        }

        private void RefreshColorIndicator()
        {
            var weeklyWorkHoursAsInt = _relationalRepository.CountOfWeeklyWorkHours(Employee);

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
            foreach (var relation in _relationalRepository.GetAll())
                foreach (var employee in relation.Item2)
                    if (employee.Item1.Equals(Employee) && state.Contains(relation.Item1.State.ToString()))
                        employeeProjectsListBox.Items.Add(relation.Item1);
                    else if (employee.Item1.Equals(Employee) && state.Contains("All"))
                        employeeProjectsListBox.Items.Add(relation.Item1);
        }

        private void RefreshProjectStateComboBox()
        {
            var allCount = 0;
            foreach (var state in (State[]) Enum.GetValues(typeof(State)))
                if (_relationalRepository.CountOf_State(Employee, state) > 0)
                {
                    statesComboBox.Items.Add($"{state} ({_relationalRepository.CountOf_State(Employee, state)})");
                    allCount++;
                }
            statesComboBox.Items.Add($"All ({allCount})");
            statesComboBox.Text = $"All ({allCount})";
        }

        private void StatesComboBoxChanged(object sender, EventArgs e)
        {
            RefreshProjectsList(statesComboBox.Text);
        }
    }
}