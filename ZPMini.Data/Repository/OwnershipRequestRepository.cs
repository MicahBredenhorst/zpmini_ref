using System;
using System.Collections.Generic;
using System.Linq;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;

namespace ZPMini.Data.Repository
{
    public class OwnershipRequestRepository : BaseRepository<InformationOwnershipRequest>, IOwnershipRequestRepository
    {
        private readonly DefaultContext _context;

        public OwnershipRequestRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<InformationOwnershipRequest> GetAllByFacility(Guid facilityId)
        {
            return _context.InformationOwnershipRequests.Where(io => io.OwnerId == facilityId);
        }
    }
}
