using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class TokenContext : DbContext
    {

        public DbSet<Patient> Patient { get; set; }

        public DbSet<Doctor> Doctor { get; set; }

        public DbSet<Administration> Admin { get; set; }


        public TokenContext(DbContextOptions<TokenContext> options) : base(options) { }
    }
}

