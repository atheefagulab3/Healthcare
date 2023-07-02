using System.ComponentModel.DataAnnotations;


namespace Library.Models
{
    public class Patient
    {
        [Key]
        public int Patient_ID { get; set; }

        [Required]
        public string? Patient_Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? BloodGroup { get; set; }
        [Required]
        public string? Patient_Address { get; set; }
        [Required]
        
        public long Patient_Phone { get; set; }
        [Required]
        
        public string? Patient_Email { get; set; }
        [Required]
        public string? Patient_UserName { get; set; }
        [Required]
        public string? Patient_HashedPassword { get; set; }



    }
}
