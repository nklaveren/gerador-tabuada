using System.Text.Json.Serialization;

namespace Api;

public record FilesRequest(int[] Ids);

public record FileItem(string FileName, string[] Lines);

[JsonSerializable(typeof(FileItem[]))]
[JsonSerializable(typeof(FilesRequest))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }