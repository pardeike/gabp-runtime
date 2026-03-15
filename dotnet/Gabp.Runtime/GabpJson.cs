using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gabp.Runtime
{
    public static class GabpJson
    {
        public static JsonSerializerOptions DefaultOptions { get; } = CreateDefaultOptions();

        public static string Serialize<T>(T value)
        {
            return JsonSerializer.Serialize(value, DefaultOptions);
        }

        public static byte[] SerializeToUtf8Bytes<T>(T value)
        {
            return JsonSerializer.SerializeToUtf8Bytes(value, DefaultOptions);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, DefaultOptions)!;
        }

        public static T Deserialize<T>(byte[] json)
        {
            return JsonSerializer.Deserialize<T>(json, DefaultOptions)!;
        }

        private static JsonSerializerOptions CreateDefaultOptions()
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = null,
                WriteIndented = false
            };

            options.Converters.Add(new JsonStringEnumConverter());
            return options;
        }
    }
}
