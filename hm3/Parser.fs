namespace ClassLibrary

    open System
    
    module Parser =
        
        let unknownOperation = "Operation is unknown"
        let result = ResultBuilder(unknownOperation)
        
        let ParseOperation arg =
            result {
                match arg with
                |"+" -> return Calculator.Operation.Plus
                |"-" -> return Calculator.Operation.Minus
                |"*" -> return Calculator.Operation.Multiply
                |"/" -> return Calculator.Operation.Divide
            }
            
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

