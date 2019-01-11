namespace Employees.Data.Models
{
    public class Relation
    {
        public Project Project { get; set; }
        public Employee Employee { get; set; }
        public int WeeklyWorkHours { get; set; }

        public Relation(Project project, int weeklyWorkHours)
        {
            Project = project;
            WeeklyWorkHours = weeklyWorkHours;
        }

        public Relation(Employee employee, int weeklyWorkHours)
        {
            Employee = employee;
            WeeklyWorkHours = weeklyWorkHours;
        }
    }
}