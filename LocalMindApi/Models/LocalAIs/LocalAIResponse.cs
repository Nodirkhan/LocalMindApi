using System;
using System.Text.Json.Serialization;

namespace LocalMindApi.Models.LocalAIs
{
    public class LocalAIResponse
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("response")]
        public string Response { get; set; }
    }
}
