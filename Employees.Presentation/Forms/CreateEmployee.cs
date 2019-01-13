using System;
using System.Linq;
using System.Windows.Forms;
using Employees.Data.Enums;
using Employees.Data.Models;
using Employees.Domain.Repositories;
using Employees.Infrastructure.Extensions;

namespace Employees.Presentation.Forms
{
    public partial class CreateEmployee : Form
    {
        private readonly EmployeesRepository _employeesRepository = new EmployeesRepository();
        private readonly ProjectsRepository _projectsRepository = new ProjectsRepository();
        private readonly Employee _selectedEmployee = null;

        public CreateEmployee()
        {
            InitializeComponent();
            RefreshProjectsList();
            RefreshRoles();
        }

        public CreateEmployee(Employee selectedEmployee)
        {
            InitializeComponent();
            _selectedEmployee = selectedEmployee;
            employeeFirstName.Text = selectedEmployee.FirstName;
            employeeLastName.Text = selectedEmployee.LastName;
            employeeOib.Text = selectedEmployee.Oib;
            employeeBirthday.Text = selectedEmployee.Birthday.ToString();
            RefreshAddedProjectsList();
            RefreshRoles();
            employeeRole.SelectedItem = selectedEmployee.Role;
            RefreshProjectsList();
            RemoveDuplicates();
        }

        public void RefreshRoles()
        {
            foreach (var role in (Role[]) Enum.GetValues(typeof(Role)))
                employeeRole.Items.Add(role);
        }

        public void RefreshProjectsList()
        {
            foreach (var project in _projectsRepository.GetAll())
                projectsListBox.Items.Add(project);
        }

        public void RefreshAddedProjectsList()
        {
            foreach (var relation in _selectedEmployee.ProjectsList)
                addedProjectsListBox.Items.Add(relation);
        }

        public void RemoveDuplicates()
        {
            var addedProjectsList = addedProjectsListBox.Items.Cast<Relation>().ToList();
            var projectsList = projectsListBox.Items.Cast<Project>().ToList();

            foreach (var project in projectsList)
            foreach (var relation in addedProjectsList)
                if (project.Equals(relation.Project))
                    projectsListBox.Items.Remove(relation.Project);
        }

        private void Add(object sender, EventArgs e)
        {
            if (weeklyWorkHours.Text == "" || projectsListBox.SelectedItem == null ||
                int.Parse(weeklyWorkHours.Text) == 0)
            {
                MessageBox.Show(@"No project selected or weekly work hours not inputted!", @"Selection");
                return;
            }

            addedProjectsListBox.Items.Add(new Relation(projectsListBox.SelectedItem as Project,
                int.Parse(weeklyWorkHours.Text)));
            projectsListBox.Items.Remove(projectsListBox.SelectedItem);
        }

        private void Remove(object sender, EventArgs e)
        {
            var selectedProject = addedProjectsListBox.SelectedItem as Relation;

            if (selectedProject == null)
            {
                MessageBox.Show(@"No project selected!", @"Selection");
                return;
            }

            projectsListBox.Items.Add(selectedProject.Project);
            addedProjectsListBox.Items.Remove(selectedProject);
        }

        private bool CheckFormatInput()
        {
            var projectsList = addedProjectsListBox.Items.Cast<Relation>().ToList();

            if (employeeFirstName.Text == "" || employeeLastName.Text == "" || employeeOib.Text == "" ||
                employeeRole.SelectedItem == null || !projectsList.Any())
            {
                MessageBox.Show(@"One or more fields empty!", @"Invalid input");
                return false;
            }

            foreach (var employee in _employeesRepository.GetAll())
                if (employeeOib.Text == employee.Oib)
                {
                    MessageBox.Show($@"Employee with {employeeOib.Text} OIB already exists!", @"Invalid input");
                    return false;
                }

            var birthday = Convert.ToDateTime(employeeBirthday.Text);

            if (DateTime.Now - birthday >= DateTime.Now - DateTime.Now.AddYears(-18)) return true;
            MessageBox.Show(@"Employee is younger than 18 years old", @"Invalid input");
            return false;
        }

        private void Save(object sender, EventArgs e)
        {
            if (_selectedEmployee != null)
            {
                foreach (var project in _projectsRepository.GetAll())
                foreach (var relation in project.EmployeesList)
                    if (_selectedEmployee.Equals(relation.Employee))
                    {
                        project.EmployeesList.Remove(relation);
                        break;
                    }

                _employeesRepository.Remove(_selectedEmployee);
            }

            var projectsList = addedProjectsListBox.Items.Cast<Relation>().ToList();

            if (!CheckFormatInput()) return;
            var employeeToAdd = new Employee(employeeFirstName.Text.NameFormatting(),
                employeeLastName.Text.NameFormatting(), employeeOib.Text, Convert.ToDateTime(employeeBirthday.Text),
                (Role) employeeRole.SelectedItem);
            _employeesRepository.Add(employeeToAdd);

            var addedEmployee = _employeesRepository.GetAll().Find(x => x.Oib == employeeToAdd.Oib);

            foreach (var relationProject in projectsList)
                addedEmployee.ProjectsList.Add(relationProject);

            foreach (var project in _projectsRepository.GetAll())
                foreach (var relation in projectsList)
                    if (relation.Project.Equals(project))
                    {
                        project.EmployeesList.Add(new Relation(addedEmployee, relation.WeeklyWorkHours));
                        break;
                    }

            var employeeDetailsWindow = new EmployeeDetails(addedEmployee);
            employeeDetailsWindow.ShowDialog();
            Close();
        }

        private void Back(object sender, EventArgs e)
        {
            Hide();
            var employeeDetailsWindow = new EmployeeDetails(_selectedEmployee);
            employeeDetailsWindow.Closed += (s, args) => Close();
            employeeDetailsWindow.ShowDialog();
        }
    }
}