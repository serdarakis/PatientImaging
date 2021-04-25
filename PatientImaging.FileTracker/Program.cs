using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientImaging.FileTracker.Services;

namespace PatientImaging.FileTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<FileTracker>();
                    services.AddSingleton<IFileService, FileService>();
                    services.AddSingleton<IMessageService, MessageService>();
                    services.AddSingleton<IEnvironmentSettings, EnvironmentSettings>();
                    services.AddSingleton<IHubConnectionBuilder, HubConnectionBuilder>((serviceProvider) =>
                    {
                        var builder = new HubConnectionBuilder();
                        var settings = serviceProvider.GetRequiredService<IEnvironmentSettings>();
                        return (HubConnectionBuilder) builder.WithAutomaticReconnect().WithUrl(settings.HubConnectionUrl);
                    });
                });
    }
}
