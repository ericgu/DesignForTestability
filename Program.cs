using System;

namespace designIssueExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var yucky = new EmployeeRepository(new FakeSqlConnection());
            var employees = yucky.GetEmployees(EmployeeFilterType.ByName, "T");

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}