using Contracts.Interfaces;
using Engine.Managers;
using Engine.Managers.Contracts;
using Engine.Managers.Parsers.Rutracker;
using Engine.Storage.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Engine;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddEngine(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
    {
        services.AddDbContext<ApplicationDbContext>(optionsAction);
        services.AddTransient<IPostManager, PostManager>();
        services.AddTransient<IPageParserManager, PageParserManager>();
        services.AddTransient<IFeedParserManager, FeedParseManager>();
        services.AddTransient<IFeedManager, FeedManager>();
        services.AddTransient<IMainManager, MainManager>();
        services.AddHttpClient();

        //services.AddHostedService<HostedService>();
        return services;
    }
}