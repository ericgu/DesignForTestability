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

        public EmployeeFilterType EmployeeFilterType
        {
            get { return _employeeFilterType; }
        }

        public string Filter
        {
            get { return _filter; }
        }

        public static void ValidateEmployeeFilter(EmployeeFilter employeeFilter)
        {
            if (employeeFilter.EmployeeFilterType == EmployeeFilterType.ByName && employeeFilter.Filter == null)
            {
                throw new ArgumentNullException("filter");
            }
        }

        public static bool DoFilter(EmployeeFilter employeeFilter, string name, int age, bool isSalaried)
        {
            switch (employeeFilter.EmployeeFilterType)
            {
                case EmployeeFilterType.ByName:
                    if (!name.StartsWith(employeeFilter.Filter)) return true;
                    break;
                case EmployeeFilterType.ExemptOnly:
                    if (age < 40 || !isSalaried) return true;
                    break;
            }
            return false;
        }
    }
}