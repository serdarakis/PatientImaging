
namespace PatientImaging.Messages
{
    public class Patient
    {

		public string PolyclinicCode { get; set; }
		public Doctor Doctor { get; set; }
		public string DateOfBirth { get; set; }		
		public int Gender { get; set; }
		public double IdentityNumber { get; set; }
		public int PhoneNumber { get; set; }		
		public string VisitDate { get; set; }		
		public string NextVisitDate { get; set; }
		public string DoctorNote { get; set; }
	}
}
