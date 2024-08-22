namespace Contracts.Interfaces;

public interface IMainManager
{
    /// <summary>
    /// Запуск парсинга фидов.
    /// </summary>
    /// <param name="cancellationToken">Асинхронный токен отмены.</param>
    Task StartAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Запуска паблиша постов.
    /// </summary>
    /// <param name="cancellationToken">Асинхронный токен отмены.</param>
    Task PublishPostsAsync(CancellationToken cancellationToken);
}