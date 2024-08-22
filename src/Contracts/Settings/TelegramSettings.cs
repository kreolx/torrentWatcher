namespace Contracts.Settings;

public record TelegramSettings
{
    public string ChatId { get; set; } = default!;
    public string Token { get; set; } = default!;
}