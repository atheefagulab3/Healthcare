
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using PatientProject.DTO;

namespace PatientProject.Interface
{
    public interface IPatient
    {
        public Task<ICollection<Patient>> GetAll();
        public Task<Patient> GetById(int id);
        public Task<Patient> Post( Patient_Password_DTO patient_Password);
        public Task<Patient> Put(Patient patient, int id);
        public Task<Patient> DeleteById(int id);
        public bool VerifyPassword(string password, string hashedPassword);
    }
}
