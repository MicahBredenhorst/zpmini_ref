using System;
using System.Collections.Generic;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;

namespace ZPMini.Data.MockRepository
{
    public class MockHealthFacilityPatientRepository : IHealthFacilityPatientRepository
    {
        public void Add(HealthFacilityPatient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(HealthFacilityPatient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public HealthFacilityPatient Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HealthFacilityPatient> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(HealthFacilityPatient entity)
        {
            throw new NotImplementedException();
        }
    }
}
