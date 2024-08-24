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
        string html = null;
        await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true,
            Args = new[] { "--no-sandbox" },
            SlowMo = 10,
        });
        await using var page = await browser.NewPageAsync();
        await page.SetJavaScriptEnabledAsync(true);
        var response = await page.GoToAsync(url, WaitUntilNavigation.Networkidle2);
        html = await response.TextAsync();
        _logger.LogInformation(html);
        return html;
    }
}