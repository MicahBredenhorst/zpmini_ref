using System;
using System.Linq;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;

namespace ZPMini.Data.Repository
{
    public class HealthFacilityRepository : BaseRepository<HealthFacility>, IHealthFacilityRepository
    {
        private readonly DefaultContext _context;

        public HealthFacilityRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

    }
}
