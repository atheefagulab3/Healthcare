using AppointmentPrj.DTO;
using Library.Models;

namespace AppointmentPrj.Interface
{
    public interface IAppointmentService
    {
       public  Task<InitialAppointmentDTO> CreateInitialAppointment(InitialAppointmentDTO initialAppointmentDTO);
        Task UpdateAppointment(UpdateAppointmentDTO updateAppointmentDTO);
        Task ConfirmAppointment(ConfirmAppointmentDTO confirmAppointmentDTO);
        Task<Appoinments> GetAppointment(int appointmentId);
        Task<List<Appoinments>> GetAllAppointments();
        Task DeleteAppointment(int appointmentId);
    }
}
