

using GameDataParser.App;

GameDataParserApp app = new GameDataParserApp(
    new StringsTextualRepository(),
    new StringsJsonRepository(),
    new GameDataParserConsoleUserInteraction ());

try
{
	app.Run();
}
catch (Exception)
{

    Console.WriteLine("Sorry, the application has experienced an unexpected error and will have to be closed.");

    StringsTextualRepository stringsTextualRepository = new StringsTextualRepository();

    if (File.Exists("log.txt"))
    {
        var oldLog = stringsTextualRepository.Read("log.txt");
        //foreach (var log in oldLog)
        //{
        //    Console.WriteLine(log);
        //}
        var newLog = "Noch ein fehler gefunden.";
        oldLog.Add(newLog);
         
        stringsTextualRepository.Write("log.txt", oldLog);
    }
    else 
    {

    }
}


Console.ReadLine();