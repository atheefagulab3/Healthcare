using DoctorPrj.Repositories;
using DoctorPrj.Services;
using Library.Models;
using Library.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DoctorPrj.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly DoctorService _doctorService;

        public DoctorController(IDoctorRepository doctorRepository, DoctorService doctorService)
        {
            _doctorRepository = doctorRepository;
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorRepository.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromForm] DoctorwithPassword DoctorwithPassword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int doctorId = await _doctorRepository.AddDoctorAsync(DoctorwithPassword);
            return CreatedAtAction(nameof(GetDoctor), new { id = doctorId }, DoctorwithPassword.doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, Doctor doctor)
        {
            if (id != doctor.DoctorID)
            {
                return BadRequest();
            }

            await _doctorRepository.UpdateDoctorAsync(doctor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorRepository.DeleteDoctorAsync(id);
            return NoContent();
        }

        [HttpGet("doctors-with-patients")]
        public async Task<IActionResult> GetAllDoctorsWithPatients()
        {
            IEnumerable<DoctorPatientDTO> doctorPatientDTOs = await _doctorService.GetAllDoctorsWithPatientsAsync();
            return Ok(doctorPatientDTOs);
        }
        [HttpPost("{id}/activation")]
        public async Task<IActionResult> ActivateDoctor(int id, [FromBody] DoctorActive_DTO doctorActivationDTO)
        {
            try
            {
                DoctorActive_DTO activatedDoctor = await _doctorService.Activation(id, doctorActivationDTO);
                return Ok(activatedDoctor);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during activation
                return StatusCode(500, $"An error occurred during doctor activation: {ex.Message}");
            }
        }
        [HttpPut("ChangePass/{id}")]
        public async Task<ActionResult<Doctor_Password_DTO>> ChangePassword(int id, ChangePasswordModel model)
        {
            var doctorDto = await _doctorRepository.ChangePassword(id, model.OldPassword, model.NewPassword);

            if (doctorDto == null)
            {
                // Doctor not found or old password is incorrect
                return BadRequest("Invalid old password.");
            }

            return Ok(doctorDto);
        }

    }
}
