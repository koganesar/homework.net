// Type: hm2.Calculator 
// Assembly: hm2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 38697048-8E05-451F-88DD-181C863D5F51
// Location: /Users/a1/Documents/GitHub/homework.net/hm2/bin/Release/netcoreapp3.1/hm2.dll
// Sequence point data from /Users/a1/Documents/GitHub/homework.net/hm2/bin/Release/netcoreapp3.1/hm2.pdb


.assembly hm2
{
.ver 1:0:0:0
}


.class public abstract sealed auto ansi beforefieldinit
  hm2.Calculator
    extends [CORE_ASSEMBLY]System.Object
{

  .class nested public sealed auto ansi
    Operation
      extends System.Enum
  {

    .field public specialname rtspecialname int32 value__

    .field public static literal valuetype hm2.Calculator/Operation Plus = int32(0) // 0x00000000

    .field public static literal valuetype hm2.Calculator/Operation Minus = int32(1) // 0x00000001

    .field public static literal valuetype hm2.Calculator/Operation Multiply = int32(2) // 0x00000002

    .field public static literal valuetype hm2.Calculator/Operation Divide = int32(3) // 0x00000003

    .field public static literal valuetype hm2.Calculator/Operation Unknown = int32(4) // 0x00000004
  } // end of class Operation

  .field public static class [System.Runtime]System.Exception UnknownOperation

  .field public static class [System.Runtime]System.DivideByZeroException DivideByZero

  .method public hidebysig static int32
    Calculate(
      int32 num1,
      int32 num2,
      valuetype hm2.Calculator/Operation operation
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 result
    )

    // [24 13 - 24 28]
    IL_0000: ldc.i4.0
    IL_0001: stloc.0      // result

    IL_0002: ldarg.2      // operation
    IL_0003: switch       (IL_001a, IL_0020, IL_0026, IL_002c)
    IL_0018: br.s         IL_003b

    // [28 21 - 28 42]
    IL_001a: ldarg.0      // num1
    IL_001b: ldarg.1      // num2
    IL_001c: add
    IL_001d: stloc.0      // result

    // [29 21 - 29 27]
    IL_001e: br.s         IL_0041

    // [31 21 - 31 42]
    IL_0020: ldarg.0      // num1
    IL_0021: ldarg.1      // num2
    IL_0022: sub
    IL_0023: stloc.0      // result

    // [32 21 - 32 27]
    IL_0024: br.s         IL_0041

    // [34 21 - 34 42]
    IL_0026: ldarg.0      // num1
    IL_0027: ldarg.1      // num2
    IL_0028: mul
    IL_0029: stloc.0      // result

    // [35 21 - 35 27]
    IL_002a: br.s         IL_0041

    // [37 21 - 37 35]
    IL_002c: ldarg.1      // num2
    IL_002d: brtrue.s     IL_0035

    // [39 25 - 39 44]
    IL_002f: ldsfld       class [System.Runtime]System.DivideByZeroException hm2.Calculator::DivideByZero
    IL_0034: throw

    // [41 21 - 41 42]
    IL_0035: ldarg.0      // num1
    IL_0036: ldarg.1      // num2
    IL_0037: div
    IL_0038: stloc.0      // result

    // [42 21 - 42 27]
    IL_0039: br.s         IL_0041

    // [44 21 - 44 44]
    IL_003b: ldsfld       class [System.Runtime]System.Exception hm2.Calculator::UnknownOperation
    IL_0040: throw

    // [47 13 - 47 27]
    IL_0041: ldloc.0      // result
    IL_0042: ret

  } // end of method Calculator::Calculate

  .method private hidebysig static specialname rtspecialname void
    .cctor() cil managed
  {
    .maxstack 8

    // [17 9 - 17 90]
    IL_0000: ldstr        "Operation is unknown"
    IL_0005: newobj       instance void [System.Runtime]System.Exception::.ctor(string)
    IL_000a: stsfld       class [System.Runtime]System.Exception hm2.Calculator::UnknownOperation

    // [19 9 - 19 102]
    IL_000f: ldstr        "Num2 is zero"
    IL_0014: newobj       instance void [System.Runtime]System.DivideByZeroException::.ctor(string)
    IL_0019: stsfld       class [System.Runtime]System.DivideByZeroException hm2.Calculator::DivideByZero
    IL_001e: ret

  } // end of method Calculator::.cctor
} // end of class hm2.Calculator

