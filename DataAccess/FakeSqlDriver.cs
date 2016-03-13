using System;
using System.Collections.Generic;

namespace designIssueExample.DataAccess
{
    internal class FakeSqlDriver : ISqlDriver
    {
        private readonly FakeSqlConnection _connection;
        public FakeSqlDriver()
        {
            _connection = new FakeSqlConnection();
        }

        public List<Employee> BuildSqlCommand(Query query, Func<ISqlDataReader, List<Employee>> load ,int retry = 5)
        {

            List<Employee> result;
            using (var sqlCommand = new FakeSqlCommand(query.Value, _connection))
            {
                ISqlDataReader reader;
                var retryCount = retry;

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
                result = load(reader);
            }
            return result;
        }

    }
}
