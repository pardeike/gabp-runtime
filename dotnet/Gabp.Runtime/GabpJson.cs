using Newtonsoft.Json;

namespace Gabp.Runtime
{
    public static class GabpJson
    {
        private static readonly JsonSerializerSettings DefaultSettings = CreateDefaultSettings();

        public static string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value, DefaultSettings);
        }

        public static byte[] SerializeToUtf8Bytes<T>(T value)
        {
            return System.Text.Encoding.UTF8.GetBytes(Serialize(value));
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, DefaultSettings)!;
        }

        public static T Deserialize<T>(byte[] json)
        {
            return Deserialize<T>(System.Text.Encoding.UTF8.GetString(json));
        }

        private static JsonSerializerSettings CreateDefaultSettings()
        {
            return new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }
    }
}
