using System.Text.Json.Serialization;

namespace TelegramClient.Models;

public record TelegramResult
{
    [JsonPropertyName("ok")]
    public bool Ok { get; set; }
    [JsonPropertyName("error_code")]
    public int? ErrorCode { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}