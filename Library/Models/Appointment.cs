
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Library.Models
{
    public class Appointment
    {
        [Key]
        public int Appoinment_ID { get; set; }

        [ForeignKey("Doctor")]
        public int Doctor_ID { get; set; }
        [ForeignKey("Patients")]
        public int Patient_ID { get; set; }
        public string? Consultation { get; set; }
        public string? Status { get; set; }
        public Doctor? Doctor { get; set; }
        public Patients? Patient { get; set; }
    }
}
