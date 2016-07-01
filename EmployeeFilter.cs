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

        public EmployeeCollection Filter(EmployeeCollection employeeCollection)
        {
            return employeeCollection.Filter(Matches);
        }
    }
}