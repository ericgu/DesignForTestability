using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace designIssueExample.Tests
{
    [TestFixture]
    class EmployeeTests
    {
        [Test]
        // LOL the only domain test
        public void GivenEmployeeData_ConvertToString_ExpectFormatIsCorrect()
        {
            // Arrange
            var e = new Employee {Age = 42, Id = 4242, IsSalaried = true, Name = "Hue Hue"};
            // Act
            var result = e.ToString();
            // Assert
            Assert.AreEqual(result, "4242 Hue Hue 42 True");
        }
    }
}
