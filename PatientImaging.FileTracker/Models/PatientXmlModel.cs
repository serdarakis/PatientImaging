using PatientImaging.Helpers;
using System;
using System.Xml.Serialization;

namespace PatientImaging.FileTracker.Models
{
    [XmlRoot(ElementName = "Patient")]
    public class PatientXmlModel
    {
        internal string polyclinicCodeField { get; private set; }
        internal DoctorXmlModel doctorField { get; private set; }
        internal string nameField { get; private set; }
        internal string surnameField { get; private set; }
        internal DateTime dateOfBirthField { get; private set; }
        internal GenderXmlModel genderField { get; private set; }
        internal string identityNumberField { get; private set; }
        internal string phoneNumberField { get; private set; }
        internal DateTime visitDateField { get; private set; }
        internal DateTime nextVisitDateField { get; private set; }
        internal string doctorNoteField { get; private set; }



        [XmlElement(ElementName = "PolyclinicCode")]
        public string PolyclinicCode
        {
            get
            {
                return polyclinicCodeField;
            }
            set
            {
                if (value == null || value.Length != 4)
                    throw new ArgumentException($"{nameof(PolyclinicCode)} must have only 4 char.");
                polyclinicCodeField = value;
            }
        }

        [XmlElement(ElementName = "Doctor")]
        public DoctorXmlModel Doctor
        {
            get
            {
                return doctorField;
            }
            set
            {
                doctorField = value ?? throw new ArgumentNullException(nameof(Doctor));
            }
        }

        [XmlElement(ElementName = "Name")]
        public string Name
        {
            get
            {
                return nameField;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"{nameof(Name)} can not be null or empty");

                nameField = value;
            }
        }

        [XmlElement(ElementName = "Surname")]
        public string Surname
        {
            get
            {
                return surnameField;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"{nameof(surnameField)} can not be null or empty");

                surnameField = value;
            }
        }

        [XmlElement(ElementName = "DateOfBirth")]
        public string DateOfBirth
        {
            get
            {
                return dateOfBirthField.ToString();
            }
            set
            {
                dateOfBirthField = value.ConvertToDatetimeOrThrow(nameof(DateOfBirth));
            }
        }

        [XmlElement(ElementName = "Gender")]
        public int Gender
        {
            get { return (int)genderField; }
            set
            {
                if (!Enum.IsDefined(typeof(GenderXmlModel), value))
                    throw new ArgumentOutOfRangeException(nameof(Gender));

                genderField = (GenderXmlModel)value;
            }
        }

        [XmlElement(ElementName = "IdentityNumber")]
        public string IdentityNumber
        {
            get
            {
                return identityNumberField;
            }
            set
            {
                if (value == null || value.Length != 11 || !value.IsOnlyNumbers())
                    throw new ArgumentException($"{nameof(IdentityNumber)} must have only 11 numbers.");
                identityNumberField = value;
            }
        }

        [XmlElement(ElementName = "PhoneNumber")]
        public string PhoneNumber
        {
            get
            {
                return phoneNumberField;
            }
            set
            {
                if (value == null || value.Length != 10 || !value.IsOnlyNumbers())
                    throw new ArgumentException($"{nameof(IdentityNumber)} must have only 10 numbers.");
                phoneNumberField = value;
            }
        }

        [XmlElement(ElementName = "VisitDate")]
        public string VisitDate
        {
            get
            {
                return visitDateField.ToString();
            }
            set
            {
                visitDateField = value.ConvertToDatetimeOrThrow(nameof(VisitDate), "dd-MM-yyyy HH:mm");
            }
        }

        [XmlElement(ElementName = "NextVisitDate")]
        public string NextVisitDate
        {
            get
            {
                return nextVisitDateField.ToString();
            }
            set
            {
                nextVisitDateField = value.ConvertToDatetimeOrThrow(nameof(NextVisitDate), "dd-MM-yyyy HH:mm");
            }
        }

        [XmlElement(ElementName = "DoctorNote")]
        public string DoctorNote
        {
            get
            {
                return doctorNoteField;
            }
            set
            {
                if (value != null && value.Length > 1000)
                    throw new ArgumentException("Must be less then 1000 char", nameof(DoctorNote));

                doctorNoteField = value;
            }
        }
    }
}
