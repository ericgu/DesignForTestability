using System;
using System.Linq;
using designIssueExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace designIssueExampleTests
{
    [TestClass]
    public class EmployeeFilter_Tests
    {
        [TestMethod]
        public void When_I_create_a_named_filter_with_a_null_string__it_throws_an_exception()
        {
            try
            {
                EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ByName, null);
                Assert.Fail("Missing Exception");
            }
            catch (Exception)
            {
            }
        }

        [TestMethod]
        public void When_I_create_a_named_filter_and_pass_values_that_dont_match__Matches_returns_false()
        {
            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ByName, "A");

            Assert.IsFalse(employeeFilter.Matches(CreateEmployee("Fred", 42, false)));
        }

        private static Employee CreateEmployee(string name, int age, bool isSalaried)
        {
            return new Employee { Name = name, Age = age, IsSalaried = isSalaried};
        }

        [TestMethod]
        public void When_I_create_a_named_filter_and_pass_values_that_do_match__Matches_returns_true()
        {
            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ByName, "A");

            Assert.IsTrue(employeeFilter.Matches(CreateEmployee("Alan", 42, false)));
        }

        [TestMethod]
        public void When_I_create_a_exempt_filter_with_an_age_that_is_too_young_and_salaried__Matches_returns_false()
        {
            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ExemptOnly, null);

            Assert.IsFalse(employeeFilter.Matches(CreateEmployee("Alan", 39, true)));
        }

        [TestMethod]
        public void When_I_create_a_exempt_filter_with_an_age_that_is_old_enough_and_not_salaried__Matches_returns_false()
        {
            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ExemptOnly, null);

            Assert.IsFalse(employeeFilter.Matches(CreateEmployee("Alan", 40, false)));
        }
        [TestMethod]
        public void When_I_create_a_exempt_filter_with_an_age_that_is_old_enough_and_is_salaried__Matches_returns_true()
        {
            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ExemptOnly, null);

            Assert.IsTrue(employeeFilter.Matches(CreateEmployee("Alan", 40, true)));
        }

        [TestMethod]
        public void When_I_create_a_named_filter_and_filter_a_collection__It_returns_the_matching_employees()
        {
            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ByName, "A");

            EmployeeCollection employees = new EmployeeCollection();
            employees.Add(CreateEmployee("Fred", 42, false));
            employees.Add(CreateEmployee("Alan", 42, false));
            employees.Add(CreateEmployee("Zelda", 42, false));

            var filtered = employeeFilter.Filter(employees);

            Assert.AreEqual(1, filtered.Items.Count);
            Assert.AreEqual("Alan", filtered.Items.First().Name);
        }
    }
}
