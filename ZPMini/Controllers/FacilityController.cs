using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;
using ZPMini.Factory.Interface;

namespace ZPMini.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FacilityController : ControllerBase
    {
        private readonly IHealthFacilityRepository _healthFacilityRepository;
        private readonly ILogger<FacilityController> _logger;

        public FacilityController(IRepositoryFactory repositoryFactory, ILogger<FacilityController> logger)
        {
            _healthFacilityRepository = repositoryFactory.CreateHealthFacilityRepository();
            _logger = logger;
        }

        [HttpGet("/facility/{facilityId}")]
        public ActionResult<HealthFacility> Get(Guid facilityId)
        {
            if(facilityId != Guid.Empty)
            {
                _logger.LogInformation($"[Get] Information has been requested for facility: {facilityId}");
                return _healthFacilityRepository.Get(facilityId);
            }
            _logger.LogInformation($"[Get] Information has been requested for invalid facility: {facilityId}");
            return StatusCode(400);
        }
    }
}
