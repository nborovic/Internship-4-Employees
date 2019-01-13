using System;
using System.Linq;
using System.Windows.Forms;
using Employees.Data.Models;
using Employees.Domain.Repositories;

namespace Employees.Presentation.Forms
{
    public partial class MenuMain : Form
    {
        private readonly EmployeesRepository _employeesRepository;
        private readonly ProjectsRepository _projectsRepository;
        private string _option;

        public MenuMain()
        {
            InitializeComponent();
            _employeesRepository = new EmployeesRepository();
            _projectsRepository = new ProjectsRepository();
            _option = "0";
            GenerateEmployeesProjectsRelations();
            RefreshList();
            SearchAutoComplete();
        }

        private void GenerateEmployeesProjectsRelations()
        {
            _employeesRepository.SeedData();
            _projectsRepository.SeedData();
        }

        private void RefreshList()
        {
            employeeProjectListBox.Items.Clear();

            if (_option == "1")
                foreach (var project in _projectsRepository.GetAll())
                    employeeProjectListBox.Items.Add(project);
            else
                foreach (var employee in _employeesRepository.GetAll())
                    employeeProjectListBox.Items.Add(employee);
        }

        private void RefreshProjects(object sender, EventArgs e)
        {
            _option = "1";
            RefreshList();
            SearchAutoComplete();
        }

        private void RefreshEmployees(object sender, EventArgs e)
        {
            _option = "0";
            RefreshList();
            SearchAutoComplete();
        }

        private void Search(object sender, EventArgs e)
        {
            var employeesList = (_option == "0") ? employeeProjectListBox.Items.Cast<Employee>().ToList() : null;
            var projectsList = (_option == "1") ? employeeProjectListBox.Items.Cast<Project>().ToList() : null;

            switch (_option)
            {
                case "0":
                    if (employeesList != null)
                        foreach (var employee in employeesList)
                            if ($"{employee.FirstName} {employee.LastName}".Contains(searchTextBox.Text))
                                employeeProjectListBox.SelectedItem = employee;
                    break;

                default:
                    if (projectsList != null)
                        foreach (var project in projectsList)
                            if (project.Name.Contains(searchTextBox.Text))
                                employeeProjectListBox.SelectedItem = project;
                    break;
            }
        }

        public void SearchAutoComplete()
        {
            var employeesList = (_option == "0") ? employeeProjectListBox.Items.Cast<Employee>().ToList() : null;
            var projectsList = (_option == "1") ? employeeProjectListBox.Items.Cast<Project>().ToList() : null;

            var employeeProjectArray = new string[employeeProjectListBox.Items.Count];
            var i = 0;

            switch (_option)
            {
                case "0":
                    if (employeesList != null)
                        foreach (var employee in employeesList)
                        {
                            employeeProjectArray[i] = $"{employee.FirstName} {employee.LastName}";
                            i++;
                        }

                    break;

                default:
                    if (projectsList != null)
                        foreach (var project in projectsList)
                        {
                            employeeProjectArray[i] = project.Name;
                            i++;
                        }

                    break;
            }

            searchTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            searchTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchTextBox.AutoCompleteCustomSource.AddRange(employeeProjectArray);
        }

        private void Details(object sender, EventArgs e)
        {
            if (employeeProjectListBox.SelectedItem == null)
            {
                MessageBox.Show(@"No employee/project selected!", @"Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (_option)
            {
                case "0":
                    Hide();
                    var employeeDetailsWindow = new EmployeeDetails(employeeProjectListBox.SelectedItem as Employee);
                    employeeDetailsWindow.Closed += (s, args) => Show();
                    employeeDetailsWindow.ShowDialog();                   
                    break;

                default:
                    Hide();
                    var projectDetailsWindow = new ProjectDetails(employeeProjectListBox.SelectedItem as Project);
                    projectDetailsWindow.Closed += (s, args) => Show();
                    projectDetailsWindow.ShowDialog();
                    break;
            }

            RefreshList();
            SearchAutoComplete();
        }

        private void Create(object sender, EventArgs e)
        {
            switch (_option)
            {
                case "0":
                    Hide();
                    var createEmployeeWindow = new CreateEditEmployee();
                    createEmployeeWindow.Closed += (s, args) => Show();
                    createEmployeeWindow.ShowDialog();
                    break;

                default:
                    Hide();
                    var createProjectWindow = new CreateEditProject();
                    createProjectWindow.Closed += (s, args) => Show();
                    createProjectWindow.ShowDialog();
                    break;
            }

            RefreshList();
            SearchAutoComplete();
        }

        private void Delete(object sender, EventArgs e)
        {
            var selectedItem = employeeProjectListBox.SelectedItem;

            if (selectedItem == null)
                MessageBox.Show(@"No employee/project selected!", @"Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (MessageBox.Show(@"Are you sure you want to delete this employee/project?", @"Delete",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (_option)
                {
                    case "0":
                        foreach (var project in _projectsRepository.GetAll())
                        foreach (var relation in project.EmployeesList)
                            if (relation.Employee.Equals(selectedItem))
                                if (project.EmployeesList.Count > 1)
                                {
                                    project.EmployeesList.Remove(relation);
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show($@"You can't delete employee because he is the only one working on {project}", @"Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                        _employeesRepository.Remove(selectedItem as Employee);
                        employeeProjectListBox.Items.Remove(selectedItem);
                        break;

                    default:
                        foreach (var employee in _employeesRepository.GetAll())
                        foreach (var project in employee.ProjectsList)
                            if (project.Project.Equals(selectedItem))
                                {
                                    employee.ProjectsList.Remove(project);
                                    break;
                                }
                                
                        _projectsRepository.Remove(employeeProjectListBox.SelectedItem as Project);
                        employeeProjectListBox.Items.Remove(selectedItem);
                        break;
                }
            }
        }
    }
}