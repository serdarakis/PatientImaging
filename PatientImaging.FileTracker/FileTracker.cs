
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PatientImaging.FileTracker
{
    public class FileTracker : BackgroundService
    {
        private readonly ILogger<FileTracker> _logger;
        

        public FileTracker(ILogger<FileTracker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var hub = new HubConnectionBuilder();
                hub.WithUrl("http://localhost:13391/patientHub");
                hub.WithAutomaticReconnect();
                var hb = hub.Build();
                await hb.StartAsync();

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Checking XML files at: {time}", DateTimeOffset.Now);
                    await hb.SendAsync("SendMessage", "Serdar", "Data", stoppingToken);

                    hb.On<string, string>("ReceiveMessage", (user, message) =>
                    {
                        _logger.LogInformation("Message Resived At: {time}", DateTimeOffset.Now);
                        _logger.LogInformation("User: {user}", user);
                        _logger.LogInformation("Message: {message}", message);
                    });

                    await Task.Delay(1000, stoppingToken);
                }
                await hb.StopAsync();
                await hb.DisposeAsync();
            }
            catch (Exception e)
            {

            }

        }
    }

}
