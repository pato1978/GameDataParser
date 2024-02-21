﻿namespace GameDataParser.App
{
    public interface IGameDataParserUserInteraction
    {
        string AskForUserInput(string text);
        void ShowMessage(string text);
        public void PrintGames(List<Games> games);
    }
}