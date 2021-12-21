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
            List<Guid> infoOwnerships = _context.InformationOwnerships.Where(i => i.OwnerId == facilityId).Select(i => i.InformationId).ToList();
            return _context.HealthFacilities.Where(hf => hf.Id == facilityId).Include(hf => hf.HealthFacilityPatients).ThenInclude(hfp => hfp.Patient).Include(hf => hf.InformationOwnership).ThenInclude(io => io.PatientInformation).FirstOrDefault();
        }

        public IEnumerable<HealthFacility> GetAllWithProperties()
        {
            return _context.HealthFacilities.Include(h => h.HealthFacilityPatients).Include(h => h.InformationOwnership);
        }

        public bool Exists(Guid facilityId)
        {
            return _context.HealthFacilities.Any(h => h.Id == facilityId);
        }
    }
}
