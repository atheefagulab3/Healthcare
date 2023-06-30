using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {

        public IConfiguration? _configuration;
        private readonly Library.Models.TokenContext _context;
        private const string PatientRole = "Patient";
        private const string DoctorRole = "Doctor";
        private const string AdminsRole = "Admin";

        public AuthorizeController(IConfiguration config, Library.Models.TokenContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost("Doctor")]
        public async Task<IActionResult> PostDoctor(Doctor _DData)
        {
            if (_DData != null && _DData.Username != null && _DData.Password != null)
            {
                var Doctor = await GetDoctor(_DData.Username, _DData.Password);

                if (Doctor != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                         new Claim("Doctor_ID", Doctor.Doctor_ID.ToString()),
                         new Claim("Username", Doctor.Username),
                        new Claim("Password",Doctor.Password),
                        new Claim(ClaimTypes.Role, DoctorRole)

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Doctor> GetDoctor(string Username, string Password)
        {
            return await _context.Doctor.FirstOrDefaultAsync(u => u.Username == Username && u.Password == Password);
        }



        [HttpPost("Patient")]
        public async Task<IActionResult> PostPatient(Patient _PData)
        {
            if (_PData != null && _PData.Patient_UserName != null && _PData.Patient_Password != null)
            {
                var Patient = await GetPatient(_PData.Patient_UserName, _PData.Patient_Password);

                if (Patient != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                         new Claim("Patient_ID", Patient.Patient_ID.ToString()),
                         new Claim("Patient_UserName", Patient.Patient_UserName),
                        new Claim("Password",Patient.Patient_Password),
                        new Claim(ClaimTypes.Role, PatientRole)

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Patient> GetPatient(string Patient_UserName, string Patient_Password)
        {
            return await _context.Patient.FirstOrDefaultAsync(u => u.Patient_UserName == Patient_UserName && u.Patient_Password == Patient_Password);
        }


        [HttpPost("Admins")]
        public async Task<IActionResult> Post(Administration AdminData)
        {
            if (AdminData != null && AdminData.AdminName != null && AdminData.AdminPassword != null)
            {
                var admin = await GetAdmin(AdminData.AdminName, AdminData.AdminPassword);

                if (admin != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("AdminName", admin.AdminName.ToString()),
                        new Claim("AdminPassword",admin.AdminPassword),
                        new Claim(ClaimTypes.Role, AdminsRole)

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Administration> GetAdmin(string adminname, string adminpassword)
        {
            return await _context.Admin.FirstOrDefaultAsync(u => u.AdminName == adminname && u.AdminPassword == adminpassword);
        }
    }
}



