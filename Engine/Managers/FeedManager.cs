using Contracts.Interfaces;
using Contracts.Models;
using Engine.Storage.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Engine.Managers;

internal sealed class FeedManager : IFeedManager
{
    private readonly ApplicationDbContext _context;

    public FeedManager(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FeedDto>> GetFeedsAsync(CancellationToken cancellationToken)
    {
        return await _context.FeedSettings
                .Select(x => new FeedDto(x.Url, x.Source))
                .ToArrayAsync(cancellationToken);
    }
}