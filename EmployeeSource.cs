using System;

namespace designIssueExample
{
    class EmployeeSource
    {
        public static EmployeeCollection FetchEmployees(FakeSqlConnection connection, EmployeeSource employeeSource)
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
                    int id = reader.GetInt32(Yucky.EmployeeIdColumnIndex);
                    string name = reader.GetString(Yucky.EmployeeNameColumnIndex);
                    int age = reader.GetInt32(Yucky.EmployeeAgeColumnIndex);
                    bool isSalaried = reader.GetBoolean(Yucky.EmployeeIsSalariedColumnIndex);

                    var employee = new Employee
                    {
                        Name = name,
                        Id = id,
                        Age = age,
                        IsSalaried = isSalaried
                    };
                    employeeCollection.Add(employee);
                }
            }
            return employeeCollection;
        }
    }
}