﻿using Doctors.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Doctorapp.Repositories
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

        public async Task<int> AddDoctorAsync([FromForm] Doctor doctor, string password)
        {
            string path = Path.Combine(@"C:\Users\pc\Desktop\img", doctor.ImageName);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                doctor.File.CopyTo(stream);
            }
            string hashedPassword = PasswordHasher.HashPassword(password);
            doctor.HashedPassword = hashedPassword;
            doctor.Status = "pending";
            doctor.LastLogin = default;

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor.DoctorID;
        }

       /* [HttpPost]
        [Route("UploadFile")]
        public Image UploadFile([FromForm] Image img, int hotelId)
        {
            Image image = new Image();
            try
            {
                string path = Path.Combine(@"C:\Users\jeswa\OneDrive\Desktop\Kanini\React\api\public\images", img.ImageName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    img.file.CopyTo(stream);
                }
                image.HotelId = hotelId;
                image.ImageName = img.ImageName;

                _context.Images.Add(image);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }*/

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
    }
}
