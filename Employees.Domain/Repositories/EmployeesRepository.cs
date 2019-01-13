using System;
using System.Collections.Generic;
using System.Linq;
using Employees.Data.Models;
using Employees.Data.Enums;

namespace Employees.Domain.Repositories
{
    public sealed class EmployeesRepository
    {
        public static List<Employee> EmployeesList = new List<Employee>();

        public List<Employee> GetAll() => EmployeesList;

        public void Add(Employee employeeToAdd)
        {
            EmployeesList.Add(employeeToAdd);
        }

        public void Remove(Employee employeeToRemove)
        {
            EmployeesList.Remove(employeeToRemove);
        }

        public void SeedData()
        {
            var employee1 = new Employee("Nino", "Borović", "75027076027", new DateTime(2000, 1, 1), Role.Programmer);
            var employee2 = new Employee("Ante Antunović", "Antić", "90271366100", new DateTime(1999, 2, 2), Role.Designer);
            var employee3 = new Employee("Ivo", "Ivić", "47292640142", new DateTime(1997, 3, 3), Role.Accauntant);

            EmployeesList.Add(employee1);
            EmployeesList.Add(employee2);
            EmployeesList.Add(employee3);

            var project1 = new Project("Dump Days", DateTime.Now.AddDays(12), DateTime.Now.AddDays(20));
            var project2 = new Project("Dump Internship", DateTime.Now.AddDays(-14), DateTime.Now.AddDays(15));
            var project3 = new Project("Sveuciliste natjecaji", DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-2));

            EmployeesList[0].ProjectsList.Add(new Relation(project1, 19));
            EmployeesList[1].ProjectsList.Add(new Relation(project1, 15));
            EmployeesList[2].ProjectsList.Add(new Relation(project1, 10));
            EmployeesList[1].ProjectsList.Add(new Relation(project2, 16));
            EmployeesList[2].ProjectsList.Add(new Relation(project2, 11));
            EmployeesList[0].ProjectsList.Add(new Relation(project3, 22));
        }

        public int CountOfEmployees(Project selectedProject, Role? role = null)
        {
            var counter = 0;

            if (role == null) counter = selectedProject.EmployeesList.Count();

            foreach (var relation in selectedProject.EmployeesList)
                if (relation.Employee.Role == role)
                    counter++;

            return counter;
        }

        public int CountOfWeeklyWorkHours(Employee selectedEmployee)
        {
            var countOfWeeklyWorkHours = 0;

            foreach (var relation in selectedEmployee.ProjectsList)
                countOfWeeklyWorkHours += relation.WeeklyWorkHours;

            return countOfWeeklyWorkHours;
        }
    }
}