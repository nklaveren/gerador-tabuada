namespace Api;

public class MultiplicationTable(IFileWriter fileWriter)
{
    private readonly IFileWriter _fileWriter = fileWriter;
    static readonly ConcurrentDictionary<string, string> _files = new();
    public async Task<FileItem> Proccess(int file)
    {
        var fileName = $"tabuada_de_{file}.txt";
        if (_files.TryGetValue(fileName, out var content))
        {
            return new FileItem(fileName, content.Split(Environment.NewLine));
        }
        content = GenerateMultiplicationTable(file);
        _files[fileName] = content;
        await _fileWriter.WriteFileAsync(fileName, content);
        return new FileItem(fileName, content.Split(Environment.NewLine));
    }

    private static string GenerateMultiplicationTable(int number)
    {
        var sb = new StringBuilder();

        for (int i = 1; i <= 10; i++)
        {
            sb.Append(i);
            sb.Append(" x ");
            sb.Append(number);
            sb.Append(" = ");
            sb.Append(i * number);
            if(i < 10)
            sb.AppendLine();
        }
        return sb.ToString();
    }
}

public interface IFileWriter
{
    Task WriteFileAsync(string fileName, string content);
}

public class WriteFile : IFileWriter
{
    public async Task WriteFileAsync(string fileName, string content)
        => await File.WriteAllTextAsync(fileName, content);
}
