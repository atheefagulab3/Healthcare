using DoctorPrj.Repositories;
using Library.Models.DTO;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DoctorPrj.Services
{
    public class DoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<DoctorPatientDTO>> GetAllDoctorsWithPatientsAsync()
        {
            var doctors = await _doctorRepository.GetAllDoctorsAsync();
            var doctorPatientDTOs = doctors.Select(d => new DoctorPatientDTO
            {
                ImageName = d.ImageName,
                DoctorName = d.DoctorName,
                DoctorMobile = d.DoctorMobile,
                Specialization = d.Specialization,
                Doctor_Experience = d.Doctor_Experience,
                Constulting_Day = d.Constulting_Day,
                Constulting_Time = d.Constulting_Time,
                Review = d.Review
            });

            return doctorPatientDTOs;
        }
        public async Task<DoctorActive_DTO> Activation(int id, DoctorActive_DTO doctorActivationDTO)
        {
            Doctor doctor = await _doctorRepository.GetDoctorByIdAsync(id);
            doctor.Status = doctorActivationDTO.status;
            await _doctorRepository.UpdateDoctorAsync(doctor);
            return doctorActivationDTO;
        }
        
    }
}
