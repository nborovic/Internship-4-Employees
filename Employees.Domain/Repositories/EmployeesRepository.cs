using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Data.Models;

namespace Employees.Domain.Repositories
{
    public sealed class EmployeesRepository
    {
        public static List<Employee> EmployeesList;

        public List<Employee> GetAll() => EmployeesList;
    }
}
