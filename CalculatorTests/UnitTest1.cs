using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testhomework;
<<<<<<< Updated upstream
using hm2;
=======
using ClassLibrary;
using ClassLibrary;
>>>>>>> Stashed changes

namespace CalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSum()
        {
            Assert.AreEqual(2, ClassLibrary.Calculator.Calculate(1, 1, ClassLibrary.Calculator.Operation.Plus));
        }
        
        [TestMethod]
        public void TestMinus()
        {
            Assert.AreEqual(1, ClassLibrary.Calculator.Calculate(3, 2, ClassLibrary.Calculator.Operation.Minus));
        }

        [TestMethod]
        public void TestMultiply()
        {
            Assert.AreEqual(5, ClassLibrary.Calculator.Calculate(1, 5, ClassLibrary.Calculator.Operation.Multiply));
        }

        [TestMethod]
        public void TestDivide()
        {
            Assert.AreEqual(5, ClassLibrary.Calculator.Calculate(25, 5, ClassLibrary.Calculator.Operation.Divide));
        }

        [TestMethod]
        public void TestUnknownOperation()
        {
            try
            {
                ClassLibrary.Calculator.Calculate(1, 5, ClassLibrary.Calculator.Operation.Unknown);
            } catch (Exception exception) {
                Assert.AreEqual("Operation is unknown", exception.Message);
            }
        }

        [TestMethod]
        public void TestDivideByZero()
        {
            try
            {
                ClassLibrary.Calculator.Calculate(1, 0, ClassLibrary.Calculator.Operation.Divide);
            } catch (Exception exception) {
                Assert.AreEqual("Num2 is zero", exception.Message);
            }
        }

        [TestMethod]
        public void TestParseNumber()
        {
            var resultOfParse = ClassLibrary.Parser.ParseNumber("1");
            Assert.AreEqual(1, resultOfParse);

            try
            {
                var resultOfParse1 = ClassLibrary.Parser.ParseNumber("a");
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Value is not integer", exception.Message);
            }
        }

        [TestMethod]
        public void TestParseOperation()
        {
            var resultOfParse = ClassLibrary.Parser.ParseOperation("+");
            Assert.AreEqual(ClassLibrary.Calculator.Operation.Plus, resultOfParse);
            
            var resultOfParse2 = ClassLibrary.Parser.ParseOperation("-");
            Assert.AreEqual(ClassLibrary.Calculator.Operation.Minus, resultOfParse2);
            
            var resultOfParse3 = ClassLibrary.Parser.ParseOperation("*");
            Assert.AreEqual(ClassLibrary.Calculator.Operation.Multiply, resultOfParse3);

            var resultOfParse4 = ClassLibrary.Parser.ParseOperation("/");
            Assert.AreEqual(ClassLibrary.Calculator.Operation.Divide, resultOfParse4);

            try
            {
                var resultOfParse1 = ClassLibrary.Parser.ParseOperation("a");
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Operation is not correct", exception.Message);
            }
        }
    }
}





