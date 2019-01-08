using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Data.Enums;

namespace Employees.Data.Models
{
    public class Project
    {
        public string Name { get; set; }
        public List<Tuple<Employee, int>> EmployeesList { get; set; }
        public DateTime Start { get; set; }
        public DateTime Deadline { get; set; }
        public State State { get; set; }

        public Project(string name, List<Tuple<Employee, int>> employeeList, DateTime start, DateTime deadline, State state)
        {
            Name = name;
            EmployeesList = employeeList;
            Start = start;
            Deadline = deadline;
            State = state;
        }

        public override string ToString()
        {
            return $"{Name} ({State})";
        }
    }
}
