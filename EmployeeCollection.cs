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

        public List<Employee> CreateEmployeeCollection()
        {
            return _employeeCollection;
        }
    }
}