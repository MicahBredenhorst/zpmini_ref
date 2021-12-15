using System;
using System.Collections.Generic;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;

namespace ZPMini.Data.MockRepository
{
    public class MockOwnershipRequestRepository : IOwnershipRequestRepository
    {
        public void Add(InformationOwnershipRequest entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(InformationOwnershipRequest entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public InformationOwnershipRequest Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InformationOwnershipRequest> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InformationOwnershipRequest> GetAllByFacility(Guid facilityId)
        {
            throw new NotImplementedException();
        }

        public void Update(InformationOwnershipRequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
