using Demo2.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo2Test.Controllers
{
    [TestClass]
    public class ValuesControllerTests
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void TestMethod1()
        {
        }

        private ValuesController CreateValuesController()
        {
            return new ValuesController();
        }
    }
}