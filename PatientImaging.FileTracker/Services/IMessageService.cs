using Microsoft.AspNetCore.SignalR.Client;
using PatientImaging.FileTracker.Mappers;
using PatientImaging.FileTracker.Models;
using System.Threading.Tasks;

namespace PatientImaging.FileTracker.Services
{
    internal interface IMessageService
    {
        Task Start();
        Task Stop();
        Task SendPatient(PatientXmlModel patient);
    }

    internal class MessageService : IMessageService
    {
        private const string MessageName = "PatientFound";
        private readonly HubConnection _hub;

        public MessageService(IHubConnectionBuilder hubConnectionBuilder)
        {
            _hub = hubConnectionBuilder.Build();
        }

        public Task Start() => _hub.StartAsync();
        public async Task Stop()
        {
            await _hub.StopAsync();
            await _hub.DisposeAsync();
        }

        public async Task SendPatient(PatientXmlModel patient)
        {
            await _hub.SendAsync(MessageName, PatientMapper.Map(patient));
        }
    }
}
