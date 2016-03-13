using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designIssueExample
{
    internal class FakeSqlDriver
    {
        private FakeSqlConnection _connection;
        public FakeSqlDriver()
        {
            _connection = new FakeSqlConnection();
        }

        public List<Employee> BuildSqlCommand(Query query, Func<ISqlDataReader, List<Employee>> readFromSqlResult ,int retry = 5)
        {

            var result = new List<Employee>();
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
                result = readFromSqlResult(reader);
            }
            return result;
        }

    }

    internal class Query
    {
        public string Value { get; }
        public Query( string value )
        {
            Value = value;
        }
    }
}
