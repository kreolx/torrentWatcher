using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;
using Contracts.Interfaces;
using Contracts.Models;
using Engine.Managers.Contracts;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;

[assembly: InternalsVisibleTo("Test.Engine")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c547cac37abd99c8db225ef2f6c8a3602f3b3606cc9891605d02baa56104f4cfc0734aa39b93bf7852f7d9266654753cc297e7d2edfe0bac1cdcf9f717241550e0a7b191195b7667bb4f64bcb8e2121380fd1d9d46ad2d92d2d15605093924cceaf74c4861eff62abf69b9291ed0a340e113be11e6a7d3113e92484cf7045cc7")]
namespace Engine.Managers.Parsers.Rutracker;

internal sealed class RutrackerPageParserManager : IPageParserManager
{
    public Source Source { get; } = Source.Rutracker;
    private readonly IHttpTrackerClient _httpClient;
    private readonly ILogger<RutrackerPageParserManager> _logger;

    public RutrackerPageParserManager(ILogger<RutrackerPageParserManager> logger, IHttpTrackerClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    ///<inheritdoc />
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
            var descBody = htmlDocument.DocumentNode?.SelectSingleNode("//*[contains(text(),'Описан')]")?.NextSibling;
            description = HtmlEntity.DeEntitize(descBody?.InnerText);
            magnet = htmlDocument.DocumentNode?.SelectSingleNode("//*[contains(@class,'magnet-link')]")?.Attributes["href"].Value;
            var imageNodes = htmlDocument.DocumentNode?.SelectNodes("//*[contains(@class, 'postImg')]");
            if (imageNodes?.Count > 0)
            {
                foreach (var imageNode in imageNodes)
                {
                    if (imageNode.Attributes.Contains("title") && imageNode.Attributes["title"].Value.Contains("big"))
                    {
                        imageUrl = imageNode.Attributes["title"].Value;
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