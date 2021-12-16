using Microsoft.EntityFrameworkCore;
using ZPMini.Data.Entity;

namespace ZPMini.Data
{
    public class DefaultContext : DbContext
    {
        public DefaultContext() : base()
        {

        }

        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<InformationOwnership> InformationOwnerships { get; set; }
        public DbSet<InformationOwnershipRequest> InformationOwnershipRequests { get; set; }
        public DbSet<PatientInformation> PatientInformation { get; set; }
        public DbSet<HealthFacility> HealthFacilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientInformation>(entity => 
            {
                entity.HasOne(d => d.Patient).WithMany(p => p.PatientInformation).HasForeignKey(p => p.PatientId);
            });

            modelBuilder.Entity<InformationOwnership>(entity =>
            {
                entity.HasOne(d => d.HealthFacility).WithMany(p => p.InformationOwnership).HasForeignKey(p => p.OwnerId);
            });

            modelBuilder.Entity<InformationOwnershipRequest>(entity =>
            {
                entity.HasOne(d => d.HealthFacility).WithMany(p => p.InformationOwnershipRequests).HasForeignKey(p => p.OwnerId);
            });

        }
    }
}
