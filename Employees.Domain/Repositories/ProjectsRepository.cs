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
        public static List<Project> ProjectsList;

        public List<Project> GetAll() => ProjectsList;
    }
}
