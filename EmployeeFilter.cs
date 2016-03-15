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

        public void ValidateEmployeeFilter()
        {
            if (EmployeeFilterType == EmployeeFilterType.ByName && Filter == null)
            {
                throw new ArgumentNullException("filter");
            }
        }

        public bool DoFilter(string name, int age, bool isSalaried)
        {
            switch (EmployeeFilterType)
            {
                case EmployeeFilterType.ByName:
                    if (!name.StartsWith(Filter)) return true;
                    break;
                case EmployeeFilterType.ExemptOnly:
                    if (age < 40 || !isSalaried) return true;
                    break;
            }
            return false;
        }
    }
}