using System;
using System.Collections.Generic;
using designIssueExample.DataAccess;

namespace designIssueExample.Tests.DataAccess
{
    internal class SimulateFakeSqlDriver : ISqlDriver
    {
        private readonly SimulateFakeSqlConnection _connection;

        public SimulateFakeSqlDriver()
        {
            _connection = new SimulateFakeSqlConnection();
        }

        private List<object[]> _simulatorData;

        public List<Employee> BuildSqlCommand(Query query, Func<ISqlDataReader, List<Employee>> load, int retry = 5)
        {
            List<Employee> result;
            using (var sqlCommand = new SimulateFakeSqlCommand(query.Value, _connection))
            {
                ISqlDataReader reader;
                var retryCount = retry;

                while (true)
                {
                    try
                    {
                        reader = sqlCommand.ExecuteReader();

                        PutTheFakeData(reader);
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

        private void PutTheFakeData(ISqlDataReader reader)
        {
            var simulateFakeSqlDataReader = (SimulateFakeSqlDataReader) reader;
            simulateFakeSqlDataReader.SimulatorReplaceData(_simulatorData);
        }

        public void SimulatorReplaceData(List<object[]> data)
        {
            _simulatorData = data;
        }
    }
}