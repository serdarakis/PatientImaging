using System.Xml.Serialization;

namespace PatientImaging.FileTracker.Models
{
	[XmlRoot(ElementName = "Patient")]
	public class Patient
	{

		[XmlElement(ElementName = "PolyclinicCode")]
		public string PolyclinicCode { get; set; }

		[XmlElement(ElementName = "Doctor")]
		public Doctor Doctor { get; set; }

		[XmlElement(ElementName = "DateOfBirth")]
		public string DateOfBirth { get; set; }

		[XmlElement(ElementName = "Gender")]
		public int Gender { get; set; }

		[XmlElement(ElementName = "IdentityNumber")]
		public double IdentityNumber { get; set; }

		[XmlElement(ElementName = "PhoneNumber")]
		public int PhoneNumber { get; set; }

		[XmlElement(ElementName = "VisitDate")]
		public string VisitDate { get; set; }

		[XmlElement(ElementName = "NextVisitDate")]
		public string NextVisitDate { get; set; }

		[XmlElement(ElementName = "DoctorNote")]
		public string DoctorNote { get; set; }
	}

}
