using System;
using Xunit;

using MsTest.Service; // This assumes your Calculator class is in this namespace

namespace MsTest.Tests.XUnit
{
    // Shared fixture class (used for one-time setup across multiple test classes)
    public class CalculatorFixture : IDisposable
    {
        // Public calculator instance to be used in tests
        public Calculator Calculator { get; private set; }

        // Constructor => runs once when fixture is created (before any tests)
        public CalculatorFixture()
        {
            Console.WriteLine("One-time setup: Creating Calculator instance");
            Calculator = new Calculator();
        }

        // Dispose => runs once after all tests using this fixture are done
        public void Dispose()
        {
            Console.WriteLine("One-time cleanup: Disposing Calculator fixture");
            // Put any cleanup logic here (not needed in this simple example)
        }
    }

    // Test class using the fixture  
    // Constructor runs before EACH test  
    // Dispose() runs after EACH test  
    public class CalculatorTests : IClassFixture<CalculatorFixture>, IDisposable
    {
        private readonly CalculatorFixture _fixture;
        private readonly Calculator _calculator;

        // Constructor => runs before each [Fact] test method  
        public CalculatorTests(CalculatorFixture fixture)
        {
            Console.WriteLine("Test setup: Starting a test");
            _fixture = fixture;
            _calculator = _fixture.Calculator; // Access shared Calculator instance  
        }

        // Dispose => runs after each test method  
        public void Dispose()
        {
            Console.WriteLine("Test cleanup: Finished a test");
        }

        // Test 1: Adding two positive numbers  
        [Fact]
        public void Add_TwoPositiveNumbers_ReturnsSum()
        {
            var result = _calculator.Add(2, 3);
            Assert.Equal(5, result); // Asserts 2 + 3 = 5  
        }

        // Test 2: Adding zero  
        [Fact]
        public void Add_WithZero_ReturnsSameNumber()
        {
            var result = _calculator.Add(0, 10);
            Assert.Equal(10, result);
        }

        // Test 3: Adding negative and positive numbers  
        [Fact]
        public void Add_NegativeAndPositive_ReturnsCorrectResult()
        {
            var result = _calculator.Add(-5, 3);
            Assert.Equal(-2, result);
        }
    }
}