module WebApplicationFs.CalculatorAdapter

open Microsoft.FSharp.Core
open hm10.Controllers
open hm10.Models

let calculate (calculator: ExpressionCalculator) str : decimal =
    let str = ExpressionChinilo.Pochinit(str)
    let expression = calculator.FromString(str)
    calculator.ExecuteSlowly(expression) |> decimal
