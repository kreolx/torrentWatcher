using Contracts.Interfaces;
using Contracts.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TelegramClient;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddTelegramClient(this IServiceCollection services, IConfiguration configuration)
    {
        var sect = configuration.GetSection(nameof(TelegramSettings));
        services.AddOptions<TelegramSettings>().Bind(sect);
        
        services.AddTransient<ITelegramClient, Client>();
        return services;
    }
}