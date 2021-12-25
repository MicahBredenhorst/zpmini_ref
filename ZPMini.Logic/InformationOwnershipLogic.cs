using System;
using System.Collections.Generic;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;
using ZPMini.Factory.Interface;
using ZPMini.Logic.Interface;

namespace ZPMini.Logic
{
    public class InformationOwnershipLogic : IInformationOwnershipLogic
    {
        private readonly IOwnershipRepository _ownershipRepository;
        private readonly IOwnershipRequestRepository _ownershipRequestRepository;
        public InformationOwnershipLogic(IRepositoryFactory repositoryFactory)
        {
            _ownershipRepository = repositoryFactory.CreateOwnershipRepository();
            _ownershipRequestRepository = repositoryFactory.CreateOwnershipRequestRepository();
        }

        public InformationOwnershipRequest GetOwnershipRequest(Guid requestId)
        {
            return _ownershipRequestRepository.Get(requestId);
        }

        public IEnumerable<InformationOwnershipRequest> GetAllOwnershipRequests(Guid facilityId)
        {
            return _ownershipRequestRepository.GetAllByFacility(facilityId);
        }

        public void RemoveOwnershipRequest(Guid requestId)
        {
            _ownershipRequestRepository.Delete(requestId);
        }

        public void AddOwnership(Guid facilityId, Guid informationId)
        {
            _ownershipRepository.Add(new InformationOwnership 
            {
                InformationId = informationId,
                OwnerId = facilityId,
            });
        }

        public InformationOwnership GetInformationOwnershipFromFacility(Guid informationId, Guid facilityId)
        {
            return _ownershipRepository.GetInformationOwnershipOfFacility(informationId, facilityId);
        }

        public bool RequestOwnership(Guid requestingFacility, Guid owningFacility, Guid informationId)
        {
            if(GetInformationOwnershipFromFacility(informationId, owningFacility) != null)
            {
                _ownershipRequestRepository.Add(new InformationOwnershipRequest
                {
                    Id = Guid.NewGuid(),
                    OwnerId = owningFacility,
                    ReceiverId = requestingFacility,
                    InformationId = informationId

                });
                return true;
            }
            return false;
        }

        public bool Exists(Guid informationOwnershipId)
        {
            return _ownershipRepository.Exists(informationOwnershipId);
        }
    }
}
