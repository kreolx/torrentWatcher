using System.IO.Compression;
using System.Text;
using Contracts.Interfaces;
using Microsoft.Extensions.Logging;

namespace ExternalClients;

public class HttpTrackerClient : IHttpTrackerClient
{
    private readonly IHttpClientFactory  _httpClientFactory;
    private readonly ILogger<HttpTrackerClient> _logger;

    public HttpTrackerClient(IHttpClientFactory httpClientFactory, ILogger<HttpTrackerClient> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<string> GetAsync(string url, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(url)) throw new ArgumentNullException(nameof(url));
        var httpClient = _httpClientFactory.CreateClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
        request.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
        request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate, br, zstd");
        request.Headers.TryAddWithoutValidation("Accept-Language", "ru,en;q=0.9");
        request.Headers.TryAddWithoutValidation("User-Agent", "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 YaBrowser/24.7.0.0 Safari/537.36");
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