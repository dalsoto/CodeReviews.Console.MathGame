using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace MathGame.Math;

internal abstract class Operations
{
    protected int Value1 { get; set; }
    protected int Value2 { get; set; }

    public Operations()
    {
        Random random = new Random();

        Value1 = random.Next(1, 101);
        Value2 = random.Next(1, 101);
    }

    public abstract string DisplayCalculation();
    public abstract int Calculation();

    public string UserAnswer()
    {
        while (true)
        {
            bool validNumber;
            Console.Write("Your answer:");

            try
            {
                string? value = Console.ReadLine();

                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Enter a number.");
                    continue;
                }

                validNumber = int.TryParse(value, out int i);

                if (validNumber == false)
                {
                    Console.WriteLine("Enter a valid number.");
                    continue;
                }
                else
                {
                    return value;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public string CalculationFinal()
    {
        string calculation = DisplayCalculation();
        string answer = Calculation().ToString();
        string userAnswer = UserAnswer();

        if (answer == userAnswer)
        {
            Console.WriteLine("Correct! Press Any Key to Continue.");
            Console.ReadKey();
            return $"{calculation} = {answer}. Your answer: {userAnswer} - [green]Correct[/]";
        }
        else
        {
            Console.WriteLine($"Incorrect. {answer} was the correct answer. Press Any Key to Continue.");
            Console.ReadKey();
            return $"{calculation} = {answer}. Your answer {userAnswer} - [red]Incorrect[/]";
        }
    }
}

