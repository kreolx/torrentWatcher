﻿using Contracts.Interfaces;
using Engine.Managers.Contracts;
using Microsoft.Extensions.Logging;

namespace Engine.Managers;

internal sealed class MainManager : IMainManager
{
    private readonly IFeedManager _feedManager;
    private readonly IPostManager _postManager;
    private readonly IEnumerable<IFeedParserManager> _feedParserManagers;
    private readonly IEnumerable<IPageParserManager> _pageParsers;
    private readonly IHttpTrackerClient _httpClient;
    private readonly ITelegramClient _telegramClient;
    private readonly ILogger<MainManager> _logger;

    public MainManager(IFeedManager feedManager, IPostManager postManager, IEnumerable<IFeedParserManager> feedParserManagers,
        IEnumerable<IPageParserManager> pageParsers, IHttpTrackerClient httpClient, ILogger<MainManager> logger, ITelegramClient telegramClient)
    {
        _feedManager = feedManager;
        _postManager = postManager;
        _feedParserManagers = feedParserManagers;
        _pageParsers = pageParsers;
        _httpClient = httpClient;
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
            try
            {
                _logger.LogInformation("Processing feed: {0} {1}", feedSetting.Source, feedSetting.Url);
                var feed = await _httpClient.GetAsync(feedSetting.Url, cancellationToken);
                var parser = _feedParserManagers.First(x => x.Source == feedSetting.Source);
                var pageParser = _pageParsers.First(x => x.Source == feedSetting.Source);
                var posts = parser.ParseFeed(feed);
                var postsArray = posts.ToArray().Take(5).ToArray();
                _logger.LogInformation("Parsed {0} posts.", postsArray.Length);
                if (posts!.Any())
                {
                    for (int i = 0; i < postsArray.Length; i++)
                    {
                        var post = await pageParser.LoadDataAsync(postsArray[i], cancellationToken);
                        await _postManager.AddNewPostAsync(post, cancellationToken);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message, e.StackTrace);
            }
        }
    }

    ///<inheritdoc/>
    public async Task PublishPostsAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing public posts.");
        int i = 0;
        do
        {
            var postDto = await _postManager.GetNotPublishedPostAsync(cancellationToken);
            if (postDto is not null)
            {
                var result =
                    await _telegramClient.SendMessageAsync(postDto.ImageUrl, postDto.ToString(), cancellationToken);
                await _postManager.SetPublishedPostAsync(postDto.Id, result, cancellationToken);
            }
            else
            {
                break;
            }
            i++;
        } while (i < 10);
    }
}