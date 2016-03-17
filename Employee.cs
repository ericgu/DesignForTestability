using System;
namespace designIssueExample
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsSalaried { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", Id, Name, Age, IsSalaried);
        }
    }
}
