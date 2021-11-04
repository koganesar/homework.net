namespace ClassLibrary

    open System
    
    module Parser =
        
        let unknownOperation = "Operation is unknown"
        let notNumberValue = "value is not number"
        
        let ParseOperation arg =
            ResultBuilder(unknownOperation) {
                if arg = "+" || arg = "-" || arg = "*" || arg = "/" then    
                    match arg with
                    |"+" -> return Calculator.Operation.Plus
                    |"-" -> return Calculator.Operation.Minus
                    |"*" -> return Calculator.Operation.Multiply
                    | _ -> return Calculator.Operation.Divide
            }
            
        let result = ResultBuilder(notNumberValue)
        let parseInt (arg: string): Result<int, string> =
            result {
                let valueRef = ref (Int32())
                if Int32.TryParse(arg, valueRef) then
                    return !valueRef
            }
            
        let parseFloat (arg: string): Result<single, string> =
            result {
                let valueRef = ref (Single())
                if Single.TryParse(arg, valueRef) then
                    return !valueRef
            }
            
            
            
        let parseDouble (arg: string): Result<double, string> =
            result {
                let valueRef = ref (Double())
                if Double.TryParse(arg, valueRef) then
                    return !valueRef
            }
            
            
            
        let parseDecimal (arg: string): Result<decimal, string> =
            result {
                let valueRef = ref (Decimal())
                if Decimal.TryParse(arg, valueRef) then
                    return !valueRef
            }

