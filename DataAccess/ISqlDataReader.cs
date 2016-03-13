namespace designIssueExample.DataAccess
{
    public interface ISqlDataReader
    {
        bool Read();
        int GetInt32(int index);
        string GetString(int index);
        bool GetBoolean(int index);
    }
}