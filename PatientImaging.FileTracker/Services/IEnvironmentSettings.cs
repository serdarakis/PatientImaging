
using System;
using System.Collections;

namespace PatientImaging.FileTracker.Services
{
    public interface IEnvironmentSettings
    {
        string HubConnectionUrl { get; }
    }

    internal class EnvironmentSettings : IEnvironmentSettings
    {
        private const string HubConnectionUrlName = "HubConnectionUrl";
        
        private readonly string _hubConnectionUrl;

        public EnvironmentSettings()
        {
            _hubConnectionUrl = Environment.GetEnvironmentVariable(HubConnectionUrlName);
        }

        public string HubConnectionUrl => _hubConnectionUrl;
    }
}
