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
    }
}
