
using System.Xml.Serialization;

namespace PatientImaging.FileTracker.Models
{
	[XmlRoot(ElementName = "Doctor")]
    public class Doctor
	{

		[XmlElement(ElementName = "RegistrationNumber")]
		public int RegistrationNumber { get; set; }

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "Surname")]
		public string Surname { get; set; }
	}
}
