using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;
using ZPMini.Factory.Interface;

namespace ZPMini.Logic
{
    public class FacilityLogic
    {
        private readonly ILogger<FacilityLogic> _logger;
        private readonly IHealthFacilityRepository _healthFacilityRepository;
        private readonly IHealthFacilityPatientRepository _healthFacilityPatientRepository;
        public FacilityLogic(ILogger<FacilityLogic> logger, IRepositoryFactory repositoryFactory)
        {
            _logger = logger;
            _healthFacilityRepository = repositoryFactory.CreateHealthFacilityRepository();
            _healthFacilityPatientRepository = repositoryFactory.CreateHealthFacilityPatientRepository();
        }

        public void Add(HealthFacility healthFacility)
        {
            _healthFacilityRepository.Add(healthFacility);
        }

        public HealthFacility GetHealthFacility(Guid facilityId)
        {
            return _healthFacilityRepository.GetWithProperties(facilityId);
        }

        public void DeleteHealthFacility(Guid facilityId)
        {
            _healthFacilityRepository.Delete(facilityId);
        }

        public IEnumerable<HealthFacility> GetAll()
        {
            return _healthFacilityRepository.GetAllWithProperties();
        }

        public bool AssignPatient(Patient patient, Guid facilityId)
        {
            HealthFacility facility =  _healthFacilityRepository.GetWithProperties(facilityId);
            if(facility != null)
            {
                HealthFacilityPatient hfpatient = new()
                {
                    FacilityId = facilityId,
                    HealthFacility = facility,
                    Patient = patient,
                    PatientId = patient.Id
                };

                _healthFacilityPatientRepository.Add(hfpatient);
                return true;
            }
            return false;
        }
        
        public bool Exists(Guid facilityId)
        {
            return _healthFacilityRepository.Exists(facilityId);
        }
    }
}
