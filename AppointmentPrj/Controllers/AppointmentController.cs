using AppointmentPrj.DTO;
using AppointmentPrj.Interface;
using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentService appointmentService,IAppointmentRepository appointmentRepository)
        {
            _appointmentService = appointmentService;
            _appointmentRepository = appointmentRepository;
        }

        [HttpPost("initial")]
        public async Task<InitialAppointmentDTO> CreateInitialAppointment(InitialAppointmentDTO initialAppointmentDTO)
        {
            var appointment = await _appointmentService.CreateInitialAppointment(initialAppointmentDTO);
            return appointment;
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentDTO updateAppointmentDTO)
        {
            await _appointmentService.UpdateAppointment(updateAppointmentDTO);
            return NoContent();
        }

        [HttpPut("confirm")]
        public async Task<IActionResult> ConfirmAppointment(ConfirmAppointmentDTO confirmAppointmentDTO)
        {
            await _appointmentService.ConfirmAppointment(confirmAppointmentDTO);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointment(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointments();
            return Ok(appointments);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAppointment(id);
            return NoContent();
        }
        [HttpGet("FilterbyDoctor/{id}")]
        public async Task<List<Appoinments>> Filter(int id)
        {
            var appointments = await _appointmentRepository.FilterByDoctor(id);
            return appointments;
        }
    }
}
