
using System.ComponentModel.DataAnnotations;


namespace Library.Models
{
    public class Patients
    {
        [Key]
        public int Patient_ID { get; set; }

        [Required]
        public string? Patient_Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [RegularExpression("^(male|female|other)$")]
        public string? Gender { get; set; }
        [Required]
        public string? BloodGroup { get; set; }
        [Required]
        public string? Patient_Address { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$")]
        public long Patient_Phone { get; set; }
        [Required]
        [EmailAddress]
        public string? Patient_Email { get; set; }
        [Required]
        public string? Patient_UserName { get; set; }
        [Required]
        public string? Patient_HashedPassword { get; set; }



    }
}
