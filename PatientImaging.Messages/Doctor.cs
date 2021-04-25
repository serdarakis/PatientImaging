using System;

namespace PatientImaging.Messages
{
    public class Doctor
    {
        public string RegistrationNumber { get; }
        public string Name { get; }
        public string Surname { get; }

        public Doctor(string registrationNumber,string name, string surname)
        {
            RegistrationNumber = registrationNumber;
            Name = name;
            Surname = surname;
        }
    }
}
