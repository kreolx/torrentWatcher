using Contracts.Interfaces;
using Contracts.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExternalClients;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddTelegramClient(this IServiceCollection services, IConfiguration configuration)
    {
        var sect = configuration.GetSection(nameof(TelegramSettings));
        services.AddOptions<TelegramSettings>().Bind(sect);
        
        services.AddTransient<ITelegramClient, TelegramClient>();
        //services.AddTransient<IHttpTrackerClient, HttpTrackerClient>();
        services.AddTransient<IHttpTrackerClient, PuppeterClient>();
        services.AddHttpClient();
        return services;
    }
}