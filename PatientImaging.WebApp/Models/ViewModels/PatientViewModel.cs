using System;
using System.ComponentModel.DataAnnotations;

namespace PatientImaging.WebApp.Models.ViewModels
{
    public class PatientViewModel
    {
        public string PolyclinicCode { get; set;}
        public DoctorViewModel Doctor { get; set;}
        

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy}")]
        public DateTime DateOfBirth { get; set;}
        public int Gender { get; set;}
        public string IdentityNumber { get; set;}
        public string PhoneNumber { get; set;}
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy}")]
        public DateTime VisitDate { get; set;}
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy}")]
        public DateTime? NextVisitDate { get; set;}
        public string DoctorNote { get; set;}
    }
}
