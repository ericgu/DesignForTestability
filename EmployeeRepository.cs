using System;
using System.Collections.Generic;

namespace designIssueExample
{
    internal class EmployeeRepository
    {
        private const int EmployeeIdColumnIndex = 0;
        private const int EmployeeNameColumnIndex = 1;
        private const int EmployeeAgeColumnIndex = 2;
        private const int EmployeeIsSalariedColumnIndex = 3;

        private readonly FakeSqlConnection _connection;

        public EmployeeRepository(FakeSqlConnection connection)
        {
            _connection = connection;
        }


        public IEnumerable<Employee> GetEmployees(EmployeeFilterType employeeFilterType, string filter)
        {
            if (employeeFilterType == EmployeeFilterType.ByName && filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var query = "select * from employee, employee_role inner join employee.Id == employee_role.EmployeeId";

            var result = new List<Employee>();
            using (var sqlCommand = new FakeSqlCommand(query, _connection))
            {
                FakeSqlDataReader reader;
                var retryCount = 5;

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
                    var id = reader.GetInt32(EmployeeIdColumnIndex);
                    var name = reader.GetString(EmployeeNameColumnIndex);
                    var age = reader.GetInt32(EmployeeAgeColumnIndex);
                    var isSalaried = reader.GetBoolean(EmployeeIsSalariedColumnIndex);

                    switch (employeeFilterType)
                    {
                        case EmployeeFilterType.ByName:
                            if (!name.StartsWith(filter)) continue;
                            break;
                        case EmployeeFilterType.ExemptOnly:
                            if (age < 40 || !isSalaried) continue;
                            break;
                    }

                    result.Add(new Employee {Name = name, Id = id, Age = age, IsSalaried = isSalaried});
                }
            }

            return result;
        }
    }
}