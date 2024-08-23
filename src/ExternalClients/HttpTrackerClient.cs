using System.IO.Compression;
using System.Text;
using Contracts.Interfaces;
using Microsoft.Extensions.Logging;

namespace ExternalClients;

public class HttpTrackerClient : IHttpTrackerClient
{
    private readonly IHttpClientFactory  _httpClientFactory;
    private readonly ILogger<HttpTrackerClient> _logger;

    public HttpTrackerClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> GetAsync(string url, CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
        request.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
        request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
        request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
        request.Headers.TryAddWithoutValidation("Accept-Charset", "windows-1251");

        try
        {
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
            return html;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "HttpTrackerClientError {0} {1}", e.Message, e.StackTrace);
            throw;
        }
    }
}