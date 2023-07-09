using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentPrj.Interface
{
    public interface IAppointmentRepository
    {
        Task<int> CreateAppointment(Appoinments appointment);
        Task UpdateAppointment(Appoinments appointment);
        Task<Appoinments> GetAppointment(int appointmentId);
        Task<List<Appoinments>> GetAllAppointments();
        Task DeleteAppointment(int appointmentId);
        public Task<List<Appoinments>> FilterByDoctor(int id);
    }
}
