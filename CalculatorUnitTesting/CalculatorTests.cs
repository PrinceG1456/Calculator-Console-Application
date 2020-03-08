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
            string consoleOutput = null;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Calculator.Calculate(new string[] { "sum" });

                consoleOutput = stringWriter.ToString().Replace(System.Environment.NewLine, string.Empty);
            }

            Assert.AreEqual("0", consoleOutput);

        }

        [Test]
        public void CalculateSum_SingleParams_ReturnsTheSameNumber()
        {
            string consoleOutput = null;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Calculator.Calculate(new string[] { "sum", "3" });

                consoleOutput = stringWriter.ToString().Replace(System.Environment.NewLine, string.Empty);
            }

            Assert.AreEqual("3", consoleOutput);

        }

        [Test]
        public void CalculateSum_TwoParams_ReturnsTheSum()
        {
            string consoleOutput = null;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Calculator.Calculate(new string[] { "sum", "3,4" });

                consoleOutput = stringWriter.ToString().Replace(System.Environment.NewLine, string.Empty);
            }

            Assert.AreEqual("7", consoleOutput);

        }

        [Test]
        public void CalculateSum_NParams_ReturnsTheSumOfN()
        {
            string consoleOutput = null;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Calculator.Calculate(new string[] { "sum", "4,7,3,4,7,3,5,6,7,4,3,2,5,7,5,3,4,6,7,8,9,5,5,5,4,3,2" });

                consoleOutput = stringWriter.ToString().Replace(System.Environment.NewLine, string.Empty);
            }

            Assert.AreEqual("133", consoleOutput);

        }

        [Test]
        public void CalculateAdd_ParamsWithNewlineSeparator_ReturnsTheSumOfN()
        {
            string consoleOutput = null;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Calculator.Calculate(new string[] { "add", "2\n3,4" });

                consoleOutput = stringWriter.ToString().Replace(System.Environment.NewLine, string.Empty);
            }

            Assert.AreEqual("9", consoleOutput);

        }

        [Test]
        public void CalculateAdd_ParamsWithDelimiters_ReturnsTheSum()
        {
            string consoleOutput = null;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Calculator.Calculate(new string[] { "add", "\\;\\3;4;5" });

                consoleOutput = stringWriter.ToString().Replace(System.Environment.NewLine, string.Empty);
            }

            Assert.AreEqual("12", consoleOutput);

        }

        [Test]
        public void CalculateAdd_ParamsWithNegativeNumbers_ReturnsErrorWithTheNegativeNumbers()
        {
            string consoleOutput = null;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Calculator.Calculate(new string[] { "add", "\\,\\2,7,-3,5,-2" });

                consoleOutput = stringWriter.ToString().Replace(System.Environment.NewLine, string.Empty);
            }

            Assert.AreEqual("Negative numbers [-3,-2] not allowed.", consoleOutput);

        }

        [Test]
        public void CalculateAdd_ParamsWithNumbersAbove1000_ReturnsSumSkippingTheNumbersAbove1000()
        {
            string consoleOutput = null;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Calculator.Calculate(new string[] { "add", "10,20,1010,20" });

                consoleOutput = stringWriter.ToString().Replace(System.Environment.NewLine, string.Empty);
            }

            Assert.AreEqual("50", consoleOutput);

        }

        [Test]
        public void CalculateMultiply_ParamsWithTwoNumbers_ReturnsItsMultiplication()
        {
            string consoleOutput = null;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Calculator.Calculate(new string[] { "multiply", "2,3" });

                consoleOutput = stringWriter.ToString().Replace(System.Environment.NewLine, string.Empty);
            }

            Assert.AreEqual("6", consoleOutput);

        }


        [Test]
        public void CalculateMultiply_NParams_ReturnsMultiplicatioinOfN()
        {
            string consoleOutput = null;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Calculator.Calculate(new string[] { "multiply", "4,7,3,4" });

                consoleOutput = stringWriter.ToString().Replace(System.Environment.NewLine, string.Empty);
            }

            Assert.AreEqual("336", consoleOutput);

        }

        [Test]
        public void CalculateMultiply_ParamsWithNewlineSeparator_ReturnsMultiplicatonOfN()
        {
            string consoleOutput = null;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Calculator.Calculate(new string[] { "multiply", "2\n3,4" });

                consoleOutput = stringWriter.ToString().Replace(System.Environment.NewLine, string.Empty);
            }

            Assert.AreEqual("24", consoleOutput);

        }

        [Test]
        public void CalculateMultiply_ParamsWithDelimiters_ReturnsMultiplication()
        {
            string consoleOutput = null;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Calculator.Calculate(new string[] { "multiply", "\\;\\3;4;5" });

                consoleOutput = stringWriter.ToString().Replace(System.Environment.NewLine, string.Empty);
            }

            Assert.AreEqual("60", consoleOutput);

        }

        [Test]
        public void CalculateMultiply_ParamsWithNegativeNumbers_ReturnsErrorWithTheNegativeNumbers()
        {
            string consoleOutput = null;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Calculator.Calculate(new string[] { "multiply", "\\,\\2,7,-3,5,-2" });

                consoleOutput = stringWriter.ToString().Replace(System.Environment.NewLine, string.Empty);
            }

            Assert.AreEqual("Negative numbers [-3,-2] not allowed.", consoleOutput);

        }

        [Test]
        public void CalculateMultiply_ParamsWithNumbersAbove1000_ReturnsMultiplicationValueSkippingTheNumbersAbove1000()
        {
            string consoleOutput = null;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Calculator.Calculate(new string[] { "multiply", "10,20,1010,20" });

                consoleOutput = stringWriter.ToString().Replace(System.Environment.NewLine, string.Empty);
            }

            Assert.AreEqual("4000", consoleOutput);

        }

    }
}
