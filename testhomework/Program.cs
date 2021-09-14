using System;

namespace testhomework
{
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = Parser.ParseNumber(args[0]);
            var operation = Parser.ParseOperation(args[1]);
            var num2 = Parser.ParseNumber(args[2]);

            var result = Calculator.Calculate(num1, num2, operation);
            

            Console.WriteLine($"Result is:{result}");
        }
    }
}
