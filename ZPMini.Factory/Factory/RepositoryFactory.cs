using ZPMini.Data;
using ZPMini.Data.Interface;
using ZPMini.Data.Repository;
using ZPMini.Factory.Interface;

namespace ZPMini.Factory.Factory
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly DefaultContext _context;
        public RepositoryFactory(DefaultContext context)
        {
            _context = context;
        }

        public IPatientRepository CreatePatientRepository()
        {
            return new PatientRepository(_context);
        }

        public IPatientInformationRepository CreatePatientInformationRepository()
        {
            return new PatientInformationRepository(_context);
        }

        public IOwnershipRepository CreateOwnershipRepository()
        {
            return new OwnershipRepository(_context);
        }

        public IOwnershipRequestRepository CreateOwnershipRequestRepository()
        {
            return new OwnershipRequestRepository(_context);
        }
        
        public IHealthFacilityRepository CreateHealthFacilityRepository()
        {
            return new HealthFacilityRepository(_context);
        }

    }
}
