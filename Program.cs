using System;
using System.Collections.Generic;

namespace designIssueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Yucky yucky = new Yucky();
            EmployeeFilter employeeFilter1 = new EmployeeFilter(EmployeeFilterType.ByName, "T");
            var employeeFilter = employeeFilter1;
            var employees = Yucky.GetEmployees(employeeFilter, new FakeSqlConnection());

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }

        }
    }
}
