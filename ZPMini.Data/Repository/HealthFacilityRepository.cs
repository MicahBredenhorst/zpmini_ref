using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public HealthFacility GetWithProperties(Guid facilityId)
        {
            IEnumerable<Guid> informationOwnerships = _context.InformationOwnerships
                .Where(i => i.OwnerId == facilityId).Select(i => i.Id);

            return _context.HealthFacilities
                .Where(h => h.Id == facilityId)
                .Include(h => h.Patients).ThenInclude(p => p.PatientInformation).Where(i => informationOwnerships.Contains(i.Id) == true)
                .Include(h => h.InformationOwnership).FirstOrDefault();
        }

        public IEnumerable<HealthFacility> GetAllWithProperties()
        {
            return _context.HealthFacilities
                .Include(h => h.Patients)
                .Include(h => h.InformationOwnership);
        }
    }
}
