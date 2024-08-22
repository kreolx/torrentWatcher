namespace Contracts.Interfaces;

public interface ITelegramClient
{
    Task<bool> SendMessageAsync(string? imageUrl, string message, CancellationToken cancellationToken);
}