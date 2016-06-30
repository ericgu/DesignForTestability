using System;
using System.Collections.Generic;

namespace designIssueExample
{
    class Yucky
    {
        private const int EmployeeIdColumnIndex = 0;
        private const int EmployeeNameColumnIndex = 1;
        private const int EmployeeAgeColumnIndex = 2;
        private const int EmployeeIsSalariedColumnIndex = 3;

        public static EmployeeCollection GetEmployees(EmployeeFilter employeeFilter, FakeSqlConnection connection)
        {
            var employeeCollection = EmployeeSource.FetchEmployees(connection);

            return employeeCollection.Filter(employeeFilter.Matches);
        }
    }
}
