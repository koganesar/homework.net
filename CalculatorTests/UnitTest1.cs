using System;
using ClassLibrary;
using Microsoft.FSharp.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSum()
        {
            Assert.AreEqual(FSharpResult<int, string>.NewOk(2), 
                Calculator.Calculate(FSharpResult<int, string>.NewOk(1),
                    FSharpResult<int, string>.NewOk(1),
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Plus)));
        }
        
        [TestMethod]
        public void TestMinus()
        {
            Assert.AreEqual(FSharpResult<int, string>.NewOk(1), 
                ClassLibrary.Calculator.Calculate(FSharpResult<int, string>.NewOk(3), 
                    FSharpResult<int, string>.NewOk(2), 
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Minus)));
        }

        [TestMethod]
        public void TestMultiply()
        {
            Assert.AreEqual(FSharpResult<int, string>.NewOk(5), 
                ClassLibrary.Calculator.Calculate(FSharpResult<int, string>.NewOk(1),
                    FSharpResult<int, string>.NewOk(5), 
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Multiply)));
        }

        [TestMethod]
        public void TestDivide()
        {
            Assert.AreEqual(FSharpResult<int, string>.NewOk(5), 
                ClassLibrary.Calculator.Calculate(FSharpResult<int, string>.NewOk(25),
                    FSharpResult<int, string>.NewOk(5), 
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Divide)));
        }
        
        
        
        
        //Double
        
        
        
        
        [TestMethod]
        public void TestSum1()
        {
            Assert.AreEqual(FSharpResult<double, string>.NewOk(2), 
                Calculator.Calculate(FSharpResult<double, string>.NewOk(1),
                    FSharpResult<double, string>.NewOk(1),
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Plus)));
        }
        
        [TestMethod]
        public void TestMinus1()
        {
            Assert.AreEqual(FSharpResult<double, string>.NewOk(1), 
                ClassLibrary.Calculator.Calculate(FSharpResult<double, string>.NewOk(3), 
                    FSharpResult<double, string>.NewOk(2), 
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Minus)));
        }

        [TestMethod]
        public void TestMultiply1()
        {
            Assert.AreEqual(FSharpResult<double, string>.NewOk(5), 
                ClassLibrary.Calculator.Calculate(FSharpResult<double, string>.NewOk(1),
                    FSharpResult<double, string>.NewOk(5), 
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Multiply)));
        }

        [TestMethod]
        public void TestDivide1()
        {
            Assert.AreEqual(FSharpResult<double, string>.NewOk(5), 
                ClassLibrary.Calculator.Calculate(FSharpResult<double, string>.NewOk(25),
                    FSharpResult<double, string>.NewOk(5), 
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Divide)));
        }
        
        
        
        //float
        
        
        
        
        [TestMethod]
        public void TestSum2()
        {
            Assert.AreEqual(FSharpResult<Single, string>.NewOk(2), 
                Calculator.Calculate(FSharpResult<Single, string>.NewOk(1),
                    FSharpResult<Single, string>.NewOk(1),
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Plus)));
        }
        
        [TestMethod]
        public void TestMinus2()
        {
            Assert.AreEqual(FSharpResult<Single, string>.NewOk(1), 
                ClassLibrary.Calculator.Calculate(FSharpResult<Single, string>.NewOk(3), 
                    FSharpResult<Single, string>.NewOk(2), 
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Minus)));
        }

        [TestMethod]
        public void TestMultiply2()
        {
            Assert.AreEqual(FSharpResult<Single, string>.NewOk(5), 
                ClassLibrary.Calculator.Calculate(FSharpResult<Single, string>.NewOk(1),
                    FSharpResult<Single, string>.NewOk(5), 
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Multiply)));
        }

        [TestMethod]
        public void TestDivide2()
        {
            Assert.AreEqual(FSharpResult<Single, string>.NewOk(5), 
                ClassLibrary.Calculator.Calculate(FSharpResult<Single, string>.NewOk(25),
                    FSharpResult<Single, string>.NewOk(5), 
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Divide)));
        }
        
        
        
        
        //decimal
        
        
        
        
        [TestMethod]
        public void TestSum3()
        {
            Assert.AreEqual(FSharpResult<decimal, string>.NewOk(2), 
                Calculator.Calculate(FSharpResult<decimal, string>.NewOk(1),
                    FSharpResult<decimal, string>.NewOk(1),
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Plus)));
        }
        
        [TestMethod]
        public void TestMinus3()
        {
            Assert.AreEqual(FSharpResult<decimal, string>.NewOk(1), 
                ClassLibrary.Calculator.Calculate(FSharpResult<decimal, string>.NewOk(3), 
                    FSharpResult<decimal, string>.NewOk(2), 
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Minus)));
        }

        [TestMethod]
        public void TestMultiply3()
        {
            Assert.AreEqual(FSharpResult<decimal, string>.NewOk(5), 
                ClassLibrary.Calculator.Calculate(FSharpResult<decimal, string>.NewOk(1),
                    FSharpResult<decimal, string>.NewOk(5), 
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Multiply)));
        }

        [TestMethod]
        public void TestDivide3()
        {
            Assert.AreEqual(FSharpResult<decimal, string>.NewOk(5), 
                ClassLibrary.Calculator.Calculate(FSharpResult<decimal, string>.NewOk(25),
                    FSharpResult<decimal, string>.NewOk(5), 
                    FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Divide)));
        }
        
        
        

        [TestMethod]
        public void TestDivideByZero()
        {
            Assert.AreEqual(FSharpResult<int, string>.NewError(Calculator.DivideByZero),
                Calculator.Calculate(FSharpResult<int, string>.NewOk(1),
                FSharpResult<int, string>.NewOk(0),
                FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Divide)));
        }

        [TestMethod]
        public void TestParseNumber()
        {
            Assert.AreEqual(FSharpResult<int, string>.NewOk(1), Parser.parseInt("1"));
            Assert.AreEqual(FSharpResult<int, string>.NewError(Parser.notNumberValue), Parser.parseInt("a"));
        }

        [TestMethod]
        public void TestParseOperation()
        {
            Assert.AreEqual(FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Plus), Parser.ParseOperation("+"));
            
            Assert.AreEqual(FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Minus), Parser.ParseOperation("-"));
            
            Assert.AreEqual(FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Multiply), Parser.ParseOperation("*"));
            
            Assert.AreEqual(FSharpResult<Calculator.Operation, string>.NewOk(Calculator.Operation.Divide), Parser.ParseOperation("/"));
            
            Assert.AreEqual(FSharpResult<Calculator.Operation, string>.NewError(Parser.unknownOperation), Parser.ParseOperation("a"));
        }
    }
}





