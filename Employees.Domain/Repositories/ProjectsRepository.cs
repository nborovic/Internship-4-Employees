using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void GenerateProjects()
        {
            var project1 = new Project("Dump Days", DateTime.Now.AddDays(12), DateTime.Now.AddDays(20));
            var project2 = new Project("Dump Internship", DateTime.Now.AddDays(-14), DateTime.Now.AddDays(15));
            var project3 = new Project("Sveuciliste natjecaji", DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-2));

            ProjectsList.Add(project1);
            ProjectsList.Add(project2);
            ProjectsList.Add(project3);
        }
    }
}
