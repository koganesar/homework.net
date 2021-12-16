module WebApplicationFs.CalculatorHandler

open Giraffe.Core
open Giraffe
open hm10.Models

let CalculatorHttpHandler (calculator : ExpressionCalculator) : HttpHandler =
    fun next ctx ->
        match ctx.GetQueryStringValue("expressionString") with
        | Ok str ->
            let res =
                CalculatorAdapter.calculate calculator str
            (setStatusCode 200 >=> json res) next ctx
        | Error e -> (setStatusCode 250 >=> json e) next ctx
