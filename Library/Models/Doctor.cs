﻿
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }
        [Required]
        public string? DoctorName { get; set; }
        [Required]
        [Range(1, 150)]
        public int Age { get; set; }
        [Required]
        [RegularExpression("^(male|female|other)$")]
        public string? Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string? Specialization { get; set; }
        [Required]
        [EmailAddress]
        public string? DoctorEmail { get; set; }
        [Required]
        public string? DoctorAddress { get; set; }
        [Required]
        public int DoctorMobile { get; set; }
        [Required]
        public int EmergencyNo { get; set; }
        [Required]
        public string? Doctor_Experience { get; set; }
        [Required]
        public string? Constulting_Day { get; set; }
        [Required]
        public DateTime Constulting_Time { get; set; }
        [Required]
        public string? Username { get; set; }
        public string? HashedPassword { get; set; }

        [Required]
        [RegularExpression("^(success)$")]
        public string Status { get; set; } = "pending";
        public string? Review { get; set; }
        public DateTime LastLogin { get; set; }

        public string? ImageName { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
        public ICollection<Patients>? Patient { get; set; }
    }
}
