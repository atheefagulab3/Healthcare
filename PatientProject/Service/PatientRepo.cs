using Library.Models;
using Library.Models.Helpers;
using PatientProject.Interface;
using Microsoft.EntityFrameworkCore;
using PatientProject.Models;
using PatientProject.DTO;
using Microsoft.AspNetCore.Mvc;

namespace PatientProject.Service
{
    public class PatientRepo : IPatient
    {
            private readonly PatientContext context;
            public PatientRepo(PatientContext _context)
            {
                context = _context;
            }
            public async Task<Patient> DeleteById(int id)
            {
                var patient = await context.Patients.FindAsync(id);

                if (patient != null)
                {
                    context.Patients.Remove(patient);
                    await context.SaveChangesAsync();
                }

                return patient;
            }

        public async Task<ICollection<Patient>> GetAll()
        {
            var patients = await context.Patients.ToListAsync();
            if (patients != null)
            {
                return patients;
            }
            return null;
        }


        public async Task<Patient> GetById(int id)
            {
                var patients = await context.Patients.FindAsync(id);
                return patients;
            }

            public async Task<Patient> Post( Patient_Password_DTO patient_Password)
            {
                string hashedPassword = PasswordHasher.HashPassword(patient_Password.Password);
            patient_Password.patient.Patient_HashedPassword = hashedPassword;
                context.Patients.Add(patient_Password.patient);
                await context.SaveChangesAsync();
                return patient_Password.patient;
            }

            public async Task<Patient> Put(Patient patient, int id)
            {
                var existingPatient = await context.Patients.FindAsync(id);

                if (existingPatient != null)
                {

                    existingPatient.Patient_Name = patient.Patient_Name;
                    existingPatient.Age = patient.Age;
                    existingPatient.Gender = patient.Gender;
                    existingPatient.BloodGroup = patient.BloodGroup;
                    existingPatient.Patient_Address = patient.Patient_Address;
                    existingPatient.Patient_Phone = patient.Patient_Phone;
                    existingPatient.Patient_Email = patient.Patient_Email;
                    existingPatient.Patient_UserName = patient.Patient_UserName;
                    existingPatient.Patient_HashedPassword = patient.Patient_HashedPassword;


                    await context.SaveChangesAsync();
                    return existingPatient;
                }
                else
                {
                    throw new Exception("Patient not found");
                }
            }

            public bool VerifyPassword(string password, string hashedPassword)
            {
                return PasswordHasher.VerifyPassword(password, hashedPassword);
            }
        }
}
