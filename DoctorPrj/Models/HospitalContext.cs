﻿using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPrj.Models
{
    public class HospitalContext : DbContext
    {


        public DbSet<Doctor> Doctors { get; set; }


        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }
    }
}

