
using System.ComponentModel.DataAnnotations;


namespace Library.Models
{
    public class Doctor
    {
        [Key]
        public int Doctor_ID { get; set; }
        [Required]
        public string? Doctor_Name { get; set; }
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
        public string? Doctor_Email { get; set; }
        [Required]
        public string? Doctor_Address { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$")]
        public int Doctor_Mobile { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$")]
        public int Emergency_No { get; set; }
        [Required]
        public string? Doctor_Experience { get; set; }
        [Required]
        public string? Constulting_Day { get; set; }
        [Required]
        public DateTime Constulting_Time { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [RegularExpression("^(success)$")]
        public string Status { get; set; } = "pending";
        public string? Review { get; set; }
        public DateTime LastLogin { get; set; }
        public ICollection<Patient>? Patients { get; set; }
    }
}
