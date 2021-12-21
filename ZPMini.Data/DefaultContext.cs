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
        public DbSet<HealthFacilityPatient> HealthFacilityPatients { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HealthFacilityPatient>(entity => 
            {
                entity.HasKey(hp => new { hp.PatientId, hp.FacilityId });
                entity.HasOne(hp => hp.HealthFacility).WithMany(hf => hf.HealthFacilityPatients).HasForeignKey(hp => hp.FacilityId);
                entity.HasOne(hp => hp.Patient).WithMany(p => p.HealthFacilityPatients).HasForeignKey(hp => hp.PatientId);
            });

            modelBuilder.Entity<InformationOwnership>(entity =>
            {
                entity.HasKey(io => new { io.OwnerId, io.InformationId });
                entity.HasOne(io => io.HealthFacility).WithMany(hf => hf.InformationOwnership).HasForeignKey(io => io.OwnerId);
                entity.HasOne(io => io.PatientInformation).WithMany(pi => pi.InformationOwnerships).HasForeignKey(io => io.InformationId);
            });

            modelBuilder.Entity<InformationOwnershipRequest>(entity =>
            {
                entity.HasOne(d => d.HealthFacility).WithMany(p => p.InformationOwnershipRequests).HasForeignKey(p => p.OwnerId);
            });

        }
    }
}
