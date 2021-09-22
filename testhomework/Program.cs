using System;
using hm2;

namespace testhomework
{
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = hm2.Parser.ParseNumber(args[0]);
            var operation = hm2.Parser.ParseOperation(args[1]);
            var num2 = hm2.Parser.ParseNumber(args[2]);

            var result = hm2.Calculator.Calculate(num1, num2, operation);
            

            Console.WriteLine($"Result is:{result}");
        }
    }
}
