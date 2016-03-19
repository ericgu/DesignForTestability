using System.Collections.Generic;

namespace designIssueExample
{
    public class EmployeeCollection
    {
        private List<Employee> _employeeCollection;

        public EmployeeCollection()
        {
            _employeeCollection = new List<Employee>();
        }

        public List<Employee> Items
        {
            get { return _employeeCollection; }
        }

        public static void AddEmployeeIfMatch(EmployeeFilter employeeFilter, string name, int age, bool isSalaried,
            EmployeeCollection employeeCollection, int id)
        {
            if (employeeFilter.Matches(name, age, isSalaried))
            {
                employeeCollection.Items.Add(new Employee
                {
                    Name = name,
                    Id = id,
                    Age = age,
                    IsSalaried = isSalaried
                });
            }
        }
    }
}