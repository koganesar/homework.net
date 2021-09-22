// Type: hm2.Parser 
// Assembly: hm2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 38697048-8E05-451F-88DD-181C863D5F51
// Location: /Users/a1/Documents/GitHub/homework.net/hm2/bin/Release/netcoreapp3.1/hm2.dll
// Sequence point data from /Users/a1/Documents/GitHub/homework.net/hm2/bin/Release/netcoreapp3.1/hm2.pdb

.class public abstract sealed auto ansi beforefieldinit
  hm2.Parser
    extends [System.Runtime]System.Object
{

  .field public static class [System.Runtime]System.Exception ParseNumberFail

  .field public static class [System.Runtime]System.Exception ParseOperationFail

  .method public hidebysig static int32
    ParseNumber(
      string 'value'
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 result
    )

    // [14 13 - 14 63]
    IL_0000: ldarg.0      // 'value'
    IL_0001: ldloca.s     result
    IL_0003: call         bool [System.Runtime]System.Int32::TryParse(string, int32&)

    // [15 13 - 15 26]
    IL_0008: brtrue.s     IL_0010

    // [17 17 - 17 39]
    IL_000a: ldsfld       class [System.Runtime]System.Exception hm2.Parser::ParseNumberFail
    IL_000f: throw

    // [20 13 - 20 27]
    IL_0010: ldloc.0      // result
    IL_0011: ret

  } // end of method Parser::ParseNumber

  .method public hidebysig static valuetype hm2.Calculator/Operation
    ParseOperation(
      string 'value'
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] valuetype hm2.Calculator/Operation V_0
    )

    // [25 13 - 32 15]
    IL_0000: ldarg.0      // 'value'
    IL_0001: ldstr        "+"
    IL_0006: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_000b: brtrue.s     IL_0036
    IL_000d: ldarg.0      // 'value'
    IL_000e: ldstr        "-"
    IL_0013: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0018: brtrue.s     IL_003a
    IL_001a: ldarg.0      // 'value'
    IL_001b: ldstr        "*"
    IL_0020: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0025: brtrue.s     IL_003e
    IL_0027: ldarg.0      // 'value'
    IL_0028: ldstr        "/"
    IL_002d: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0032: brtrue.s     IL_0042
    IL_0034: br.s         IL_0046

    // [27 24 - 27 49]
    IL_0036: ldc.i4.0
    IL_0037: stloc.0      // V_0
    IL_0038: br.s         IL_004c

    // [28 24 - 28 50]
    IL_003a: ldc.i4.1
    IL_003b: stloc.0      // V_0
    IL_003c: br.s         IL_004c

    // [29 24 - 29 53]
    IL_003e: ldc.i4.2
    IL_003f: stloc.0      // V_0
    IL_0040: br.s         IL_004c

    // [30 24 - 30 51]
    IL_0042: ldc.i4.3
    IL_0043: stloc.0      // V_0
    IL_0044: br.s         IL_004c

    // [31 22 - 31 46]
    IL_0046: ldsfld       class [System.Runtime]System.Exception hm2.Parser::ParseOperationFail
    IL_004b: throw

    IL_004c: ldloc.0      // V_0

    // [34 13 - 34 27]
    IL_004d: ret

  } // end of method Parser::ParseOperation

  .method private hidebysig static specialname rtspecialname void
    .cctor() cil managed
  {
    .maxstack 8

    // [8 9 - 8 89]
    IL_0000: ldstr        "Value is not integer"
    IL_0005: newobj       instance void [System.Runtime]System.Exception::.ctor(string)
    IL_000a: stsfld       class [System.Runtime]System.Exception hm2.Parser::ParseNumberFail

    // [10 9 - 10 96]
    IL_000f: ldstr        "Operation is not correct"
    IL_0014: newobj       instance void [System.Runtime]System.Exception::.ctor(string)
    IL_0019: stsfld       class [System.Runtime]System.Exception hm2.Parser::ParseOperationFail
    IL_001e: ret

  } // end of method Parser::.cctor
} // end of class hm2.Parser
