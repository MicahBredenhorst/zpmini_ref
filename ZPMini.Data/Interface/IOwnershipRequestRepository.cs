using System;
using System.Collections.Generic;
using ZPMini.Data.Entity;

namespace ZPMini.Data.Interface
{
    public interface IOwnershipRequestRepository : IRepository<InformationOwnershipRequest>
    {
        public IEnumerable<InformationOwnershipRequest> GetAllByFacility(Guid facilityId);
    }
}
