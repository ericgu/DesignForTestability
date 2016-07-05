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

            FilterEmployeesAndWriteToConsoleProcedural(employeeSource, employeeFilter);
            FilterEmployeesAndWriteToConsolePipeline(employeeSource, employeeFilter);
        }

        private static void FilterEmployeesAndWriteToConsoleProcedural(EmployeeSource employeeSource, EmployeeFilter employeeFilter)
        {
            var collection = employeeSource.FetchEmployees().Filter(employeeFilter.Matches);

            WriteToConsole(collection);
        }

        private static void FilterEmployeesAndWriteToConsolePipeline(EmployeeSource employeeSource, EmployeeFilter employeeFilter)
        {
Pipeline.Process(
    employeeSource.FetchEmployees,
    employeeFilter.Filter,
    WriteToConsole);
        }

        private static void WriteToConsole(EmployeeCollection collection)
        {
            foreach (Employee employee in collection.Items)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
