using GameDataParser;

public interface IStringsRepository
{
    List<Games> Read(string filePath);
    void Write(string filePath, List<string> strings);
}