using Contracts.Models;

namespace Contracts.Interfaces;

public interface ITelegramClient
{
    Task<PublishResult> SendMessageAsync(string? imageUrl, string message, CancellationToken cancellationToken);
}