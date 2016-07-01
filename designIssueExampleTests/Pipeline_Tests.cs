using System;
using designIssueExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace designIssueExampleTests
{
    [TestClass]
    public class Pipeline_Tests
    {
        [TestMethod]
        public void When_I_call_Process__it_properly_passes_data_through()
        {
            string result = null;

            Pipeline.Process<int, string>(
                () => 15,
                (number) => number.ToString(),
                (s) => { result = s; }
                );

            Assert.AreEqual("15", result);
        }
    }
}
