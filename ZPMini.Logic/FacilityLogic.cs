using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using ZPMini.API;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;
using ZPMini.Factory.Interface;
using ZPMini.Logic.Interface;

namespace ZPMini.Logic
{
    public class FacilityLogic : IFacilityLogic
    {
        private readonly ILogger<IFacilityLogic> _logger;
        private readonly IHealthFacilityRepository _healthFacilityRepository;
        private readonly IHealthFacilityPatientRepository _healthFacilityPatientRepository;
        private readonly IMapper _mapper;
        public FacilityLogic(ILogger<IFacilityLogic> logger, 
            IRepositoryFactory repositoryFactory,
            IMapper mapper)
        {
            _logger = logger;
            _healthFacilityRepository = repositoryFactory.CreateHealthFacilityRepository();
            _healthFacilityPatientRepository = repositoryFactory.CreateHealthFacilityPatientRepository();
            _mapper = mapper;
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
                HealthFacilityPatient hfpatient = _mapper.MergeInto<HealthFacilityPatient>(patient, facility);
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
