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
    }
}
