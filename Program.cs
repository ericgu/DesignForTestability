using System;

namespace designIssueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Yucky yucky = new Yucky();
            var employees = yucky.GetEmployees(new EmployeeFilter(EmployeeFilterType.ByName, "T"), new FakeSqlConnection());

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }

        }
    }
}
