﻿

public class StringsTextualRepository : IStringsRepository
{
    private static readonly string Separator = Environment.NewLine;

    public List<string> Read(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        return fileContents.Split(Separator).ToList();
    }

    public void Write(string filePath, List<string> text)
    {
        File.WriteAllText(filePath, string.Join(Separator, text));
    }
}