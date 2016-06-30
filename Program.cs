using System;
using System.Collections.Generic;

namespace designIssueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeFilter = new EmployeeFilter(EmployeeFilterType.ByName, "T");
            FakeSqlConnection connection = new FakeSqlConnection();
            var employeeSource = new EmployeeSource(connection);

            var collection = employeeSource.FetchEmployees().Filter(employeeFilter.Matches);

            foreach (Employee employee in collection.Items)
            {
                Console.WriteLine(employee);
            }

        }
    }
}
