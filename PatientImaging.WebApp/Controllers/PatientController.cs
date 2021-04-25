using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientImaging.Messages;
using PatientImaging.WebApp.Infastructure.Services;
using PatientImaging.WebApp.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientImaging.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
      
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientService _patientService;

        public PatientController(ILogger<PatientController> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IEnumerable<Patient>> List()
        {
            return await _patientService.GetAllPatients();
        }

        [HttpPost]
        public async Task Insert([FromBody] PatientViewModel patient)
        {
            await _patientService.InsertPatient(patient);
        }
    }
}
