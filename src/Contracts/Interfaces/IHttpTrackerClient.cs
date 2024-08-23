namespace Contracts.Interfaces;

public interface IHttpTrackerClient
{
    Task<string> GetAsync(string url, CancellationToken cancellationToken);
}