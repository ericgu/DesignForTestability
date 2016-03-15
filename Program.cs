using System;
using System.Collections.Generic;

namespace designIssueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Yucky yucky = new Yucky();
            var employeeFilter = CreateEmployeeFilter();
            var employees = Yucky.GetEmployees(employeeFilter, new FakeSqlConnection());

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }

        }

        private static EmployeeFilter CreateEmployeeFilter()
        {
            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ByName, "T");
            employeeFilter.ValidateEmployeeFilter();
            return employeeFilter;
        }
    }
}
