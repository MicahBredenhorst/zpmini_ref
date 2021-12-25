using System;
using System.Collections.Generic;
using ZPMini.Data.Entity;

namespace ZPMini.Logic.Interface
{
    public interface IInformationOwnershipLogic
    {
        public InformationOwnershipRequest GetOwnershipRequest(Guid requestId);
        public IEnumerable<InformationOwnershipRequest> GetAllOwnershipRequests(Guid facilityId);
        public void RemoveOwnershipRequest(Guid requestId);
        public void AddOwnership(Guid facilityId, Guid informationId);
        public InformationOwnership GetInformationOwnershipFromFacility(Guid informationId, Guid facilityId);
        public bool RequestOwnership(Guid requestingFacility, Guid owningFacility, Guid informationId);
    }
}
