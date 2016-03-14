using System.Collections.Generic;
using System.Linq;
using designIssueExample.DataAccess;
using NUnit.Framework;

namespace designIssueExample.Tests.DataAccess
{
    [TestFixture]
    internal class EmployeeRepositoryTests
    {
        [Test]
        public void GivenDriver_QueryASpecificEmployee_ExpectGetCorrectEmployeeObject()
        {
            // Arrange
            var fakeSqlInternalData = new List<object[]>
            {
                new object[] {35323, "Fred Flintstone", 42, true},
                new object[] {35323, "Barney Rubble", 38, true},
                new object[] {35323, "Ted theRed", 16, false},
                new object[] {35323, "Tina Turnbull", 18, false}
            };

            var simulateFakeSqlDriver = new SimulateFakeSqlDriver();
            simulateFakeSqlDriver.SimulatorReplaceData(fakeSqlInternalData);

            var employeeRepositoryWithSimulator = new EmployeeRepository(simulateFakeSqlDriver);

            // Act
            var simulatorResult = employeeRepositoryWithSimulator.GetEmployees(EmployeeFilterType.ByName, "B");

            // Assert
            Assert.AreEqual("Barney Rubble", simulatorResult.First().Name);
            Assert.AreEqual(38, simulatorResult.First().Age);
            Assert.AreEqual(true, simulatorResult.First().IsSalaried);
        }
    }
}
