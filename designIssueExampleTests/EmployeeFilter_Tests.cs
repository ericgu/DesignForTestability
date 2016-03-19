using System;
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

            Assert.IsFalse(employeeFilter.Matches(new EmployeeFilter.Employee("Fred", 42, false)));
        }

        [TestMethod]
        public void When_I_create_a_named_filter_and_pass_values_that_do_match__Matches_returns_true()
        {
            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ByName, "A");

            Assert.IsTrue(employeeFilter.Matches(new EmployeeFilter.Employee("Alan", 42, false)));
        }

        [TestMethod]
        public void When_I_create_a_exempt_filter_with_an_age_that_is_too_young_and_salaried__Matches_returns_false()
        {
            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ExemptOnly, null);

            Assert.IsFalse(employeeFilter.Matches(new EmployeeFilter.Employee("Alan", 39, true)));
        }

        [TestMethod]
        public void When_I_create_a_exempt_filter_with_an_age_that_is_old_enough_and_not_salaried__Matches_returns_false()
        {
            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ExemptOnly, null);

            Assert.IsFalse(employeeFilter.Matches(new EmployeeFilter.Employee("Alan", 40, false)));
        }
        [TestMethod]
        public void When_I_create_a_exempt_filter_with_an_age_that_is_old_enough_and_is_salaried__Matches_returns_true()
        {
            EmployeeFilter employeeFilter = new EmployeeFilter(EmployeeFilterType.ExemptOnly, null);

            Assert.IsTrue(employeeFilter.Matches(new EmployeeFilter.Employee("Alan", 40, true)));
        }
    }
}
