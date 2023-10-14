using System.Text.Json;
using System.Text.Json.Serialization;

namespace NonStop.MoreTechHack.Backend.Helpers;

public static class JsonHelper
{
    private static readonly JsonSerializerOptions DefaultSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public static T? LoadJson<T>(string file)
    {
        using var reader = new StreamReader(file);
        var json = reader.ReadToEnd();
        return JsonSerializer.Deserialize<T>(json, DefaultSerializerOptions);
    }
}
