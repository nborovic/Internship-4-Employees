using System;
using System.Linq;
using System.Windows.Forms;
using Employees.Data.Enums;
using Employees.Data.Models;
using Employees.Domain.Repositories;
using Employees.Infrastructure.Extensions;

namespace Employees.Presentation.Forms
{
    public partial class CreateEditEmployee : Form
    {
        private readonly EmployeesRepository _employeesRepository = new EmployeesRepository();
        private readonly ProjectsRepository _projectsRepository = new ProjectsRepository();
        private readonly Employee _selectedEmployee;

        public CreateEditEmployee()
        {
            InitializeComponent();
            RefreshProjectsList();
            RefreshRoles();
        }

        public CreateEditEmployee(Employee selectedEmployee)
        {
            InitializeComponent();
            _selectedEmployee = selectedEmployee;
            employeeFirstName.Text = selectedEmployee.FirstName;
            employeeLastName.Text = selectedEmployee.LastName;
            employeeOib.Text = selectedEmployee.Oib;
            employeeBirthday.Text = selectedEmployee.Birthday.ToString("D");
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
            if (weeklyWorkHours.Text == "" || projectsListBox.SelectedItem == null || int.Parse(weeklyWorkHours.Text) == 0)
            {
                MessageBox.Show(@"No project selected or weekly work hours not inputted!", @"Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(@"No project selected!", @"Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            projectsListBox.Items.Add(selectedProject.Project);
            addedProjectsListBox.Items.Remove(selectedProject);
        }

        private bool CheckInput()
        {
            var projectsList = addedProjectsListBox.Items.Cast<Relation>().ToList();

            if (employeeFirstName.Text == "" || employeeLastName.Text == "" || employeeOib.Text == "" ||
                employeeRole.SelectedItem == null || !projectsList.Any())
            {
                MessageBox.Show(@"One or more fields empty!", @"Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (employeeFirstName.Text.Length + employeeLastName.Text.Length > 25)
            {
                MessageBox.Show($@"Employee's full name is too long, contains: {employeeFirstName.Text.Length + employeeLastName.Text.Length} characters! Limit: 25", @"Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var counter = 0;

            foreach (var employee in _employeesRepository.GetAll())
                if (employeeOib.Text == employee.Oib)
                    counter++;

            if (counter > 0 && _selectedEmployee == null || counter > 1 && _selectedEmployee != null)
            {
                MessageBox.Show($@"Employee with {employeeOib.Text} OIB already exists!", @"Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var birthday = Convert.ToDateTime(employeeBirthday.Text);

            if (DateTime.Now - birthday >= DateTime.Now - DateTime.Now.AddYears(-18)) return true;
            MessageBox.Show(@"Employee is younger than 18 years old", @"Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void Save(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            // Removing relations
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

            // Adding new employee
            var projectsList = addedProjectsListBox.Items.Cast<Relation>().ToList();

            var employeeToAdd = new Employee(employeeFirstName.Text.NameFormatting(),
                employeeLastName.Text.NameFormatting(), employeeOib.Text, Convert.ToDateTime(employeeBirthday.Text),
                (Role) employeeRole.SelectedItem);
            _employeesRepository.Add(employeeToAdd);

            var addedEmployee = _employeesRepository.GetAll().Find(x => x.Oib == employeeToAdd.Oib);

            // Adding projects to Employee.ProjectsList
            foreach (var relationProject in projectsList)
                addedEmployee.ProjectsList.Add(relationProject);

            // Adding employee to relational projects
            foreach (var project in _projectsRepository.GetAll())
                foreach (var relation in projectsList)
                    if (relation.Project.Equals(project))
                    {
                        project.EmployeesList.Add(new Relation(addedEmployee, relation.WeeklyWorkHours));
                        break;
                    }

            Close();
        }

        private void Back(object sender, EventArgs e)
        {
            Close();
        }
    }
}