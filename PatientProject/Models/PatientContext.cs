using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace PatientProject.Models
{
    public class PatientContext : DbContext
    {

        public PatientContext(DbContextOptions options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
    }
}
