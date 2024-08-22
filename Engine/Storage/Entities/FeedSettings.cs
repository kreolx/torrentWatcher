using Contracts.Models;

namespace Engine.Storage.Entities;

public record FeedSettings
{
    public Guid Id { get; init; }
    public string Url { get; init; } = default!;
    public Source Source { get; set; }
    public DateTimeOffset CreatedAt { get; init; }
}