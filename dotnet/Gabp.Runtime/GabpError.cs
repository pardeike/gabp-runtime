using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gabp.Runtime
{
    public sealed class GabpError
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public JsonElement? Data { get; set; }
    }
}
