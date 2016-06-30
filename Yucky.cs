using System;
using System.Collections.Generic;

namespace designIssueExample
{
    class Yucky
    {
        public static EmployeeCollection GetEmployees(EmployeeFilter employeeFilter, EmployeeSource employeeSource)
        {
            return employeeSource.FetchEmployees().Filter(employeeFilter.Matches);
        }
    }
}
