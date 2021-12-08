module hm6.CalculatorHandler
open Giraffe
open Microsoft.AspNetCore.Http
open ClassLibrary

    [<CLIMutable>]
    type Values =
       {
            V1: string
            V2: string
            operation: string
       }
    
let calculatorHttpHandler:HttpHandler =
    fun next ctx ->
        let values = ctx.TryBindQueryString<Values>()
        match values with
        |Ok v ->
            let v1 = Parser.parseDecimal v.V1
            let v2 = Parser.parseDecimal v.V2
            let operation =
                match v.operation with
                |"Plus" -> Parser.ParseOperation "+"
                |"Minus" -> Parser.ParseOperation "-"
                |"Multiply" -> Parser.ParseOperation "*"
                |"Divide" -> Parser.ParseOperation "/"
                |_ -> Parser.ParseOperation "?"
            let result = Calculator.Calculate v1 v2 operation
            match result with
            |Ok result -> (setStatusCode 200 >=> json result) next ctx
            |Error result -> (setStatusCode 400 >=> json result) next ctx
        |Error v ->
            (setStatusCode 400 >=> json v) next ctx