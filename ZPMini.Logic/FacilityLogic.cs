﻿using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;
using ZPMini.Factory.Interface;

namespace ZPMini.Logic
{
    public class FacilityLogic
    {
        private readonly ILogger<FacilityLogic> _logger;
        private readonly IHealthFacilityRepository _healthFacilityRepository;
        public FacilityLogic(ILogger<FacilityLogic> logger, IRepositoryFactory repositoryFactory)
        {
            _logger = logger;
            _healthFacilityRepository = repositoryFactory.CreateHealthFacilityRepository();
        }

        public HealthFacility GetHealthFacility(Guid facilityId)
        {
            return _healthFacilityRepository.Get(facilityId);
        }
    }
}