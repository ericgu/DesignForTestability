using System;
using System.Collections.Generic;

namespace designIssueExample.DataAccess
{
    internal interface ISqlDriver
    {
        List<Employee> BuildSqlCommand(Query query, Func<ISqlDataReader, List<Employee>> load ,int retry = 5);
    }
}