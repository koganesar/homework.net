using System;
using System.Globalization;
using System.Linq;
using System.Text;
using hm10.Models;
using hm11;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace hm10.Controllers
{

    public class CalculatorController : Controller
    {
        [HttpGet, Route("calculate")]
        public IActionResult Calculate([FromServices] ExceptionHandler exceptionHandler,[FromServices] ExpressionCalculator calculator, string expressionString)
        {
            string AddPluses(string str) =>
                str.Aggregate(new StringBuilder(), (builder, c) => builder.Append(c switch
                {
                    ' ' => "+",
                    '-' => builder.Length is not 0 && !"()*/+-".Contains(builder[^1]) ? "+-" : "-",
                    _ => c.ToString()
                })).ToString();

            try
            {
                expressionString = AddPluses(expressionString);
                Console.WriteLine();
                Console.WriteLine($"получено выражение:\n\t{expressionString}");

                var expression = calculator.FromString(expressionString);
                var res1 = calculator.ExecuteSlowly(expression);
                Console.WriteLine(
                    $"вывод результата через ExpressionCalculator:\n\t{res1?.ToString(CultureInfo.InvariantCulture) ?? "ошибка"}");
                return Ok(res1?.ToString(CultureInfo.InvariantCulture) ?? "ошибка");
            }
            catch(Exception e)
            {
                exceptionHandler.DoHandle(LogLevel.Error, e);
                return BadRequest();
            }
        }
    }
}