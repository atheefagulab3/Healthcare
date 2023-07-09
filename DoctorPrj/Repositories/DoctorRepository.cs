
using DoctorPrj.Models;
using Library.Models;
using Library.Models.DTO;
using Library.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DoctorPrj.Repositories
{
    internal class DoctorRepository : IDoctorRepository
        {
            private readonly HospitalContext _context;

            public DoctorRepository(HospitalContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
            {
                return await _context.Doctors.ToListAsync();
            }

            public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
            {
                return await _context.Doctors.FindAsync(doctorId);
            }

            public async Task<Doctor> GetDoctorByUsernameAsync(string username)
            {
                return await _context.Doctors.FirstOrDefaultAsync(d => d.Username == username);
            }

            public async Task<int> AddDoctorAsync([FromForm] DoctorwithPassword DoctorwithPassword)
            {
                string path = Path.Combine(@"E:\BigBang\healthcare\public\Img", DoctorwithPassword.doctor.ImageName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                DoctorwithPassword. doctor.File.CopyTo(stream);
                }
                string hashedPassword = PasswordHasher.HashPassword(DoctorwithPassword.password);
            DoctorwithPassword.doctor.HashedPassword = hashedPassword;
            DoctorwithPassword. doctor.Status = "pending";
            DoctorwithPassword. doctor.LastLogin = default;

                _context.Doctors.Add(DoctorwithPassword.doctor);
                await _context.SaveChangesAsync();
                return DoctorwithPassword.doctor.DoctorID;
            }

       

            public async Task UpdateDoctorAsync(Doctor doctor)
            {
                _context.Doctors.Update(doctor);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteDoctorAsync(int doctorId)
            {
                var doctor = await _context.Doctors.FindAsync(doctorId);
                if (doctor != null)
                {
                    _context.Doctors.Remove(doctor);
                    await _context.SaveChangesAsync();
                }
            }


            public bool VerifyPassword(string password, string hashedPassword)
            {
                return PasswordHasher.VerifyPassword(password, hashedPassword);
            }
        public async Task<Doctor_Password_DTO> ChangePassword(int id, string oldPassword, string newPassword)
        {
            Doctor doctor = await _context.Doctors.FindAsync(id);


            bool isOldPasswordCorrect = PasswordHasher.VerifyPassword(oldPassword, doctor.HashedPassword);
            if (!isOldPasswordCorrect)
            {
                return null;
            }
            string newHashedPassword = PasswordHasher.HashPassword(newPassword);
            doctor.HashedPassword = newHashedPassword;
            await _context.SaveChangesAsync();

            return new Doctor_Password_DTO
            {
                Id = doctor.DoctorID,
                Password = newPassword,
                HashedPassword = newHashedPassword
            };

        }
    }
    }

