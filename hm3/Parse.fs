namespace ClassLibrary

    open System
    
    module Parser =
        let ParseOperation arg =
            match arg with
            | "+" -> Calculator.Operation.Plus
            | "-" -> Calculator.Operation.Minus
            | "*" -> Calculator.Operation.Multiply
            | "/" -> Calculator.Operation.Divide
            | _ -> Calculator.Operation.Unknown
            
        let ParseNumber (str:string) =
            let valueRef = ref 0;  
            if Int32.TryParse(str, valueRef) then
                 !valueRef
            else
                Console.WriteLine($"value is not int. The value was {str}")
                0