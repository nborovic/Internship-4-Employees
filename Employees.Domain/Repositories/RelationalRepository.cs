﻿using Employees.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Data.Enums;

namespace Employees.Domain.Repositories
{
    public class RelationalRepository
    {
        public static List<Tuple<Project, List<Tuple<Employee, int>>>> ProjectEmployeeList = new List<Tuple<Project, List<Tuple<Employee, int>>>>();

        public List<Tuple<Project, List<Tuple<Employee, int>>>> GetAll() => ProjectEmployeeList;

        public void Add(Tuple<Project, List<Tuple<Employee, int>>> projectEmployeeToAdd)
        {
            ProjectEmployeeList.Add(projectEmployeeToAdd);
        }

        public void GenerateRelations()
        {
            var employeesRepo = new EmployeesRepository();
            var projectsRepo = new ProjectsRepository();
            var employeesList = employeesRepo.GetAll();
            var projectsList = projectsRepo.GetAll();

            ProjectEmployeeList.Add(new Tuple<Project, List<Tuple<Employee, int>>>(projectsList[0], new List<Tuple<Employee, int>>()
            {
                new Tuple<Employee, int>(employeesList[0], 19),
                new Tuple<Employee, int>(employeesList[1], 15),
                new Tuple<Employee, int>(employeesList[2], 10)
            }));
            ProjectEmployeeList.Add(new Tuple<Project, List<Tuple<Employee, int>>>(projectsList[1], new List<Tuple<Employee, int>>()
            {
                new Tuple<Employee, int>(employeesList[1], 16),
                new Tuple<Employee, int>(employeesList[2], 11)
            }));
            ProjectEmployeeList.Add(new Tuple<Project, List<Tuple<Employee, int>>>(projectsList[2], new List<Tuple<Employee, int>>()
            {
                new Tuple<Employee, int>(employeesList[0], 22),
            }));
        }

        public int CountOf_Role(Project selectedProject, Role role)
        {
            var counter = 0;

            foreach (var projectEmployee in ProjectEmployeeList)
                if (selectedProject.Equals(projectEmployee.Item1))
                {
                    foreach (var employee in projectEmployee.Item2)
                        if (employee.Item1.Role == role)
                            counter++;
                    break;
                }

            return counter;
        }

        public int CountOf_State(Employee selectedEmployee, State state)
        {
            var counter = 0;

            foreach (var relation in ProjectEmployeeList)
                foreach (var employee in relation.Item2)
                    if (selectedEmployee.Equals(employee.Item1) && state == relation.Item1.State)
                        counter++;

            return counter;
        }

        public int CountOfWeeklyWorkHours(Employee selectedEmployee)
        {
            var countOfWeeklyWorkHours = 0;
            foreach (var relation in ProjectEmployeeList)
                foreach (var employee in relation.Item2)
                    if (selectedEmployee.Equals(employee.Item1))
                        countOfWeeklyWorkHours += employee.Item2;

            return countOfWeeklyWorkHours;
        }
    }
}
