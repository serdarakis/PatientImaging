using Microsoft.AspNetCore.SignalR;
using PatientImaging.Messages;
using PatientImaging.WebApp.Infastructure.Services;
using System.Threading.Tasks;

namespace PatientImaging.WebApp.Infastructure.Hubs
{
    public class PatientHub:Hub<IPatientHub>
    {
        private IPatientService _patientService;

        public PatientHub(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public async Task PatientFound(Patient patient)
        {
            await _patientService.InsertPatient(patient);
            await PatientAdded(patient);
        }
        
        public async Task PatientAdded(Patient patient)
        {
            await Clients.All.PatientAdded(patient);
        }
    }

    public interface IPatientHub
    {
        Task PatientFound(Patient patient);
        Task PatientAdded(Patient patient);
    }
}
