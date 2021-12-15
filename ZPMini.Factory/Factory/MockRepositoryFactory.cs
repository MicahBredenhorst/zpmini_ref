using ZPMini.Data.Interface;
using ZPMini.Data.MockRepository;
using ZPMini.Factory.Interface;

namespace ZPMini.Factory.Factory
{
    public class MockRepositoryFactory : IRepositoryFactory
    {
        public IPatientRepository CreatePatientRepository()
        {
            return new MockPatientRepository();
        }

        public IPatientInformationRepository CreatePatientInformationRepository()
        {
            return new MockPatientInformationRepository();
        }

        public IOwnershipRepository CreateOwnershipRepository()
        {
            return new MockOwnershipRepository();
        }

        public IOwnershipRequestRepository CreateOwnershipRequestRepository()
        {
            return new MockOwnershipRequestRepository();
        }

        public IHealthFacilityRepository CreateHealthFacilityRepository()
        {
            return new MockHealthFacilityRepository();
        }
    }
}
