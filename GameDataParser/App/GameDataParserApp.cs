using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser.App
{
    public class GameDataParserApp
    {   
        private readonly StringsTextualRepository _stringsTextualRepository;
        private readonly IGameDataParserUserInteraction _gameDataParserConsoleUserInteraction;

        public GameDataParserApp(StringsTextualRepository stringsTextualRepository, IGameDataParserUserInteraction gameDataParserConsoleUserInteraction)
        {
            _stringsTextualRepository = stringsTextualRepository;
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

            var games = _stringsTextualRepository.Read(input);
            _gameDataParserConsoleUserInteraction.PrintGames(games);

        }

        
    }
}
