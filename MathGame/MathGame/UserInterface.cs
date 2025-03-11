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
                        Questions("add");
                        break;

                    case OperationOptions.Subtract:
                        Questions("subtract");
                        break;

                    case OperationOptions.Mulitply:
                        Questions("multiply");
                        break;

                    case OperationOptions.Divide:
                        Questions("divide");
                        break;

                    case OperationOptions.Random:
                        Questions("random");
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

    public Operations GetRandom()
    {
        List<Operations> list = new List<Operations>();
        Operations divide = new Division();
        Operations multiply = new Multiply();
        Operations subtract = new Subtract();
        Operations add = new Add();

        list.Add(add);
        list.Add(subtract);
        list.Add(divide);
        list.Add(multiply);

        Random random = new Random();
        int getRandom = random.Next(0, list.Count - 1);

        return list[getRandom];
    }

    public void Questions(string op)
    {
        int count = 1;
        switch (op)
        {

            case "add":

                while (count < 6)
                {
                    Operations add = new Add();
                    history.Add(add.CalculationFinal());
                    count++;
                }
                break;

            case "subtract":
                while (count < 6)
                {
                    Operations subtract = new Add();
                    history.Add(subtract.CalculationFinal());
                    count++;
                }
                break;

            case "multiply":
                while (count < 6)
                {
                    Operations multiply = new Add();
                    history.Add(multiply.CalculationFinal());
                    count++;
                }

                break;

            case "divide":
                while (count < 6)
                {
                    Operations divide = new Add();
                    history.Add(divide.DivisionFinal());
                    count++;
                }
                break;

            case "random":
                while (count < 6)
                {
                    Operations random = GetRandom();
                    if (random is Division)
                    {
                        history.Add(random.DivisionFinal());
                    }
                    else
                    {
                        history.Add(random.CalculationFinal());
                    }
                    count++;
                }
                break;
        }
    }
}

