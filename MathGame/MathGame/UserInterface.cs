using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using static MathGame.Enums;
using MathGame.Math;

namespace MathGame;
internal class UserInterface
{
    private static List<string> history = new List<string>();

    internal void MainMenu()
    {
        while (true)
        {
            Console.Clear();

            var main = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenu>()
                .Title("Welcome to the Math Game Main Menu!\n" +
                "Please select Start or View History.")
                .AddChoices(Enum.GetValues<MainMenu>()));

            if (main == Enums.MainMenu.Start)
            {
                var choice = AnsiConsole.Prompt(
                new SelectionPrompt<OperationOptions>()
                .Title("What operation would you like to do?")
                .AddChoices(Enum.GetValues<OperationOptions>()));

                switch (choice)
                {
                    case OperationOptions.Add:
                        Operations add = new Add();
                        history.Add(add.CalculationFinal());
                        break;

                    case OperationOptions.Subtract:
                        Operations subtract = new Subtract();
                        history.Add(subtract.CalculationFinal());
                        break;

                    case OperationOptions.Mulitply:
                        Operations multiply = new Multiply();
                        history.Add(multiply.CalculationFinal());
                        break;

                    case OperationOptions.Divide:
                        Division divide = new Division();
                        history.Add(divide.DivisionFinal());
                        break;
                }
            }
            else if (main == Enums.MainMenu.ViewHistory)
            {
                foreach (var item in history)
                {
                    AnsiConsole.Markup($"{item}\n");
                }
                Console.WriteLine("Press Any Key to Continue.");
                Console.ReadKey();
            }
            else
            {
                break;
            }

        }


    }
}

