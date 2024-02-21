

using GameDataParser.App;

GameDataParserApp app = new GameDataParserApp(new StringsTextualRepository(),new GameDataParserConsoleUserInteraction ());
app.Run();


Console.ReadLine();