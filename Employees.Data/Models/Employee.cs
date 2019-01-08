using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Employees.Data.Enums;

namespace Employees.Data.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Oib { get; set; }
        public DateTime Birthday { get; set; }
        public Role Role { get; set; }
        public List<Tuple<Project, int>> ProjectsList { get; set; }

        public Employee(string firstName, string lastName, string oib, DateTime birthday, Role role, List<Tuple<Project, int>> projectsList)
        {
            FirstName = firstName;
            LastName = lastName;
            Oib = oib;
            Birthday = birthday;
            Role = role;
            ProjectsList = projectsList;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} ({Role})";
        }
    }
}
