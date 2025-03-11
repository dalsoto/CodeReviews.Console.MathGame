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
}