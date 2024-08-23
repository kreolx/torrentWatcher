using Contracts.Models;

namespace Engine.Storage.Entities;

public record Post
{
    public Guid Id { get; init; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string Link { get; set; } = default!;
    public long ExternalId { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? PublishedAt { get; set; }
    public PostStatus Status { get; set; }
    public string? ErrorMessage { get; set; }
    public string? Tag { get; set; }
    public string? Magnit { get; set; }
}