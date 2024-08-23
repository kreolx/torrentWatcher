using Contracts.Interfaces;
using Contracts.Models;
using Engine.Managers.Contracts;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;

namespace Engine.Managers.Parsers.Nnmclub;

internal sealed class NnmPageParserManager : IPageParserManager
{
    public NnmPageParserManager(IHttpTrackerClient httpClient, ILogger<NnmPageParserManager> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public Source Source { get; } = Source.Nnmclub;
    private readonly IHttpTrackerClient _httpClient;
    private readonly ILogger<NnmPageParserManager> _logger;
    public async Task<PostDto> LoadDataAsync(PostDto postDto, CancellationToken cancellationToken)
    {
        string description = string.Empty;
        string imageUrl = string.Empty;
        string? magnet = null;
        if (string.IsNullOrEmpty(postDto.Link)) return postDto;
        try
        {
            string html = await _httpClient.GetAsync(postDto.Link, cancellationToken);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var descBody = htmlDocument.DocumentNode?.SelectSingleNode("//*[contains(text(),'Описан')]")?.NextSibling?.NextSibling;
            description = HtmlEntity.DeEntitize(descBody?.InnerText);
            var linkNodes = htmlDocument.DocumentNode?.SelectNodes("//a");
            if (linkNodes?.Count > 0)
            {
                foreach (var node in linkNodes)
                {
                    var titleAttr = node.Attributes.FirstOrDefault(x => x.Name == "title");
                    if (titleAttr?.Value.Equals("Примагнититься") ?? false)
                    {
                        magnet = node.Attributes["href"].Value;
                        break;
                    }
                }
            }
            //https://nnmstatic.win/forum/image.php?link=https://i123.fastpic.org/big/2024/0822/43/e4d173f6abf94a1240c9b189fb1b5743.jpeg
            var imageNodes = htmlDocument.DocumentNode?.SelectNodes("//*[contains(@class, 'postImg')]");
            if (imageNodes?.Count > 0)
            {
                foreach (var imageNode in imageNodes)
                {
                    if (imageNode.Attributes.Contains("title") && imageNode.Attributes["title"].Value.Contains("big"))
                    {
                        var fullLink = imageNode.Attributes["title"].Value;
                        imageUrl = fullLink.Split("=")[^1];
                        break;
                    }
                }
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
        }
        
        postDto = postDto with
        {
            Description = description,
            ImageUrl = imageUrl,
            Magnet = magnet
        };
        return postDto;
    }
}