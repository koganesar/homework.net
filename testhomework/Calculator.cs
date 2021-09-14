using System;
using System.Runtime.Serialization;

namespace testhomework
{
    public static class Calculator
    {
        public enum Operation
        {
            Plus, 
            Minus,
            Multiply,
            Divide,
            Unassigned
        }

        public static Exception UnassignedOperation = new Exception("Operation is unassigned");
            
        public static Exception UnknownOperation = new Exception("Operation is unknown");
        
        public static DivideByZeroException DivideByZero = new DivideByZeroException("Num2 is zero");
        
        
        public static int Calculate(int num1, int num2, Operation operation)
        {
            int result;
            switch (operation)
            {
                case Operation.Plus:
                    result = num1 + num2;
                    break;
                case Operation.Minus:
                    result = num1 - num2;
                    break;
                case Operation.Multiply:
                    result = num1 * num2;
                    break;
                case Operation.Divide:
                    if (num2 == 0)
                    {
                        throw DivideByZero;
                    }
                    result = num1 / num2;
                    break;
                case Operation.Unassigned:
                    throw UnassignedOperation;
                default:
                    throw UnknownOperation;
            }

            return result;
        }
    }
}