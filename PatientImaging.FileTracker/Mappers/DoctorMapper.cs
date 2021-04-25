using PatientImaging.FileTracker.Models;
using PatientImaging.Messages;

namespace PatientImaging.FileTracker.Mappers
{
    public static class DoctorMapper
    {
        public static Doctor Map(DoctorXmlModel doctor)
        {
            return new Messages.Doctor(
                    doctor.registrationNumberField,
                    doctor.nameField,
                    doctor.surnameField
                );
        }
    }
}
