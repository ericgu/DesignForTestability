using System;
using System.Collections.Generic;

namespace designIssueExample
{
    public class FakeSqlConnection
    {
    }

    public class FakeSqlCommand : IDisposable
    {
        public FakeSqlCommand(string query, FakeSqlConnection connection)
        {

        }
        public void Dispose()
        {
        }

        internal FakeSqlDataReader ExecuteReader()
        {
            return new FakeSqlDataReader();
        }
    }

    public class FakeSqlDataReader : ISqlDataReader
    {
        List<object[]> m_data = new List<object[]>();
        object[] m_current;

        public FakeSqlDataReader()
        {
            m_data.Add(new object[] { 35323, "Fred Flintstone", 42, true });
            m_data.Add(new object[] { 35323, "Barney Rubble", 38, true });
            m_data.Add(new object[] { 35323, "Ted theRed", 16, false });
            m_data.Add(new object[] { 35323, "Tina Turnbull", 18, false });
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
