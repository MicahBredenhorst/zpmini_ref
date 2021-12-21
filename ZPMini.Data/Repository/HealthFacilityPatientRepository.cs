using ZPMini.Data.Entity;
using ZPMini.Data.Interface;

namespace ZPMini.Data.Repository
{
    public class HealthFacilityPatientRepository : BaseRepository<HealthFacilityPatient>, IHealthFacilityPatientRepository
    {
        private readonly DefaultContext _context;

        public HealthFacilityPatientRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

    }
}
