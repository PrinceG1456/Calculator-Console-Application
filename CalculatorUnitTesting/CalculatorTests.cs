using System;
using System.IO;
using CalculatorConsoleApplication;
using NUnit.Framework;

namespace CalculatorUnitTesting
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void CalculateSum_NoParams_ReturnZero()
        {
            Assert.AreEqual("0", Calculator.Calculate(new string[] { "sum" }));

        }

        [Test]
        public void CalculateSum_SingleParams_ReturnsTheSameNumber()
        {
            Assert.AreEqual("3", Calculator.Calculate(new string[] { "sum", "3" }));

        }

        [Test]
        public void CalculateSum_TwoParams_ReturnsTheSum()
        {
            Assert.AreEqual("7", Calculator.Calculate(new string[] { "sum", "3,4" }));
        }

        [Test]
        public void CalculateSum_NParams_ReturnsTheSumOfN()
        {
            Assert.AreEqual("133", Calculator.Calculate(new string[] { "sum", "4,7,3,4,7,3,5,6,7,4,3,2,5,7,5,3,4,6,7,8,9,5,5,5,4,3,2" }));
        }

        [Test]
        public void CalculateAdd_ParamsWithNewlineSeparator_ReturnsTheSumOfN()
        {
            Assert.AreEqual("9", Calculator.Calculate(new string[] { "add", "2\n3,4" }));
        }

        [Test]
        public void CalculateAdd_ParamsWithDelimiters_ReturnsTheSum()
        {
            Assert.AreEqual("12", Calculator.Calculate(new string[] { "add", "\\;\\3;4;5" }));
        }

        [Test]
        public void CalculateAdd_ParamsWithNegativeNumbers_ReturnsErrorWithTheNegativeNumbers()
        {
            Assert.AreEqual("Negative numbers [-3,-2] not allowed.", Calculator.Calculate(new string[] { "add", "\\,\\2,7,-3,5,-2" }));
        }

        [Test]
        public void CalculateAdd_ParamsWithNumbersAbove1000_ReturnsSumSkippingTheNumbersAbove1000()
        {
            Assert.AreEqual("50", Calculator.Calculate(new string[] { "add", "10,20,1010,20" }));
        }

        [Test]
        public void CalculateMultiply_ParamsWithTwoNumbers_ReturnsItsMultiplication()
        {
            Assert.AreEqual("6", Calculator.Calculate(new string[] { "multiply", "2,3" }));
        }


        [Test]
        public void CalculateMultiply_NParams_ReturnsMultiplicatioinOfN()
        {
            Assert.AreEqual("336", Calculator.Calculate(new string[] { "multiply", "4,7,3,4" }));
        }

        [Test]
        public void CalculateMultiply_ParamsWithNewlineSeparator_ReturnsMultiplicatonOfN()
        {
            Assert.AreEqual("24", Calculator.Calculate(new string[] { "multiply", "2\n3,4" }));
        }

        [Test]
        public void CalculateMultiply_ParamsWithDelimiters_ReturnsMultiplication()
        {
            Assert.AreEqual("60", Calculator.Calculate(new string[] { "multiply", "\\;\\3;4;5" }));
        }

        [Test]
        public void CalculateMultiply_ParamsWithNegativeNumbers_ReturnsErrorWithTheNegativeNumbers()
        {
            Assert.AreEqual("Negative numbers [-3,-2] not allowed.", Calculator.Calculate(new string[] { "multiply", "\\,\\2,7,-3,5,-2" }));
        }

        [Test]
        public void CalculateMultiply_ParamsWithNumbersAbove1000_ReturnsMultiplicationValueSkippingTheNumbersAbove1000()
        {
            Assert.AreEqual("4000", Calculator.Calculate(new string[] { "multiply", "10,20,1010,20" }));

        }

    }
}
