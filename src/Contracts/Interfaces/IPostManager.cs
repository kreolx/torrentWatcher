using Contracts.Models;

namespace Contracts.Interfaces;

public interface IPostManager
{
    /// <summary>
    /// Сохраняем пост в базу данных.
    /// </summary>
    /// <param name="postDto">Данные поста.</param>
    /// <param name="cancellationToken">Асинхронный токен отмены.</param>
    Task AddNewPostAsync(PostDto postDto, CancellationToken cancellationToken);
    
    /// <summary>
    /// Достаем первый неопубликованный пост.
    /// </summary>
    /// <param name="cancellationToken">Асинхронный токен отмены.</param>
    /// <returns><see cref="PostDto"/>Данные поста.</returns>
    Task<NotPublishedPost?> GetNotPublishedPostAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Добавление списка постов.
    /// </summary>
    /// <param name="postsDto">Список заготовок для добавления.</param>
    /// <param name="cancellationToken">Асинхронный токен отмены.</param>
    Task AddRangePostsAsync(IEnumerable<PostDto> postsDto, CancellationToken cancellationToken);

    /// <summary>
    /// Отмечает пост как опубликованный.
    /// </summary>
    /// <param name="id">Идентификатор поста.</param>
    /// <param name="result"></param>
    /// <param name="cancellationToken">Асинхронный токен отмены.</param>
    Task SetPublishedPostAsync(Guid id, PublishResult result, CancellationToken cancellationToken);
}