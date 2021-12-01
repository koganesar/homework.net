using System;

namespace hm8
{
    public class Claculator: IClaculator
    {
        public double Calllculate(string num1, string num2, string oper)
        {
            var double1 = double.Parse(num1);
                        var double2 = double.Parse(num2);
                        return oper switch
                        {
                            "+" => double1 + double2,
                            "-" => double1 - double2,
                            "*" => double1 * double2,
                            "/" => double1 / double2,
                            _ => throw new Exception(
                                "Все окей, ты просто дегенерат, Я ЖЕ ТЕБЕ СКАЗАЛА ЧТО ТОЛЬКО 4 ОПЕРАЦИИ ВВОДИТЬ МОЖНО, НУ ЕП ТВОЮ МАТЬ, Я ЕМУ РАЗ СКАЗАЛА, Я ЕМУ ДВА СКАЗАЛА, А ОН НЕ ПОНИМАЕТ")
                        };
        }
    }
}