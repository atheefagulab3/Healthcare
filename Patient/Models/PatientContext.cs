using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Models
{
    public class PatientContext :DbContext
    {
        
        public PatientContext(DbContextOptions<PatientContext> options) : base(options) { }

        public DbSet<Patients> Patient { get; set; }
    }
}
