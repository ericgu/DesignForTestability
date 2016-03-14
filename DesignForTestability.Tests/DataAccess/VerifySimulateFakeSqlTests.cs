using System.Collections.Generic;
using System.Linq;
using designIssueExample.DataAccess;
using NUnit.Framework;

namespace designIssueExample.Tests.DataAccess
{
    [TestFixture]
    [Category("slow test")]
    internal class VerifySimulateFakeSqlTests
    {
        [Test]
        public void GivenWhatRepositoryGetFromFakeSql_QueryViaRepository_ExpectResultIsTheSame()
        {
            var employeeRepositoryWithFakeSql = new EmployeeRepository(new FakeSqlDriver());
            var fakeSqlResult = employeeRepositoryWithFakeSql.GetEmployees(EmployeeFilterType.ByName, "T");
            var fakeSqlInternalData = fakeSqlResult.Select(employee => new object[] {employee.Id, employee.Name, employee.Age, employee.IsSalaried}).ToList();

            var simulateFakeSqlDriver = new SimulateFakeSqlDriver();
            simulateFakeSqlDriver.SimulatorReplaceData(fakeSqlInternalData);

            var employeeRepositoryWithSimulator= new EmployeeRepository(simulateFakeSqlDriver);
            var simulatorResult = employeeRepositoryWithSimulator.GetEmployees(EmployeeFilterType.ByName, "T");

            Assert.AreEqual(JustmakeThemAllString(simulatorResult), JustmakeThemAllString(fakeSqlResult));
        }

        private static string JustmakeThemAllString(IEnumerable<Employee> fakeSqlResult)
        {
            return fakeSqlResult.Aggregate("", (current, employee) => current + (employee + "\n"));
        }
    }
}
