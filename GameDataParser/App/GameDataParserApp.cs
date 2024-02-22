using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameDataParser.App
{
    public class GameDataParserApp
    {   
        private readonly IStringsRepository _stringsTextualRepository;
        private readonly StringsJsonRepository _stringsJsonRepository;
        private readonly IGameDataParserUserInteraction _gameDataParserConsoleUserInteraction;

        public GameDataParserApp(IStringsRepository stringsTextualRepository,
                                 StringsJsonRepository stringsJsonRepository,
                                 IGameDataParserUserInteraction gameDataParserConsoleUserInteraction)
        {
            _stringsTextualRepository = stringsTextualRepository;
            _stringsJsonRepository = stringsJsonRepository;
            _gameDataParserConsoleUserInteraction = gameDataParserConsoleUserInteraction;
            
        }

        public void Run()
        {
            var input= "";
            do
            {
                input = _gameDataParserConsoleUserInteraction.AskForUserInput("Please enter the name of the file you want to read:");

                if (input == null)
                {
                    _gameDataParserConsoleUserInteraction.ShowMessage("File name cannot be null.");
                }
                else if (input == "")
                {
                    _gameDataParserConsoleUserInteraction.ShowMessage("File name cannot be empty.");
                }
                else if (!File.Exists(input))
                {
                    _gameDataParserConsoleUserInteraction.ShowMessage("File not found.");
                }
            } while (!File.Exists(input));

            try
            {
                var games = _stringsJsonRepository.Read(input);
                if (games.Count == 0)
                {
                    _gameDataParserConsoleUserInteraction.ShowMessage("No games are present in the input file.");
                }
                else
                {
                    _gameDataParserConsoleUserInteraction.PrintGames(games);
                }
            }
            catch (JsonException ex)
            {
                var fileContents = File.ReadAllText(input);
                _gameDataParserConsoleUserInteraction.PrintNoValidFormatMessage(input, fileContents);
               
                throw;
            }
            


        }

        

    }
}
