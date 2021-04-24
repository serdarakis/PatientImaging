using Microsoft.AspNetCore.SignalR.Client;
using PatientImaging.FileTracker.Models;
using System;
using System.Threading.Tasks;

namespace PatientImaging.FileTracker.Services
{
    internal interface IMessageService
    {
        Task Start();
        Task Stop();
        Task SendPatient(Patient patient);
    }

    internal class MessageService : IMessageService
    {
        private const string MessageName = "PatientFound";
        private HubConnection _hub;

        public MessageService()
        {
            var hubBuilder = new HubConnectionBuilder();
            hubBuilder.WithUrl("http://localhost:13391/patientHub");
            hubBuilder.WithAutomaticReconnect();
            _hub = hubBuilder.Build();
            _hub.On<Messages.Patient>("ReceiveMessage", (patient) =>
             {
                 Console.WriteLine(patient.Doctor.Name);
             });
        }

        public Task Start() => _hub.StartAsync();
        public async Task Stop()
        {
            await _hub.StopAsync();
            await _hub.DisposeAsync();
        }

        public async Task SendPatient(Patient patient)
        {
            var data = new PatientImaging.Messages.Patient
            {
                Gender = patient.Gender,
                IdentityNumber = patient.IdentityNumber,
                Doctor = new Messages.Doctor
                {
                    Name = patient.Doctor.Name
                }
            };
            await _hub.SendAsync(MessageName, data);
        }
    }
}
