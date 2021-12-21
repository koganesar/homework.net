using System;
using System.Linq;
using hm10.DataBase;

namespace hm10.Models;

public class ExpressionsCache
{
    private readonly CalculatedExpressionsContext _context;

    public ExpressionsCache(CalculatedExpressionsContext context) =>
        _context = context;

    public CalculatedExpression GetOrSet(
        CalculatedExpression expWithoutRes,
        Func<decimal> resultBuilder)
    {
        try
        {
            lock (_context)
            {
                return _context.Expressions.First(expression =>
                    expression.Val1 == expWithoutRes.Val1 &&
                    expression.Val2 == expWithoutRes.Val2 &&
                    expression.Op == expWithoutRes.Op);
            }
        }
        catch
        {
            expWithoutRes.Result = resultBuilder();
            lock (_context)
            {
                _context.Expressions.Add(expWithoutRes);
                _context.SaveChanges();
            }
            return expWithoutRes;
        }
    }
}
