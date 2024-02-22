using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser.App
{
    public class GameDataParserConsoleUserInteraction : IGameDataParserUserInteraction
    {
        public void ShowMessage(string text)
        {
            Console.WriteLine(text);
        }
        public string AskForUserInput(string text)
        {
            string input;
            Console.WriteLine(text);
            input = Console.ReadLine();
            return input;
        }
        public void PrintGames(List<Games> games)
        {
            foreach (var game in games)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"{game.Title}, released in {game.ReleaseYear}, rating: {game.Rating}");               

            }
        }
        public void PrintNoValidFormatMessage(string? input, string fileContents)
        {
            Console.Write($"JSON in the {input} was not in a valid format. ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("JSON body:");
            Console.ResetColor();
            Console.WriteLine($" {fileContents}");
        }

    }
}
