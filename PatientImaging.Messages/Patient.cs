
using System;

namespace PatientImaging.Messages
{
    public class Patient
    {

        public string PolyclinicCode { get; }
        public Doctor Doctor { get; }
        public DateTime DateOfBirth { get; }
        public Gender Gender { get; }
        public string IdentityNumber { get; }
        public string PhoneNumber { get; }
        public DateTime VisitDate { get; }
        public DateTime NextVisitDate { get; }
        public string DoctorNote { get; }

        public Patient(string polyclinicCode,
            Doctor doctor,
            DateTime dateOfBirth,
            Gender gender,
            string identityNumber,
            string phoneNumber,
            DateTime visitDate,
            DateTime nextVisitDate,
            string doctorNote)
        {
            PolyclinicCode = polyclinicCode;
            Doctor = doctor;
            DateOfBirth = dateOfBirth;
            Gender = Gender;
            IdentityNumber = identityNumber;
            PhoneNumber = phoneNumber;
            VisitDate = visitDate;
            NextVisitDate = nextVisitDate;
            DoctorNote = doctorNote;
        }
    }
}
