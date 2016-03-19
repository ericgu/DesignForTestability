using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

            employeeCollection.Items.Add(new Employee { Name = "George", Age = 55 });

            Assert.AreEqual(1, employeeCollection.Items.Count);
            Assert.AreEqual("George", employeeCollection.Items[0].Name);
        }

        [TestMethod]
        public void When_I_create_an_EmployeeCollection_and_add_an_employee_that_does_not_match__the_Items_property_is_empty()
        {
            EmployeeCollection employeeCollection = new EmployeeCollection();

            employeeCollection.Add(new Employee() { Name = "Fred" });

            var result = employeeCollection.Filter((employee) => employee.Name.StartsWith("X"));

            Assert.AreEqual(0, result.Items.Count);
        }

        [TestMethod]
        public void When_I_create_an_EmployeeCollection_and_add_an_employee_that_does_match__its_in_the_items_collection()
        {
            EmployeeCollection employeeCollection = new EmployeeCollection();

            employeeCollection.Add(new Employee() { Name = "Xavier" });

            var result = employeeCollection.Filter((employee) => employee.Name.StartsWith("X"));

            Assert.AreEqual(1, result.Items.Count);
            Assert.AreEqual("Xavier", result.Items.First().Name);
        }

        [TestMethod]
        public void When_I_create_an_EmployeeCollection_and_add_two_employees_that_match_and_one_that_doesnt__the_matches_are_in_the_items_collection()
        {
            EmployeeCollection employeeCollection = new EmployeeCollection();

            employeeCollection.Add(new Employee() { Name = "Xavier" });
            employeeCollection.Add(new Employee() { Name = "Thor" });
            employeeCollection.Add(new Employee() { Name = "Xerxes" });

            var result = employeeCollection.Filter((employee) => employee.Name.StartsWith("X"));

            Assert.AreEqual(2, result.Items.Count);
            Assert.AreEqual("Xavier", result.Items.First().Name);
            Assert.AreEqual("Xerxes", result.Items.Skip(1).First().Name);
        }
    }
}
