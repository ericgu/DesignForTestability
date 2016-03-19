using System;
using System.Collections.Generic;

namespace designIssueExample
{
    class Yucky
    {
        private const int EmployeeIdColumnIndex = 0;
        private const int EmployeeNameColumnIndex = 1;
        private const int EmployeeAgeColumnIndex = 2;
        private const int EmployeeIsSalariedColumnIndex = 3;

        public static EmployeeCollection GetEmployees(EmployeeFilter employeeFilter, FakeSqlConnection connection)
        {
            string query = "select * from employee, employee_role inner join employee.Id == employee_role.EmployeeId";

            EmployeeCollection employeeCollection = new EmployeeCollection();
            using (FakeSqlCommand sqlCommand = new FakeSqlCommand(query, connection))
            {
                FakeSqlDataReader reader;
                int retryCount = 5;

                while (true)
                {
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                        break;
                    }
                    catch (Exception)
                    {
                        if (retryCount-- == 0) throw;
                    }
                }

                while (reader.Read())
                {
                    int id = reader.GetInt32(EmployeeIdColumnIndex);
                    string name = reader.GetString(EmployeeNameColumnIndex);
                    int age = reader.GetInt32(EmployeeAgeColumnIndex);
                    bool isSalaried = reader.GetBoolean(EmployeeIsSalariedColumnIndex);

                    var employee = new Employee
                    {
                        Name = name,
                        Id = id,
                        Age = age,
                        IsSalaried = isSalaried
                    };
                    employeeCollection.AddEmployee(employee);
                }
            }

            EmployeeCollection filteredEmployees = new EmployeeCollection();
            foreach (Employee employee in employeeCollection.Items)
            {
                filteredEmployees.AddEmployeeIfMatch(employeeFilter.Matches, employee);
            }

            return filteredEmployees;
        }
    }
}
