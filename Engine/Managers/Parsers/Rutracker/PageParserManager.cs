﻿using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;
using Contracts.Models;
using Engine.Managers.Contracts;
using HtmlAgilityPack;

[assembly: InternalsVisibleTo("Test.Engine")]
namespace Engine.Managers.Parsers.Rutracker;

internal sealed class PageParserManager : IPageParserManager
{
    public Source Source { get; } = Source.Rutracker;
    private readonly IHttpClientFactory  _httpClientFactory;

    public PageParserManager(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    ///<inheritdoc />
    public async Task<PostDto> LoadDataAsync(PostDto postDto, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(postDto.Link)) return postDto;
        var httpClient = _httpClientFactory.CreateClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, new Uri(postDto.Link));
        request.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
        request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
        request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
        request.Headers.TryAddWithoutValidation("Accept-Charset", "windows-1251");

        using var response = await httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        await using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        await using var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress);
        using var streamReader = new StreamReader(decompressedStream);
        using var memoryStream = new MemoryStream();
        await decompressedStream.CopyToAsync(memoryStream, cancellationToken);
        var bytes = memoryStream.ToArray();
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding encoding = Encoding.GetEncoding("windows-1251");
        string html = encoding.GetString(bytes, 0, bytes.Length);
        string description = string.Empty;
        string imageUrl = string.Empty;
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);
        var descBody = htmlDocument.DocumentNode.SelectSingleNode("//*[contains(text(),'Описан')]")?.NextSibling;
        description = HtmlEntity.DeEntitize(descBody?.InnerText);
        var imageNodes = htmlDocument.DocumentNode.SelectNodes("//*[contains(@class, 'postImg')]");
        if (imageNodes.Count > 0)
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
            
        postDto = postDto with
        {
            Description = description,
            ImageUrl = imageUrl
        };
        return postDto;
    }

    
}