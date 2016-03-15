using System;
using System.Collections.Generic;

namespace designIssueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Yucky yucky = new Yucky();
            var employeeFilter = EmployeeFilter.CreateEmployeeFilter(EmployeeFilterType.ByName, "T");
            var employees = Yucky.GetEmployees(employeeFilter, new FakeSqlConnection());

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }

        }
    }
}
