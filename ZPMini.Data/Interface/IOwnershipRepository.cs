using System;
using ZPMini.Data.Entity;

namespace ZPMini.Data.Interface
{
    public interface IOwnershipRepository : IRepository<InformationOwnership>
    { 
        public InformationOwnership GetInformationOwnershipOfFacility(Guid informationId, Guid facilityId);
        public bool Exists(Guid informationOwnershipId);
    }
}
