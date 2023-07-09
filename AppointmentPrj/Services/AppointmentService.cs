using AppointmentPrj.DTO;
using AppointmentPrj.Interface;
using AppointmentPrj.Models;
using Library.Models;

namespace AppointmentPrj.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly AppointmentContext _context;

        public AppointmentService(IAppointmentRepository appointmentRepository, AppointmentContext context)
        {
            _appointmentRepository = appointmentRepository;
            _context = context;
        }

        public async Task<InitialAppointmentDTO> CreateInitialAppointment(InitialAppointmentDTO initialAppointmentDTO)
        {
            var appointment = new Appoinments
            {
                Patient_ID = initialAppointmentDTO.Patient_ID,
                Doctor_ID = initialAppointmentDTO.Doctor_ID,
                Reason_of_visit = initialAppointmentDTO.Reason_of_visit
            };

            _context.Appoinments.Add(appointment);
            await _context.SaveChangesAsync();

            return initialAppointmentDTO;
        }

        public async Task UpdateAppointment(UpdateAppointmentDTO updateAppointmentDTO)
        {
            var appointment = await _appointmentRepository.GetAppointment(updateAppointmentDTO.Appointment_ID);

            if (appointment == null)
            {
                return;
            }

            appointment.Patient_Status = updateAppointmentDTO.Patient_Status;
            appointment.Diagnosis = updateAppointmentDTO.Diagnosis;
            appointment.Treatment = updateAppointmentDTO.Treatment;

            await _appointmentRepository.UpdateAppointment(appointment);
        }

        public async Task ConfirmAppointment(ConfirmAppointmentDTO confirmAppointmentDTO)
        {
            var appointment = await _appointmentRepository.GetAppointment(confirmAppointmentDTO.Appointment_ID);

            if (appointment == null)
            {
                return;
            }

            appointment.Status = confirmAppointmentDTO.Status;

            await _appointmentRepository.UpdateAppointment(appointment);
        }

        public async Task<Appoinments> GetAppointment(int appointmentId)
        {
            return await _appointmentRepository.GetAppointment(appointmentId);
        }

        public async Task<List<Appoinments>> GetAllAppointments()
        {
            return await _appointmentRepository.GetAllAppointments();
        }

        public async Task DeleteAppointment(int appointmentId)
        {
            await _appointmentRepository.DeleteAppointment(appointmentId);
        }
        
    }
}
