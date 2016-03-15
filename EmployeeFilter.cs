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

        public bool Matches(string name, int age, bool isSalaried)
        {
            switch (_employeeFilterType)
            {
                case EmployeeFilterType.ByName:
                    if (!name.StartsWith(_filter)) return false;
                    break;
                case EmployeeFilterType.ExemptOnly:
                    if (age < 40 || !isSalaried) return false;
                    break;
            }
            return true;
        }
    }
}