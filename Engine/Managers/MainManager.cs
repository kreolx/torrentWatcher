using System.Text.Json;
using Contracts.Interfaces;
using Contracts.Models;
using Engine.Managers.Contracts;
using Microsoft.Extensions.Logging;

namespace Engine.Managers;

internal sealed class MainManager : IMainManager
{
    private readonly IFeedManager _feedManager;
    private readonly IPostManager _postManager;
    private readonly IEnumerable<IFeedParserManager> _feedParserManagers;
    private readonly IEnumerable<IPageParserManager> _pageParsers;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ITelegramClient _telegramClient;
    private readonly ILogger<MainManager> _logger;

    public MainManager(IFeedManager feedManager, IPostManager postManager, IEnumerable<IFeedParserManager> feedParserManagers,
        IEnumerable<IPageParserManager> pageParsers, IHttpClientFactory httpClientFactory, ILogger<MainManager> logger, ITelegramClient telegramClient)
    {
        _feedManager = feedManager;
        _postManager = postManager;
        _feedParserManagers = feedParserManagers;
        _pageParsers = pageParsers;
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _telegramClient = telegramClient;
    }

    ///<inheritdoc/>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting processing feeds.");
        var feeds = await _feedManager.GetFeedsAsync(cancellationToken);
        foreach (var feedSetting in feeds.ToArray())
        {
            _logger.LogInformation("Processing feed: {0}", feedSetting.Source);
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(feedSetting.Url, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var feed = await response.Content.ReadAsStringAsync(cancellationToken);
                var parser = _feedParserManagers.First(x => x.Source == feedSetting.Source);
                var pageParser = _pageParsers.First(x => x.Source == feedSetting.Source);
                var posts = parser.ParseFeed(feed);
                var postsArray = posts.ToArray().Take(10).ToArray();
                _logger.LogInformation("Parsed {0} posts.", postsArray.Length);
                var fullPost = new PostDto[postsArray.Length];
                if (posts!.Any())
                {
                    for (int i = 0; i < postsArray.Length; i++)
                    {
                        var post = await pageParser.LoadDataAsync(postsArray[i], cancellationToken);
                        fullPost[i] = post;
                    }
                }

                if (fullPost.Any())
                {
                    await _postManager.AddRangePostsAsync(fullPost, cancellationToken);
                }
            }
        }
    }

    ///<inheritdoc/>
    public async Task PublishPostsAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing public posts.");
        var postDto = await _postManager.GetNotPublishedPostAsync(cancellationToken);
        if (postDto is not null)
        {
            if (await _telegramClient.SendMessageAsync(postDto.ImageUrl, postDto.ToString(), cancellationToken))
            {
                await _postManager.SetPublishedPostAsync(postDto.Id, cancellationToken);
            }
        }
    }
}