using System.Collections.Generic;

namespace designIssueExample
{
    class EmployeeCollection
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

        public List<Employee> CreateEmployeeCollection()
        {
            return Items;
        }
    }
}