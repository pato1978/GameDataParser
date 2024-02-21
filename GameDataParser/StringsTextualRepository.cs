﻿using GameDataParser;
using System.Text.Json;
using System.Text.Json.Nodes;



public class StringsTextualRepository
{
    private static readonly string Separator = Environment.NewLine;

    public List<Games> Read(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        var strings =JsonSerializer.Deserialize<List<Games>>(fileContents);

        return strings;
    }

    public void Write(
        string filePath, List<string> names)
    {
        File.WriteAllText(
            filePath,
            string.Join(Separator, names));
    }
}

