namespace ClassLibrary

module Calculator =
    let DivideByZero =
        "Num2 is zero"
    let UnknownOperation =
        "Operation is unknown"
        
    type Operation =
          | Plus
          | Minus
          | Multiply
          | Divide
          | Unknown
          
     let Calculate (num1:int) (num2:int) operation =
        match operation with
        | Plus -> num1 + num2
        | Minus -> num1 - num2
        | Multiply -> num1 * num2
        | Divide ->
            try
                num1 / num2
            with
            | :? System.DivideByZeroException -> failwith DivideByZero
        | Unknown -> failwith UnknownOperation