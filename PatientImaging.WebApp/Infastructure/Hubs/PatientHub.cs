using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace PatientImaging.WebApp.Infastructure.Hubs
{
    public class PatientHub:Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        
    }
}
