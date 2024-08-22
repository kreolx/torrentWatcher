using Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Engine.Managers;

internal sealed class PublishHostedService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public PublishHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));
        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {
                var scope = _serviceProvider.CreateScope();
                var mainManager = scope.ServiceProvider.GetRequiredService<IMainManager>();
                await mainManager.PublishPostsAsync(stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}