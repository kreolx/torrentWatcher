using Contracts.Models;

namespace Engine.Managers.Contracts;

public interface IPageParserManager
{
    Source Source { get; }

    /// <summary>
    /// Загружает дополнительные данные со страницы трекера.
    /// </summary>
    /// <param name="postDto">Данные о посте.</param>
    /// <param name="cancellationToken">Асинхронный токен отмены.</param>
    /// <returns><see cref="PostDto"/>Обогащенные данные о посте.</returns>
    Task<PostDto> LoadDataAsync(PostDto postDto, CancellationToken cancellationToken);
}