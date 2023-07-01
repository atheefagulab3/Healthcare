using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Library.Models
{
    public class AppointmentContext :DbContext
    {

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patients> Patients { get; set; }

        public DbSet<Appoinments> Appoinments { get; set; }

        public DbSet<Administration> Administration { get; set; }


        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options) { }
    }
}
