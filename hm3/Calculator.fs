namespace ClassLibrary

open System

type ResultBuilder(arg: string) =
    member b.Zero() = Error arg
    member b.Bind(x, f) =
        match x with
        |Ok x -> f x
        |Error _ -> x
    member b.Return(x) =
        Ok x

module Calculator =
    let DivideByZero =
        "Num2 is zero"
    let result = ResultBuilder(DivideByZero)
    type Operation =
          | Plus
          | Minus
          | Multiply
          | Divide
          
    let inline Calculate (num1:Result<'T, string> when  'T:(static member (+): 'T * 'T -> 'T))
                         (num2:Result<'T, string>)
                         (operation:Result<Operation,string>) =
        match operation with
        | Ok operation ->
            result {
                let! num1 = num1
                let! num2 = num2
                match operation with
                |Plus -> return num1 + num2
                |Minus -> return num1 - num2
                |Multiply -> return num1 * num2
                |Divide ->
                    if num2 <> new 'T() then
                        return num1/num2
            }
        |Error operationError -> Error operationError
        
         