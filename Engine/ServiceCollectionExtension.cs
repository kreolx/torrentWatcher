using Contracts.Interfaces;
using Engine.Managers;
using Engine.Managers.Contracts;
using Engine.Managers.Parsers.Nnmclub;
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
        
        services.AddTransient<IPageParserManager, RutrackerPageParserManager>();
        services.AddTransient<IFeedParserManager, RutrackerFeedParseManager>();

        services.AddTransient<IFeedParserManager, NnmFeedParserManager>();
        services.AddTransient<IPageParserManager, NnmPageParserManager>();
        
        services.AddTransient<IFeedManager, FeedManager>();
        services.AddTransient<IMainManager, MainManager>();
        services.AddHttpClient();

        //services.AddHostedService<ParseHostedService>();
        //services.AddHostedService<PublishHostedService>();
        return services;
    }
}