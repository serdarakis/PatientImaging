

using PatientImaging.Messages;
using PatientImaging.WebApp.Models.ViewModels;

namespace PatientImaging.WebApp.Infastructure.Mappers
{
    public static class PatientMapper
    {
        public static Messages.Patient Map(PatientViewModel patient)
        {
            var gender = patient.Gender switch
            {
                1 => Gender.Female,
                2 => Gender.Male,
                _ => Gender.NotSpecified,
            };

            return new Messages.Patient(
                patient.PolyclinicCode,
                DoctorMapper.Map(patient.Doctor),
                patient.DateOfBirth,
                gender,
                patient.IdentityNumber,
                patient.PhoneNumber,
                patient.VisitDate,
                patient.NextVisitDate,
                patient.DoctorNote
                );
        }
    }
}
