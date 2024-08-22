using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace CommandApi;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCommandApi(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        return services;
    }
}