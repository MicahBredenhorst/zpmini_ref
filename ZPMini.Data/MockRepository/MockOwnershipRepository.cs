using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;

namespace ZPMini.Data.MockRepository
{
    public class MockOwnershipRepository : IOwnershipRepository
    {
        public readonly List<InformationOwnership> mockOwnershipInformation = new();

        public void Add(InformationOwnership entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(InformationOwnership entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public InformationOwnership Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InformationOwnership> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(InformationOwnership entity)
        {
            throw new NotImplementedException();
        }

        public InformationOwnership GetInformationOwnershipOfFacility(Guid informationId, Guid facilityId)
        {
            throw new NotImplementedException();
        }
    }
}
