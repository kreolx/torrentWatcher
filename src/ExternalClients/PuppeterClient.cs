using Contracts.Interfaces;
using Microsoft.Extensions.Logging;
using PuppeteerSharp;

namespace ExternalClients;

internal sealed class PuppeterClient : IHttpTrackerClient
{
    private readonly ILogger<PuppeterClient> _logger;

    public PuppeterClient(ILogger<PuppeterClient> logger)
    {
        _logger = logger;
    }

    public async Task<string?> GetAsync(string url, CancellationToken cancellationToken)
    {
        string? html = null;
        await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true,
            Args = new[] { "--no-sandbox" },
            SlowMo = 10,
        });
        await using var page = await browser.NewPageAsync();
        await page.SetExtraHttpHeadersAsync(new Dictionary<string, string>
        {
            {
                "User-Agent",
                "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 YaBrowser/24.7.0.0 Safari/537.36"
            },
            {
                "Accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
            }
        });
        var response = await page.GoToAsync(url, WaitUntilNavigation.Networkidle2);
        html = await response.TextAsync();
        _logger.LogInformation(html);
        return html;
    }
}