using System;
using System.Collections.Generic;
using ZPMini.Data.Entity;

namespace ZPMini.Logic.Interface
{
    public interface IFacilityLogic
    {
        public void Add(HealthFacility healthFacility);
        public HealthFacility GetHealthFacility(Guid facilityId);
        public void DeleteHealthFacility(Guid facilityId);
        public IEnumerable<HealthFacility> GetAll();
        public bool AssignPatient(Patient patient, Guid facilityId);
        public bool Exists(Guid facilityId);
    }
}
