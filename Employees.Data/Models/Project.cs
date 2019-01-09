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
        public DateTime Start { get; set; }
        public DateTime Deadline { get; set; }
        public State State { get; set; }

        public Project(string name, DateTime start, DateTime deadline)
        {
            Name = name;
            Start = start;
            Deadline = deadline;
            var timeSpanZero = new TimeSpan(0, 0, 0, 0, 0);
            State = (DateTime.Now - Start > timeSpanZero && DateTime.Now - Deadline < timeSpanZero) ? 
                State.Active :  (DateTime.Now - deadline > timeSpanZero) ?
                State.Finished : State.Planned;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Project;
            return item != null && Name == item.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} ({State})";
        }
    }
}
