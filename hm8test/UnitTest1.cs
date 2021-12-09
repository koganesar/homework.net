using System;
using hm8;
using Xunit;

namespace hm8test
{
    public class UnitTest1
    {
        private Claculator claculllator = new Claculator();
        [Theory]
        [InlineData("1", "2", "+", 3)]
        [InlineData("1", "2", "-", -1)]
        [InlineData("1", "2", "*", 2)]
        [InlineData("1", "2", "/", 0.5)]

        public void Test1(string num1, string num2, string oper, double result)
        {
            Assert.Equal(claculllator.Calllculate(num1, num2, oper), result);
            // var result = claculllator.Calllculate("1", "2", "+");

        }
    }
}