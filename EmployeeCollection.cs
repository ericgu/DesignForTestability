using System.Collections.Generic;

namespace designIssueExample
{
    class EmployeeCollection
    {
        private List<Employee> _employeeCollection;

        public List<Employee> CreateEmployeeCollection()
        {
            _employeeCollection = new List<Employee>();
            return _employeeCollection;
        }
    }
}