using System;
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

        public void Add(Employee employee)
        {
            Items.Add(employee);
        }

        public EmployeeCollection Filter(Func<Employee, bool> filter)
        {
            EmployeeCollection filteredEmployees = new EmployeeCollection();
            foreach (Employee employee in Items)
            {
                if (filter(employee))
                {
                    filteredEmployees.Items.Add(employee);
                }
            }
            return filteredEmployees;
        }
    }
}