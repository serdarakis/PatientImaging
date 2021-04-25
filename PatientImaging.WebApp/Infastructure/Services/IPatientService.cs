using Microsoft.AspNetCore.SignalR;
using PatientImaging.Messages;
using PatientImaging.WebApp.Infastructure.Hubs;
using PatientImaging.WebApp.Infastructure.Mappers;
using PatientImaging.WebApp.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientImaging.WebApp.Infastructure.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task InsertPatient(PatientViewModel patient);
        Task InsertPatient(Patient patient);
    }

    internal class PatientService : IPatientService
    {
        List<Patient> patients = new List<Patient>();
        private IHubContext<PatientHub, IPatientHub> _hubContext;

        public PatientService(IHubContext<PatientHub,IPatientHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            await Task.Delay(100);
            return patients;
        }

        public async Task InsertPatient(PatientViewModel patient)
        {
            var patentModel = PatientMapper.Map(patient);
            patients.Add(patentModel);
            await _hubContext.Clients.All.PatientAdded(patentModel);
        }

        public async Task InsertPatient(Patient patient)
        {
            patients.Add(patient);
            await _hubContext.Clients.All.PatientAdded(patient);
        }
    }
}
