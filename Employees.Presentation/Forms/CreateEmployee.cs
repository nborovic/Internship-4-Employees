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

        public CreateEmployee()
        {
            InitializeComponent();
            RefreshProjectsList();
            RefreshRoles();
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

        private void Add(object sender, EventArgs e)
        {
            if (weeklyWorkHours.Text == "" || projectsListBox.SelectedItem == null)
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
            var selectedProject = addedProjectsListBox.SelectedItem as Tuple<Project, int>;

            if (selectedProject == null)
            {
                MessageBox.Show(@"No project selected!", @"Selection");
                return;
            }

            projectsListBox.Items.Add(selectedProject.Item1);
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

            if (DateTime.Now - birthday < DateTime.Now - DateTime.Now.AddYears(-18))
            {
                MessageBox.Show(@"Employee is younger than 18 years old", @"Invalid input");
                return false;
            }

            return true;
        }

        private void Save(object sender, EventArgs e)
        {
            var projectsList = addedProjectsListBox.Items.Cast<Relation>().ToList();

            if (!CheckFormatInput()) return;
            var employeeToAdd = new Employee(employeeFirstName.Text.NameFormatting(), employeeLastName.Text.NameFormatting(), employeeOib.Text, Convert.ToDateTime(employeeBirthday.Text),
                (Role)employeeRole.SelectedItem);
            _employeesRepository.Add(employeeToAdd);

            foreach (var employee in _employeesRepository.GetAll())
                if (employeeToAdd.Equals(employee))
                    foreach (var relation in projectsList)
                        employee.ProjectsList.Add(relation);

            Close();
        }
    }
}
