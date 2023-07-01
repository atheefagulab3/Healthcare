using AppointmentPrj.Interface;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentPrj.Services
{

    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentContext _context;

        public AppointmentRepository(AppointmentContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAppointment(Appoinments appointment)
        {
            _context.Appoinments.Add(appointment);
            await _context.SaveChangesAsync();

            return appointment.Appoinment_ID;
        }

        public async Task UpdateAppointment(Appoinments appointment)
        {
            _context.Appoinments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<Appoinments> GetAppointment(int appointmentId)
        {
            return await _context.Appoinments.FindAsync(appointmentId);
        }

        public async Task<List<Appoinments>> GetAllAppointments()
        {
            return await _context.Appoinments.ToListAsync();
        }

        public async Task DeleteAppointment(int appointmentId)
        {
            var appointment = await _context.Appoinments.FindAsync(appointmentId);

            if (appointment != null)
            {
                _context.Appoinments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }
    }
}

