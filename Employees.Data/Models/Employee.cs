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

        public Employee(string firstName, string lastName, string oib, DateTime birthday, Role role)
        {
            FirstName = firstName;
            LastName = lastName;
            Oib = oib;
            Birthday = birthday;
            Role = role;
            ProjectsList = new List<Tuple<Project, int>>();
        }

        public override bool Equals(object obj)
        {
            var item = obj as Employee;
            return item != null && Oib == item.Oib;
        }

        public override int GetHashCode()
        {
            return Oib.GetHashCode();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} ({Role})";
        }
    }
}
