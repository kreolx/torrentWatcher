using System.IO.Compression;
using System.Net.Http.Json;
using System.Text.Json;
using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TelegramClient.Models;

namespace TelegramClient;

internal sealed class Client : ITelegramClient
{
    private readonly TelegramSettings _settings;
    private readonly IHttpClientFactory  _httpClientFactory;
    private readonly ILogger<Client> _logger;

    public Client(IOptionsMonitor<TelegramSettings> settings, IHttpClientFactory httpClientFactory, ILogger<Client> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _settings = settings.CurrentValue;
    }

    public async Task<PublishResult> SendMessageAsync(string? imageUrl, string message, CancellationToken cancellationToken)
    {
        bool success = false;
        string? errorMessage = null;
        try
        {
            var url = string.IsNullOrEmpty(imageUrl) ? $"https://api.telegram.org/bot{_settings.Token}/sendMessage?chat_id={_settings.ChatId}"
                : $"https://api.telegram.org/bot{_settings.Token}/sendPhoto?chat_id={_settings.ChatId}";
            var httpClient = _httpClientFactory.CreateClient();
            using var request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
            request.Headers.TryAddWithoutValidation("Accept", "application/json");
            request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
            request.Content = string.IsNullOrEmpty(imageUrl) ? JsonContent.Create(new
            {
                text = message, disable_web_page_preview = false, disable_notification = false, parse_mode = "HTML"
            })
                :
            JsonContent.Create(new
            {
                photo = imageUrl, caption = message, disable_web_page_preview = false, disable_notification = false,
                parse_mode = "HTML"
            });
            using var response = await httpClient.SendAsync(request, cancellationToken);
            //response.EnsureSuccessStatusCode();
            await using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken);
            using var reader = new StreamReader(responseStream);
            var result = await reader.ReadToEndAsync(cancellationToken);
            var telegramResponse = JsonSerializer.Deserialize<TelegramResult>(result);
            if (!telegramResponse?.Ok ?? true)
            {
                _logger.LogError("Error while sending message {0} {1}",telegramResponse?.ErrorCode, telegramResponse?.Description);
            }
            else
            {
                success = true;
            }
            
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            errorMessage = e.Message;
        }
        
        return new PublishResult(success, errorMessage);
    }
}