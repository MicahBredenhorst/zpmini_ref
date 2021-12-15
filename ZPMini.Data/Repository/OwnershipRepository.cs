using System;
using System.Linq;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;

namespace ZPMini.Data.Repository
{
    public class OwnershipRepository : BaseRepository<InformationOwnership>, IOwnershipRepository
    {
        private readonly DefaultContext _context;

        public OwnershipRepository(DefaultContext context) : base (context)
        {
            _context = context;
        }

        public InformationOwnership GetInformationOwnershipOfFacility(Guid informationId, Guid facilityId)
        {
            return _context.InformationOwnerships.Where(i => i.InformationId == informationId && i.OwnerId == facilityId).FirstOrDefault();
        }
    }
}
