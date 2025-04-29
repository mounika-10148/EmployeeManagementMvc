using MsTest.Service;
using MsTest.Service;

namespace TestMyApp
{
    //NUnit Test Framework

    [TestFixture] //marks the class as test class
    public class Tests
    {
        private Calculator calculator;

        [SetUp] //runs before each test
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test] //test the logic 
        public void Test1()
        {
            int result = calculator.Add(3, 4);

            Assert.That(result, Is.EqualTo(7)); //checks actual output matches with the expected output
        }
    }
}