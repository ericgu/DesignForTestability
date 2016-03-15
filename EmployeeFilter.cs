using System;

namespace designIssueExample
{
    internal class EmployeeFilter
    {
        private EmployeeFilterType _employeeFilterType;
        private string _filter;

        public EmployeeFilter(EmployeeFilterType employeeFilterType, string filter)
        {
            _employeeFilterType = employeeFilterType;
            _filter = filter;
        }

        public void ValidateEmployeeFilter()
        {
            if (_employeeFilterType == EmployeeFilterType.ByName && _filter == null)
            {
                throw new ArgumentNullException("filter");
            }
        }

        public static bool Matches(EmployeeFilter employeeFilter, string name, int age, bool isSalaried)
        {
            switch (employeeFilter._employeeFilterType)
            {
                case EmployeeFilterType.ByName:
                    if (!name.StartsWith(employeeFilter._filter)) return false;
                    break;
                case EmployeeFilterType.ExemptOnly:
                    if (age < 40 || !isSalaried) return false;
                    break;
            }
            return true;
        }

        public static EmployeeFilter CreateEmployeeFilter()
        {
            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ByName, "T");
            employeeFilter.ValidateEmployeeFilter();
            return employeeFilter;
        }
    }
}