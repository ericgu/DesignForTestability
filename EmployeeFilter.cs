using System;

namespace designIssueExample
{
    public class EmployeeFilter
    {
        private EmployeeFilterType _employeeFilterType;
        private string _filter;

        public EmployeeFilter(EmployeeFilterType employeeFilterType, string filter)
        {
            _employeeFilterType = employeeFilterType;
            _filter = filter;
            if (_employeeFilterType == EmployeeFilterType.ByName && _filter == null)
            {
                throw new ArgumentNullException("filter");
            }
        }

        public class Employee
        {
            private string _name;
            private int _age;
            private bool _isSalaried;

            public Employee(string name, int age, bool isSalaried)
            {
                _name = name;
                _age = age;
                _isSalaried = isSalaried;
            }

            public string Name
            {
                get { return _name; }
            }

            public int Age
            {
                get { return _age; }
            }

            public bool IsSalaried
            {
                get { return _isSalaried; }
            }
        }

        public bool Matches(Employee employee)
        {
            switch (_employeeFilterType)
            {
                case EmployeeFilterType.ByName:
                    if (!employee.Name.StartsWith(_filter)) return false;
                    break;
                case EmployeeFilterType.ExemptOnly:
                    if (employee.Age < 40 || !employee.IsSalaried) return false;
                    break;
            }
            return true;
        }
    }
}