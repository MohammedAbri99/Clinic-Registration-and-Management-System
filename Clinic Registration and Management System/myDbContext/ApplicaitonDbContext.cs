using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_Registration_and_Management_System.Tabels;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Registration_and_Management_System.myDbContext
{
    internal class ApplicaitonDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ENGABUFIRAS-PC;Initial Catalog=ReservationSystem;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne<Patient>()
                .WithMany();
            modelBuilder.Entity<Patient>()
                .HasMany<Appointment>()
                .WithOne();

        }
        public DbSet<Patient>? patients { set; get; }
        public DbSet<Appointment>? appointments { get; set; }
        public DbSet<Specialization>? specializations { get; set; }

        public DbSet<Admin>? admins { get; set; }


    }
}
