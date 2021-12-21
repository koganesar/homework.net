using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using hm10.DataBase;
using hm9.Models;

namespace hm10.Models;

public class CachedExecutor : SlowExecutor
{
    private readonly ExpressionsCache _cache;

    public CachedExecutor(ExpressionsCache cache) =>
        _cache = cache;


    protected override Expression Visit(BinaryExpression node)
    {
        var leftResult = Task.Run(
            () => (ConstantExpression) (
                node.Left is BinaryExpression leftBinary
                    ? Visit(leftBinary)
                    : node.Left));
        var rightResult = Task.Run(
            () => (ConstantExpression) (
                node.Right is BinaryExpression rightBinary
                    ? Visit(rightBinary)
                    : node.Right));
        Task.WaitAll(leftResult, rightResult);

        var expression = new CalculatedExpression
        {
            Val1 = (decimal) leftResult.Result.Value!,
            Val2 = (decimal) rightResult.Result.Value!,
            Op = node.NodeType switch
            {
                ExpressionType.Add => Operation.Plus,
                ExpressionType.Subtract => Operation.Minus,
                ExpressionType.Multiply => Operation.Mult,
                ExpressionType.Divide => Operation.Div,
                _ => throw new Exception("иди те в баню")
            }
        };
        expression = _cache.GetOrSet(expression, () =>
        {
            Task.Delay(1000).Wait();
            return expression.Op switch
            {
                Operation.Plus => expression.Val1 + expression.Val2,
                Operation.Minus => expression.Val1 - expression.Val2,
                Operation.Mult => expression.Val1 * expression.Val2,
                Operation.Div => expression.Val1 / expression.Val2,
                _ => throw new Exception("wrong operation")
            };
        });

        Console.WriteLine($"{leftResult.Result} {node.Method} {rightResult.Result}");
        return Expression.Constant(expression.Result);
    }
}
