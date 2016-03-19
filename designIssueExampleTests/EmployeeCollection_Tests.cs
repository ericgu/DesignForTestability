using System;
using System.Linq;
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

            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ByName, "X");

            employeeCollection.AddEmployeeIfMatch(employeeFilter, new Employee() { Name = "Fred" });

            Assert.AreEqual(0, employeeCollection.Items.Count);
        }

        [TestMethod]
        public void When_I_create_an_EmployeeCollection_and_add_an_employee_that_does_match__its_in_the_items_collection()
        {
            EmployeeCollection employeeCollection = new EmployeeCollection();

            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ByName, "X");

            employeeCollection.AddEmployeeIfMatch(employeeFilter, new Employee() { Name = "Xavier" });

            Assert.AreEqual(1, employeeCollection.Items.Count);
            Assert.AreEqual("Xavier", employeeCollection.Items.First().Name);
        }

        [TestMethod]
        public void When_I_create_an_EmployeeCollection_and_add_two_employees_that_match_and_one_that_doesnt__the_matches_are_in_the_items_collection()
        {
            EmployeeCollection employeeCollection = new EmployeeCollection();

            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ByName, "X");

            employeeCollection.AddEmployeeIfMatch(employeeFilter, new Employee() { Name = "Xavier" });
            employeeCollection.AddEmployeeIfMatch(employeeFilter, new Employee() { Name = "Thor" });
            employeeCollection.AddEmployeeIfMatch(employeeFilter, new Employee() { Name = "Xerxes" });

            Assert.AreEqual(2, employeeCollection.Items.Count);
            Assert.AreEqual("Xavier", employeeCollection.Items.First().Name);
            Assert.AreEqual("Xerxes", employeeCollection.Items.Skip(1).First().Name);
        }
    }
}
