using System;
using designIssueExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace designIssueExampleTests
{
    [TestClass]
    public class EmployeeCollection_Tests
    {
        [TestMethod]
        public void When_I_create_an_EmployeeCollection_and_add_an_employee_to_it__the_employee_is_in_the_Items_property()
        {
            EmployeeCollection employeeCollection = new EmployeeCollection();

            Assert.AreEqual(0, employeeCollection.Items.Count);

            employeeCollection.Items.Add(new Employee {Name = "George", Age = 55});

            Assert.AreEqual(1, employeeCollection.Items.Count);
            Assert.AreEqual("George", employeeCollection.Items[0].Name);
        }
    }
}
