﻿using System;
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
            FakeSqlConnection connection = new FakeSqlConnection();
            var collection = Yucky.GetEmployees(employeeFilter, new EmployeeSource(connection));
            var employees = (IEnumerable<Employee>) collection.Items;

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }

        }
    }
}
