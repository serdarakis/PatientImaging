using Microsoft.AspNetCore.SignalR;
using PatientImaging.Messages;
using System.Threading.Tasks;
using System.Timers;

namespace PatientImaging.WebApp.Infastructure.Hubs
{
    public class PatientHub:Hub
    {

        public async Task PatientFound(Patient patient)
        {
            await Clients.All.SendAsync("ReceiveMessage", patient);
        }
        
    }
}
