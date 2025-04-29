using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsTest.Service;

namespace MyApp.Tests.MSTest
{
    [TestClass] //  Marks this class as a test class for MSTest
    public class CalculatorTests
    {
        private Calculator _calculator;

        //  [TestInitialize] runs before every test method
        [TestInitialize]
        public void SetUp()
        {
            _calculator = new Calculator();
            TestContext.WriteLine("Test setup: Calculator created");
        }

        //  [TestCleanup] runs after every test method
        [TestCleanup]
        public void TearDown()
        {
            _calculator = null;
            TestContext.WriteLine("Test cleanup: Calculator destroyed");
        }

        //  Context for logging or shared data
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            // Arrange is done in SetUp()

            // Act
            var result = _calculator.Add(2, 3);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Add_WithZero_ReturnsSameNumber()
        {
            var result = _calculator.Add(0, 7);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Add_NegativeAndPositive_ReturnsCorrectSum()
        {
            var result = _calculator.Add(-4, 10);
            Assert.AreEqual(6, result);
        }
    }
}
