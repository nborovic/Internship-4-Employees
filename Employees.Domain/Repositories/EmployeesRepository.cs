using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void GenerateEmployees()
        {
            var employee1 = new Employee("Nino", "Borović", "75027076027", new DateTime(2000, 1, 1), Role.Programmer);
            var employee2 = new Employee("Onin", "Ćivorob", "90271366100", new DateTime(1999, 2, 2), Role.Designer);
            var employee3 = new Employee("Inon", "Voborić", "47292640142", new DateTime(1997, 3, 3), Role.Accauntant);

            EmployeesList.Add(employee1);
            EmployeesList.Add(employee2);
            EmployeesList.Add(employee3);
        }
    }
}
