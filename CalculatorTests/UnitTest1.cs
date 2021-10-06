using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testhomework;
using hm2;
using ClassLibrary;

namespace CalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSum()
        {
            Assert.AreEqual(2, hm2.Calculator.Calculate(1, 1, hm2.Calculator.Operation.Plus));
        }
        
        [TestMethod]
        public void TestMinus()
        {
            Assert.AreEqual(1, hm2.Calculator.Calculate(3, 2, hm2.Calculator.Operation.Minus));
        }

        [TestMethod]
        public void TestMultiply()
        {
            Assert.AreEqual(5, hm2.Calculator.Calculate(1, 5, hm2.Calculator.Operation.Multiply));
        }

        [TestMethod]
        public void TestDivide()
        {
            Assert.AreEqual(5, hm2.Calculator.Calculate(25, 5, hm2.Calculator.Operation.Divide));
        }

        [TestMethod]
        public void TestUnknownOperation()
        {
            try
            {
                hm2.Calculator.Calculate(1, 5, hm2.Calculator.Operation.Unknown);
            } catch (Exception exception) {
                Assert.AreEqual("Operation is unknown", exception.Message);
            }
        }

        [TestMethod]
        public void TestDivideByZero()
        {
            try
            {
                hm2.Calculator.Calculate(1, 0, hm2.Calculator.Operation.Divide);
            } catch (Exception exception) {
                Assert.AreEqual("Num2 is zero", exception.Message);
            }
        }

        [TestMethod]
        public void TestParseNumber()
        {
            var resultOfParse = hm2.Parser.ParseNumber("1");
            Assert.AreEqual(1, resultOfParse);

            try
            {
                var resultOfParse1 = hm2.Parser.ParseNumber("a");
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Value is not integer", exception.Message);
            }
        }

        [TestMethod]
        public void TestParseOperation()
        {
            var resultOfParse = hm2.Parser.ParseOperation("+");
            Assert.AreEqual(hm2.Calculator.Operation.Plus, resultOfParse);
            
            var resultOfParse2 = hm2.Parser.ParseOperation("-");
            Assert.AreEqual(hm2.Calculator.Operation.Minus, resultOfParse2);
            
            var resultOfParse3 = hm2.Parser.ParseOperation("*");
            Assert.AreEqual(hm2.Calculator.Operation.Multiply, resultOfParse3);

            var resultOfParse4 = hm2.Parser.ParseOperation("/");
            Assert.AreEqual(hm2.Calculator.Operation.Divide, resultOfParse4);

            try
            {
                var resultOfParse1 = hm2.Parser.ParseOperation("a");
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Operation is not correct", exception.Message);
            }
        }
    }
}