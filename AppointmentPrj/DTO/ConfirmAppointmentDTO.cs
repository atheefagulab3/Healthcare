using System.ComponentModel.DataAnnotations;

namespace AppointmentPrj.DTO
{
    public class ConfirmAppointmentDTO
    {
        [Required]
        public int Appointment_ID { get; set; }

        [Required]
        public string Status { get; set; } = "waiting";
    }
}
