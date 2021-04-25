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
                _logger.LogInformation("Message service connecting {time}", DateTimeOffset.Now);
                await _messageService.Start();
                _logger.LogInformation("Message service connected {time}", DateTimeOffset.Now);
                while (!stoppingToken.IsCancellationRequested)
                {
                    await CheckFiles();
                    await Task.Delay(1000, stoppingToken);
                }
                await _messageService.Stop();
            }
            catch (Exception e)
            {
                _logger.LogInformation("Application offline {time} because of {exception} Exception", DateTimeOffset.Now, e);
            }

        }

        private async Task CheckFiles()
        {
            _logger.LogInformation("Checking XML files at: {time}", DateTimeOffset.Now);
            List<string> files = _fileService.GetNewFilesPath();
            _logger.LogInformation(files.Count == 0 ? "No new file founded" : "{count} new files founded", files.Count);

            foreach (var file in files)
            {
                try
                {
                    PatientXmlModel patient = await _fileService.ParseXMLFile<PatientXmlModel>(file);
                    await _messageService.SendPatient(patient);
                    _fileService.SetAsTransfered(file);
                }
                catch (Exception e)
                {
                    _logger.LogInformation("File {file}can not processed because of {exception} Exception", file, e);
                }

            }

        }
    }

}
