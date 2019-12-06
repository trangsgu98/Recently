using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore;
using ApplicationCore.Entities;
namespace ApplicationCore.DTO
{
    public class PatientsDTO
    {
        //enum Gender { Nam = "Nam", Nu = "Nữ"}
        [Display(Name = "Patient Id")]
        public string PatientId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        public Gender Gender{get; set;}

        [DataType(DataType.Date)]
       // [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Employee Address is required")]
        [StringLength(300)]
        //[DisplayFormat(DataFormatString = "{0:1:2:3:4}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public Address Address { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string Phone { get; set; }
    }
}