using PatientImaging.Messages;
using PatientImaging.WebApp.Models.ViewModels;

namespace PatientImaging.WebApp.Infastructure.Mappers
{
    public static class DoctorMapper
    {
        public static Doctor Map(DoctorViewModel doctor)
        {
            return new Messages.Doctor(
                    doctor.RegistrationNumber,
                    doctor.Name,
                    doctor.Surname
                );
        }
    }
}
