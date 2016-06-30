using System;
using System.Collections.Generic;

namespace designIssueExample
{
    class Yucky
    {
        public static EmployeeCollection GetEmployees(EmployeeFilter employeeFilter, EmployeeSource employeeSource)
        {
            var employeeCollection = employeeSource.FetchEmployees();

            return employeeCollection.Filter(employeeFilter.Matches);
        }
    }
}
