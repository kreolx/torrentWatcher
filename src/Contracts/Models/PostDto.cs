namespace Contracts.Models;

/// <summary>
/// Моделька поста с торрента.
/// </summary>
public record PostDto(string Title, string Description, string Link, string ImageUrl, long ExternalId);