using CommandApi;
using Engine;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TelegramClient;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) =>
{
    lc.ReadFrom.Configuration(ctx.Configuration);
});
builder.Services.AddEngine(ConfigureDbContext)
    .AddCommandApi()
    .AddTelegramClient(builder.Configuration);

builder.Services.AddSwaggerGen(options =>
{
    string[] files = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly);
    foreach (string filePath in files)
    {
        options.IncludeXmlComments(filePath, includeControllerXmlComments: true);
    }
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Commands API V1");
});

app.UseRouting();
app.MapControllers();

app.Run();


void ConfigureDbContext(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.
        UseNpgsql(builder!.Configuration.GetConnectionString("postgresConnection"),
            b =>
            {
                b.MigrationsAssembly(typeof(Program).Assembly.GetName().Name);
                b.MigrationsHistoryTable("__EFMigrationsHistory", "torrent");
            });
}