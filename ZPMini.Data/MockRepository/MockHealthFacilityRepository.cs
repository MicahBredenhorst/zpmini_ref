using System;
using System.Collections.Generic;
using System.Linq;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;

namespace ZPMini.Data.MockRepository
{
    public class MockHealthFacilityRepository : IHealthFacilityRepository
    {
        private readonly List<HealthFacility> mockHealthFacilities = new();

        public MockHealthFacilityRepository()
        {
            mockHealthFacilities.Add(new HealthFacility
            {
                Id = Guid.Parse("E8A360F5-14AE-46F3-88A4-51CB4AFAD12D"),
                FacilityName = "Hospital A",
            });

            mockHealthFacilities.Add(new HealthFacility
            {
                Id = Guid.Parse("C718D54D-A4BA-45C0-BA07-88165E27E499"),
                FacilityName = "Nursery Home B",

            });

            mockHealthFacilities.Add(new HealthFacility
            {
                Id = Guid.Parse("6ED52540-969F-4185-B680-BEC2EB911B10"),
                FacilityName = "Hospital B",
            });
        }

        public void Add(HealthFacility entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(HealthFacility entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Guid facilityId)
        {
            throw new NotImplementedException();
        }

        public HealthFacility Get(Guid id)
        {
            return mockHealthFacilities.Where(hf => hf.Id == id).FirstOrDefault();
        }

        public IEnumerable<HealthFacility> GetAll()
        {
            return mockHealthFacilities;
        }

        public IEnumerable<HealthFacility> GetAllWithProperties(Guid facilityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HealthFacility> GetAllWithProperties()
        {
            throw new NotImplementedException();
        }

        public HealthFacility GetWithProperties(Guid facilityId)
        {
            throw new NotImplementedException();
        }

        public void Update(HealthFacility entity)
        {
            throw new NotImplementedException();
        }
    }
}
