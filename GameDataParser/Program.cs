

using GameDataParser.App;
using GameDataParser.Log;

GameDataParserApp app = new GameDataParserApp(
    new StringsTextualRepository(),
    new StringsJsonRepository(),
    new GameDataParserConsoleUserInteraction ());
StringsTextualRepository stringsTextualRepository = new StringsTextualRepository();
//Log log = new();

try
{
	app.Run();
}
catch (Exception ex)
{

    Console.WriteLine("Sorry, the application has experienced an unexpected error and will have to be closed.");

    

    if (File.Exists("log.txt"))
    {
        var oldLog = stringsTextualRepository.Read("log.txt");
        //foreach (var log in oldLog)
        //{
        //    Console.WriteLine(log);
        //}
        var newLog = Log.GetNewLog(ex);
        //List<string> newLog = [DateTime.Now.ToString() + ex.Message + ex.StackTrace];

        oldLog.Add(newLog);

        stringsTextualRepository.Write("log.txt", oldLog);
    }
    else 
    {

        List<string> newLog = [DateTime.Now.ToString() + ex.Message + ex.StackTrace];

        stringsTextualRepository.Write("log.txt", newLog);
    }
}


Console.ReadLine();

