using Demo.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Demo.UnitTests.Controllers
{
    [TestClass]
    public class ValuesControllerTests
    {
        private MockRepository mockRepository;
        
        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);            
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Get()
        {
            ValuesController valuesController = CreateValuesController();

            var results = valuesController.Get().ToList();

            Assert.AreEqual(results[0], "value1");
            Assert.AreEqual(results[1], "value2");
            Assert.AreEqual(results[2], "(145, 9)");
        }

        private ValuesController CreateValuesController()
        {
            return new ValuesController();
        }
    }
}