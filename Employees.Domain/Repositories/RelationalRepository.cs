using Employees.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.Repositories
{
    public class RelationalRepository
    {
        public static List<Tuple<Project, List<Tuple<Employee, int>>>> ProjectEmployee = new List<Tuple<Project, List<Tuple<Employee, int>>>>();

        public List<Tuple<Project, List<Tuple<Employee, int>>>> GetAll() => ProjectEmployee;

        public void Add(Tuple<Project, List<Tuple<Employee, int>>> projectEmployeeToAdd)
        {
            ProjectEmployee.Add(projectEmployeeToAdd);
        }

        public void GenerateRelations()
        {
            var employeesRepo = new EmployeesRepository();
            var projectsRepo = new ProjectsRepository();
            var employeesList = employeesRepo.GetAll();
            var projectsList = projectsRepo.GetAll();

            ProjectEmployee.Add(new Tuple<Project, List<Tuple<Employee, int>>>(projectsList[0], new List<Tuple<Employee, int>>()
            {
                new Tuple<Employee, int>(employeesList[0], 11),
                new Tuple<Employee, int>(employeesList[1], 8),
                new Tuple<Employee, int>(employeesList[2], 7)
            }));
            ProjectEmployee.Add(new Tuple<Project, List<Tuple<Employee, int>>>(projectsList[1], new List<Tuple<Employee, int>>()
            {
                new Tuple<Employee, int>(employeesList[1], 5),
                new Tuple<Employee, int>(employeesList[2], 11)
            }));
            ProjectEmployee.Add(new Tuple<Project, List<Tuple<Employee, int>>>(projectsList[2], new List<Tuple<Employee, int>>()
            {
                new Tuple<Employee, int>(employeesList[0], 8),
            }));
        }
    }
}
