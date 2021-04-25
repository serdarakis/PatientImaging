
using PatientImaging.Helpers;
using System;
using System.Xml.Serialization;

namespace PatientImaging.FileTracker.Models
{
	[XmlRoot(ElementName = "Doctor")]
    public class DoctorXmlModel
	{
		internal string registrationNumberField { get; private set; }
        internal string nameField { get; private set; }
        internal string surnameField { get; private set; }


        [XmlElement(ElementName = "RegistrationNumber")]
		public string RegistrationNumber
        {
            get
            {
                return registrationNumberField;
            }
            set
            {
                if (value != null && value.Length != 8 && !value.IsOnlyNumbers())
                    throw new ArgumentException($"{nameof(registrationNumberField)} must have only 8 numbers.");
                registrationNumberField = value;
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
    }
}
