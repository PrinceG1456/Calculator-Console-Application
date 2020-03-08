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

    }
}
