
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PatientImaging.FileTracker.Models;
using PatientImaging.FileTracker.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PatientImaging.FileTracker
{
    internal class FileTracker : BackgroundService
    {
        private readonly ILogger<FileTracker> _logger;
        private readonly IFileService _fileService;
        private readonly IMessageService _messageService;

        public FileTracker(ILogger<FileTracker> logger, IFileService fileService, IMessageService messageService)
        {
            _logger = logger;
            _fileService = fileService;
            _messageService = messageService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                //var hub = new HubConnectionBuilder();
                //hub.WithUrl("http://localhost:13391/patientHub");
                //hub.WithAutomaticReconnect();
                //var hb = hub.Build();
                //await hb.StartAsync();
                await _messageService.Start();
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Checking XML files at: {time}", DateTimeOffset.Now);
                    List<string> files = _fileService.GetNewFilesPath();
                    foreach(var file in files)
                    {
                        Patient patient = await _fileService.ParseXMLFile<Patient>(file);
                        await _messageService.SendPatient(patient);
                    }
                    //await hb.SendAsync("SendMessage", "Serdar", "Data", stoppingToken);

                    //hb.On<string, string>("ReceiveMessage", (user, message) =>
                    //{
                    //    _logger.LogInformation("Message Resived At: {time}", DateTimeOffset.Now);
                    //    _logger.LogInformation("User: {user}", user);
                    //    _logger.LogInformation("Message: {message}", message);
                    //});

                    await Task.Delay(1000, stoppingToken);
                }
                //await hb.StopAsync();
                //await hb.DisposeAsync();
                await _messageService.Stop();
            }
            catch (Exception e)
            {

            }

        }
    }

}
