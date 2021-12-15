
using ZPMini.Data.Interface;

namespace ZPMini.Factory.Interface
{
    public interface IRepositoryFactory
    {
        public IPatientRepository CreatePatientRepository();
        public IPatientInformationRepository CreatePatientInformationRepository();
        public IOwnershipRepository CreateOwnershipRepository();
        public IOwnershipRequestRepository CreateOwnershipRequestRepository();
        public IHealthFacilityRepository CreateHealthFacilityRepository();
    }
}
