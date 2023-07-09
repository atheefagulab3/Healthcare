using Library.Models;
using Library.Models.DTO;
using Microsoft.AspNetCore.Mvc;


namespace DoctorPrj.Repositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int doctorId);
        Task<Doctor> GetDoctorByUsernameAsync(string username);
        public Task<int> AddDoctorAsync([FromForm] DoctorwithPassword DoctorwithPassword);
        Task UpdateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(int doctorId);
        bool VerifyPassword(string password, string hashedPassword);

        public Task<Doctor_Password_DTO> ChangePassword(int id, string oldPassword, string newPassword);
    }
}
