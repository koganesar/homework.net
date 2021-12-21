using System;
using System.Globalization;
using System.Linq.Expressions;
using hm9.Models;

namespace hm10.Models
{

    public class ExpressionCalculator
    {
        private readonly SlowExecutor _executor;

        public ExpressionCalculator(SlowExecutor executor) =>
            _executor = executor;

        public Expression FromString(string str) =>
            decimal.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedResult)
                ? Expression.Constant(parsedResult)
                : StringParsingHelper.TryFindMiddlePlus(ref str, out var beforePlus)
                    ? Compose(
                        FromString(beforePlus),
                        FromString(str[1..]),
                        StringParsingHelper.ParseOperation(str[0]))
                    : StringParsingHelper.TryFindLastMultOrDiv(ref str, out var beforeOperation)
                        ? Compose(
                            FromString(beforeOperation),
                            FromString(str[1..]),
                            StringParsingHelper.ParseOperation(str[0]))
                        : str![0] is '('
                            ? StringParsingHelper.IsAllSingleBracketExpression(str)
                                ? FromString(str[1..^1])
                                : Compose(
                                    FromString(StringParsingHelper.TakeBrackets(ref str)),
                                    FromString(str[1..]),
                                    StringParsingHelper.ParseOperation(str[0]))
                            : str[0] is '-' && StringParsingHelper.IsAllSingleBracketExpression(str[1..])
                                ? Negotiate(FromString(str[2..^1]))
                                : throw new Exception(str);

        private static BinaryExpression Compose(Expression e1, Expression e2, Operation operation) =>
            operation switch
            {
                Operation.Plus => Expression.MakeBinary(ExpressionType.Add, e1, e2),
                Operation.Minus => Expression.MakeBinary(ExpressionType.Subtract, e1, e2),
                Operation.Mult => Expression.MakeBinary(ExpressionType.Multiply, e1, e2),
                Operation.Div => Expression.MakeBinary(ExpressionType.Divide, e1, e2),
                _ => throw new Exception("не соответствует ни одной из данных операций")
            };

        private static UnaryExpression Negotiate(Expression e) =>
            Expression.MakeUnary(ExpressionType.Negate, e, default);

        public decimal? ExecuteSlowly(Expression expression) =>
            (_executor.StartVisiting(expression) as ConstantExpression)?.Value as decimal?;
    }
}