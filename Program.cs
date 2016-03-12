using System;

namespace designIssueExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var employeeRepository = new EmployeeRepository(new FakeSqlConnection());
            var employees = employeeRepository.GetEmployees(EmployeeFilterType.ByName, "T");

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}