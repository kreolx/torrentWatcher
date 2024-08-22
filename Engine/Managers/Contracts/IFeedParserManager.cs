using Contracts.Models;

namespace Engine.Managers.Contracts;

public interface IFeedParserManager
{
    Source Source { get; }
    
    /// <summary>
    /// Парсинг фида трекера.
    /// </summary>
    /// <param name="feed">Фид в строковом представлении.</param>
    /// <returns><see cref="PostDto"/>Массив постов в первом приближении.</returns>
    IEnumerable<PostDto>? ParseFeed(string feed);
}