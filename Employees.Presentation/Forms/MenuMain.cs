using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employees.Data.Enums;
using Employees.Data.Models;
using Employees.Domain.Repositories;

namespace Employees.Presentation.Forms
{
    public partial class MenuMain : Form
    {
        private readonly EmployeesRepository _employeesRepository;
        private readonly ProjectsRepository _projectsRepository;
        private readonly RelationalRepository _relationalRepository;
        private string _option;

        public MenuMain()
        {
            InitializeComponent();
            _employeesRepository = new EmployeesRepository();
            _projectsRepository = new ProjectsRepository();
            _relationalRepository = new RelationalRepository();
            _option = "0";
            GenerateEmployeesProjectsRelations();
            RefreshList();
            SearchAutoComplete();
        }

        private void GenerateEmployeesProjectsRelations()
        {
            _employeesRepository.GenerateEmployees();
            _projectsRepository.GenerateProjects();
            _relationalRepository.GenerateRelations();
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
                    foreach (var employee in employeesList)
                        if ($"{employee.FirstName} {employee.LastName}".Contains(searchTextBox.Text))
                            employeeProjectListBox.SelectedItem = employee;
                    break;

                default:
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
                    foreach (var employee in employeesList)
                    {
                        employeeProjectArray[i] = $"{employee.FirstName} {employee.LastName}";
                        i++;
                    }
                    break;

                default:
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
            switch (_option)
            {
                case "0":
                    break;

                default:
                    var projectDetailsWindow = new ProjectDetails(employeeProjectListBox.SelectedItem as Project);
                    projectDetailsWindow.ShowDialog();
                    break;
            }
        }
    }
}
