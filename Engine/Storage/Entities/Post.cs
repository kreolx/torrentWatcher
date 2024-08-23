using Contracts.Models;

namespace Engine.Storage.Entities;

public record Post
{
    public Guid Id { get; init; }
    public string Title { get; init; } = default!;
    public string? Description { get; init; }
    public string? ImageUrl { get; init; }
    public string Link { get; init; } = default!;
    public long ExternalId { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? PublishedAt { get; set; }
    public PostStatus Status { get; set; }
    public string? ErrorMessage { get; set; }
}