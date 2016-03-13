using System;
using designIssueExample.DataAccess;

namespace designIssueExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var employeeRepository = new EmployeeRepository(new FakeSqlDriver());
            var employees = employeeRepository.GetEmployees(EmployeeFilterType.ByName, "T");

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}