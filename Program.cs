using System;
using System.Collections.Generic;

namespace designIssueExample
{
    class Program
    {
        private static void Main(string[] args)
        {
            EmployeeRepository yucky = new EmployeeRepository(new FakeSqlConnection());
            var employees = yucky.GetEmployees(EmployeeFilterType.ByName, "T");

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
            //EmployeeRepository
        }

    }
}
