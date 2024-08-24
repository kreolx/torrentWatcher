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
            Headless = false,
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
        await page.SetCookieAsync(new CookieParam[]
        {
            new CookieParam()
            {
                Name = "_ym_d",
                Value = "1716961158",
                Domain = ".nnmclub.to",
                Path = "/",
            },
            new CookieParam()
            {
                Name = "_ym_isad",
                Value = "1",
                Domain = ".nnmclub.to",
                Path = "/",
            },
            new CookieParam()
            {
                Name = "_ym_uid",
                Value = "1669446022884473237",
                Domain = ".nnmclub.to",
                Path = "/",
            },
            new CookieParam()
            {
                Name = "cf_clearance",
                Value =
                    "T0YvHmJmDtS8bQpaXGU9xPpuWLSiYiQ8sirpSaOigNQ-1712309402-1.0.1.1-xvVFH1RlKcIbXxSKJV2i0k0dJ7cbMUJgzwyr5c_yi6MVHdK.8Wpcq5pAOCRfyOSNKflIfUuViy.QV.zZejhXzg",
                Domain = ".nnmclub.to",
                Path = "/",
            },
            new CookieParam()
            {
                Name = "phpbb2mysql_4_data",
                Value =
                    "a%3A2%3A%7Bs%3A11%3A%22autologinid%22%3Bs%3A32%3A%22e0e9810ab5c4968ae391b642c99e2461%22%3Bs%3A6%3A%22userid%22%3Bi%3A7979410%3B%7D",
                Domain = ".nnmclub.to",
                Path = "/",
            },
            new CookieParam()
            {
                Name = "phpbb2mysql_4_sid",
                Value = "41641e2e6357ae97ebd8eac40e4d5a4e",
                Domain = ".nnmclub.to",
                Path = "/",
            },
            new CookieParam()
            {
                Name = "phpbb2mysql_4_t",
                Value =
                    "a%3A12%3A%7Bi%3A1743567%3Bi%3A1723882456%3Bi%3A1446397%3Bi%3A1723882631%3Bi%3A1743839%3Bi%3A1724046913%3Bi%3A1743830%3Bi%3A1724046921%3Bi%3A1743825%3Bi%3A1724046926%3Bi%3A1744757%3Bi%3A1724474644%3Bi%3A1744532%3Bi%3A1724398469%3Bi%3A1744486%3Bi%3A1724398520%3Bi%3A1744589%3Bi%3A1724404844%3Bi%3A1743661%3Bi%3A1724406108%3Bi%3A1744920%3Bi%3A1724474512%3Bi%3A1674351%3Bi%3A1724474603%3B%7D",
                Domain = ".nnmclub.to",
                Path = "/",
            },
        });
        var response = await page.GoToAsync(url, WaitUntilNavigation.Networkidle2);
        html = await response.TextAsync();
        _logger.LogInformation(html);
        return html;
    }
}