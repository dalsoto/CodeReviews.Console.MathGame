using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Math;
internal class Division : Operations
{
    public Division() : base() { }

    public override string DisplayCalculation()
    {
        string calculation = $"{Value1} / {Value2}";
        Console.WriteLine(calculation);
        return calculation;
    }
    public override int Calculation()
    {
        return Value1 / Value2;
    }

    public string DivisionFinal()
    {
        while (true)
        {
            if (Value1 % Value2 != 0)
            {
                Random random = new Random();
                Value1 = random.Next(1, 101);
                Value2 = random.Next(1, 101);
                continue;
            }
            else
            {
                return CalculationFinal();
            }
        }
    }
}