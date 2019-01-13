using System;
using System.Linq;
using System.Windows.Forms;
using Employees.Data.Models;
using Employees.Domain.Repositories;
using Employees.Infrastructure.Extensions;

namespace Employees.Presentation.Forms
{
    public partial class CreateEditProject : Form
    {
        private readonly EmployeesRepository _employeesRepository = new EmployeesRepository();
        private readonly ProjectsRepository _projectsRepository = new ProjectsRepository();
        private readonly Project _selectedProject;

        public CreateEditProject()
        {
            InitializeComponent();
            RefreshEmployeesList();
        }

        public CreateEditProject(Project selectedProject)
        {
            InitializeComponent();
            _selectedProject = selectedProject;
            projectName.Text = selectedProject.Name;
            projectStart.Text = selectedProject.Start.ToString("D");
            projectDeadline.Text = selectedProject.Deadline.ToString("D");
            RefreshEmployeesList();
            RefreshAddedEmployeesList();
            RemoveDuplicates();
        }

        public void RefreshEmployeesList()
        {
            foreach (var employee in _employeesRepository.GetAll())
                employeesListBox.Items.Add(employee);
        }

        public void RemoveDuplicates()
        {
            var addedEmployeesList = addedEmployeesListBox.Items.Cast<Relation>().ToList();
            var employeesList = employeesListBox.Items.Cast<Employee>().ToList();

            foreach (var employee in employeesList)
                foreach (var relation in addedEmployeesList)
                    if (relation.Employee.Equals(employee))
                        employeesListBox.Items.Remove(relation.Employee);
        }

        public void RefreshAddedEmployeesList()
        {
            foreach (var relation in _selectedProject.EmployeesList)
                addedEmployeesListBox.Items.Add(relation);
        }

        private void Add(object sender, EventArgs e)
        {
            if (weeklyWorkHours.Text == "" || employeesListBox.SelectedItem == null || int.Parse(weeklyWorkHours.Text) == 0)
            {
                MessageBox.Show(@"No employee selected or weekly work hours not inputted!", @"Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            addedEmployeesListBox.Items.Add(new Relation(employeesListBox.SelectedItem as Employee,
                int.Parse(weeklyWorkHours.Text)));
            employeesListBox.Items.Remove(employeesListBox.SelectedItem);
        }

        private void Remove(object sender, EventArgs e)
        {
            var selectedProject = addedEmployeesListBox.SelectedItem as Relation;

            if (selectedProject == null)
            {
                MessageBox.Show(@"No employee selected!", @"Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            employeesListBox.Items.Add(selectedProject.Employee);
            addedEmployeesListBox.Items.Remove(selectedProject);
        }

        private bool CheckInput()
        {
            var employeesList = addedEmployeesListBox.Items.Cast<Relation>().ToList();

            if (projectName.Text == "" || projectDeadline.Text == "" || projectStart.Text == "" || !employeesList.Any())
            {
                MessageBox.Show(@"One or more fields empty!", @"Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (projectName.Text.Length > 25)
            {
                MessageBox.Show($@"Project's name is too long, contains: {projectName.Text.Length} characters! Limit: 25", @"Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var counter = 0;

            foreach (var project in _projectsRepository.GetAll())
                if (projectName.Text == project.Name)
                    counter++;

            var isNameChanged = _selectedProject == null;

            if (!isNameChanged)
                isNameChanged = _selectedProject.Name != projectName.Text;

            if (isNameChanged && counter > 0 || !isNameChanged && counter > 1)
            {
                MessageBox.Show($@"{projectName.Text} project already exists!", @"Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var start = Convert.ToDateTime(projectStart.Text);
            var deadline = Convert.ToDateTime(projectDeadline.Text);

            if (start <= deadline) return true;
            MessageBox.Show(@"Deadline date must go after start date", @"Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void Save(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            // Removing relations
            if (_selectedProject != null)
            {
                foreach (var employee in _employeesRepository.GetAll())
                foreach (var relation in employee.ProjectsList)
                    if (_selectedProject.Equals(relation.Project))
                    {
                        employee.ProjectsList.Remove(relation);
                        break;
                    }

                _projectsRepository.Remove(_selectedProject);
            }

            // Adding new project
            var employeesList = addedEmployeesListBox.Items.Cast<Relation>().ToList();

            var projectToAdd = new Project(projectName.Text.TrimAndRemoveMultipleWhiteSpaces(), Convert.ToDateTime(projectStart.Text), Convert.ToDateTime(projectDeadline.Text));
            _projectsRepository.Add(projectToAdd);

            var addedProject = _projectsRepository.GetAll().Find(x => x.Name == projectToAdd.Name);

            // Adding employees to Project.EmployeesList
            foreach (var relation in employeesList)
                addedProject.EmployeesList.Add(relation);

            // Adding projects to relational employees
            foreach (var employee in _employeesRepository.GetAll())
                foreach (var relation in employeesList)
                    if (relation.Employee.Equals(employee))
                    {
                        employee.ProjectsList.Add(new Relation(addedProject, relation.WeeklyWorkHours));
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