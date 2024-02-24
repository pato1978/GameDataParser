

using GameDataParser.App;
using GameDataParser.Log;

GameDataParserApp app = new GameDataParserApp(
    new StringsJsonRepository(),      
 new GameDataParserConsoleUserInteraction ());


StringsTextualRepository stringsTextualRepository = new StringsTextualRepository();



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
        var newLog = Log.GetNewLog(ex);        
        oldLog.Add(newLog);
        stringsTextualRepository.Write("log.txt", oldLog);
    }
    else 
    {
        List<string> newLog =[DateTime.Now.ToString() + ex.Message + ex.StackTrace];
        stringsTextualRepository.Write("log.txt", newLog);
    }
}


Console.ReadLine();

