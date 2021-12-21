using System;
using System.Collections.Generic;
using ZPMini.Data.Entity;

namespace ZPMini.Data.Interface
{
    public interface IHealthFacilityRepository : IRepository<HealthFacility>
    {
        public HealthFacility GetWithProperties(Guid facilityId);
        public IEnumerable<HealthFacility> GetAllWithProperties();
        public bool Exists(Guid facilityId);
    }
}
