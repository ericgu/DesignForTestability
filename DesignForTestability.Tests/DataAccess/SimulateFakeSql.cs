using System;
using System.Collections.Generic;
using designIssueExample.DataAccess;

namespace designIssueExample.Tests.DataAccess
{
    public class SimulateFakeSqlConnection
    {
    }

    public class SimulateFakeSqlCommand : IDisposable
    {
        public SimulateFakeSqlCommand(string query, SimulateFakeSqlConnection connection)
        {

        }
        public void Dispose()
        {
        }

        internal SimulateFakeSqlDataReader ExecuteReader()
        {
            return new SimulateFakeSqlDataReader();
        }
    }

    public class SimulateFakeSqlDataReader : ISqlDataReader
    {
        List<object[]> m_data = new List<object[]>();
        object[] m_current;

        public SimulateFakeSqlDataReader()
        {
        }

        public void SimulatorReplaceData(List<object[]> data)
        {
            m_data = data;
        }

        public bool Read()
        {
            if (m_data.Count == 0)
            {
                return false;
            }

            m_current = m_data[0];
            m_data.RemoveAt(0);

            return true;
        }

        public int GetInt32(int index)
        {
            return (int)m_current[index];
        }

        public string GetString(int index)
        {
            return (string)m_current[index];
        }

        public bool GetBoolean(int index)
        {
            return (bool)m_current[index];
        }
    }
}
