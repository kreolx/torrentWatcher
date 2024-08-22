using Contracts.Models;

namespace Contracts.Interfaces;

public interface IFeedManager
{
    Task<IEnumerable<FeedDto>> GetFeedsAsync(CancellationToken cancellationToken);
}