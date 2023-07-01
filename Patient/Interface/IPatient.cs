using Library.Models;

namespace PatientPrj.Interface
{
    public interface IPatient
    {
        public Task<ICollection<Patients>> GetAll();
        public Task<Patients> GetById(int id);
        public Task<Patients> Post(Patients patient, string password);
        public Task<Patients> Put(Patients patient, int id);
        public Task<Patients> DeleteById(int id);
        public bool VerifyPassword(string password, string hashedPassword);
    }
}
