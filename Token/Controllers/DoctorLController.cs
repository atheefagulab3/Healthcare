using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorLController : ControllerBase
    {
        private readonly TokenContext _context;

        public DoctorLController(TokenContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctor()
        {
            try
            {
                var Doctors = await _context.Doctor.ToListAsync();
                var adminDtos = Doctors.Select(a => new Doctor
                {
                    Doctor_ID = a.Doctor_ID,
                    Username = a.Username,
                    Password = HashPassword(a.Password)
                }).ToList();

                return adminDtos;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred while retrieving admins.");
            }
        }
        private string HashPassword(string Password)
        {

            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            if (_context.Doctor == null)
            {
                return NotFound();
            }
            var Admin = await _context.Doctor.FindAsync(id);

            if (Admin == null)
            {
                return NotFound();
            }

            return Admin;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, Doctor Doctor)
        {
            if (id != Doctor.Doctor_ID)
            {
                return BadRequest();
            }

            _context.Entry(Doctor).State = EntityState.Modified;


            await _context.SaveChangesAsync();


            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor Doctor)
        {
            if (_context.Admin == null)
            {
                return Problem("Entity set 'HotelContext.Admin'  is null.");
            }
            _context.Doctor.Add(Doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = Doctor.Doctor_ID }, Doctor);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            if (_context.Doctor == null)
            {
                return NotFound();
            }
            var Admin = await _context.Admin.FindAsync(id);
            if (Admin == null)
            {
                return NotFound();
            }

            _context.Admin.Remove(Admin);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
