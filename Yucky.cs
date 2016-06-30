using System;
using System.Collections.Generic;

namespace designIssueExample
{
    class Yucky
    {
        public static EmployeeCollection GetEmployees(EmployeeFilter employeeFilter, FakeSqlConnection connection)
        {
            var employeeCollection = new EmployeeSource().FetchEmployees(connection);

            return employeeCollection.Filter(employeeFilter.Matches);
        }
    }
}
