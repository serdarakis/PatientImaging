
using PatientImaging.FileTracker.Models;

namespace PatientImaging.FileTracker.Mappers
{
    public static class PatientMapper
    {
        public static Messages.Patient Map(PatientXmlModel patient)
        {
            return new Messages.Patient(
                patient.polyclinicCodeField,
                DoctorMapper.Map(patient.doctorField),
                patient.dateOfBirthField,
                patient.genderField,
                patient.identityNumberField,
                patient.phoneNumberField,
                patient.visitDateField,
                patient.nextVisitDateField,
                patient.doctorNoteField
                );
        }
    }
}
