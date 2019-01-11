using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Data.Enums;
using Employees.Data.Models;

namespace Employees.Domain.Repositories
{
    public sealed class ProjectsRepository
    {
        public static List<Project> ProjectsList = new List<Project>();

        public List<Project> GetAll() => ProjectsList;

        public void Add(Project projectToAdd)
        {
            ProjectsList.Add(projectToAdd);
        }

        public void Remove(Project projectToRemove)
        {
            ProjectsList.Remove(projectToRemove);
        }

        public void SeedData()
        {
            var project1 = new Project("Dump Days", DateTime.Now.AddDays(12), DateTime.Now.AddDays(20));
            var project2 = new Project("Dump Internship", DateTime.Now.AddDays(-14), DateTime.Now.AddDays(15));
            var project3 = new Project("Sveuciliste natjecaji", DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-2));

            ProjectsList.Add(project1);
            ProjectsList.Add(project2);
            ProjectsList.Add(project3);

            var employee1 = new Employee("Nino", "Borović", "75027076027", new DateTime(2000, 1, 1), Role.Programmer);
            var employee2 = new Employee("Ante", "Antić", "90271366100", new DateTime(1999, 2, 2), Role.Designer);
            var employee3 = new Employee("Ivo", "Ivić", "47292640142", new DateTime(1997, 3, 3), Role.Accauntant);

            ProjectsList[0].EmployeesList.Add(new Relation(employee1, 19));
            ProjectsList[0].EmployeesList.Add(new Relation(employee2, 15));
            ProjectsList[0].EmployeesList.Add(new Relation(employee3, 10));
            ProjectsList[1].EmployeesList.Add(new Relation(employee3, 16));
            ProjectsList[1].EmployeesList.Add(new Relation(employee2, 11));
            ProjectsList[2].EmployeesList.Add(new Relation(employee1, 22));
        }

        public int CountOfProjects(Employee selectedEmployee, State? state = null)
        {
            var counter = 0;

            if (state == null) counter = selectedEmployee.ProjectsList.Count();

            foreach (var relation in selectedEmployee.ProjectsList)
                if (relation.Project.State == state)
                    counter++;

            return counter;
        }
    }
}
