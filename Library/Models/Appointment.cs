
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Library.Models
{
    public class Appoinments
    {
        [Key]
        public int Appoinment_ID { get; set; }

        [ForeignKey("Patient")]
        public int Patient_ID { get; set; }

        [ForeignKey("Doctor")]
        public int Doctor_ID { get; set; }

        public string? Reason_of_visit { get; set; }
        public string? Status { get; set; } = "waiting";


        [RegularExpression(@"^(admitted)$")]
        public string? Patient_Status { get; set; } = "consulting";
        public string? Diagnosis { get; set; }
        public string? Treatment { get; set; }
        public Doctor? Doctor { get; set; }
        public Patients? Patient { get; set; }
    }
}
