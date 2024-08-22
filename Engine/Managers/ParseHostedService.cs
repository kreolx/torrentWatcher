using Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Engine.Managers;

internal sealed class ParseHostedService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public ParseHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        
        try
        {
            using var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                var scope = _serviceProvider.CreateScope();
                var mainManager = scope.ServiceProvider.GetRequiredService<IMainManager>();
                await mainManager.StartAsync(stoppingToken);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
}