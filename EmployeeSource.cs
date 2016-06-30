using System;

namespace designIssueExample
{
    class EmployeeSource
    {
        private FakeSqlConnection _connection;

        public EmployeeSource(FakeSqlConnection connection)
        {
            _connection = connection;
        }

        public EmployeeCollection FetchEmployees() 
        {
            string query = "select * from employee, employee_role inner join employee.Id == employee_role.EmployeeId";

            EmployeeCollection employeeCollection = new EmployeeCollection();
            using (FakeSqlCommand sqlCommand = new FakeSqlCommand(query, _connection))
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
                    employeeCollection.Add(employee);
                }
            }
            return employeeCollection;
        }

        private const int EmployeeIdColumnIndex = 0;
        private const int EmployeeNameColumnIndex = 1;
        private const int EmployeeAgeColumnIndex = 2;
        private const int EmployeeIsSalariedColumnIndex = 3;
    }
}