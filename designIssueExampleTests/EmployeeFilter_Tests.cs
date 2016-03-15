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

            Assert.IsFalse(employeeFilter.Matches("Fred", 42, false));
        }
    }
}
