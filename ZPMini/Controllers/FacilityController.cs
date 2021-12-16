using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ZPMini.API.ViewModel;
using ZPMini.Data.Entity;
using ZPMini.Logic;

namespace ZPMini.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FacilityController : ControllerBase
    {
        private readonly FacilityLogic _facilityLogic;
        private readonly ILogger<FacilityController> _logger;

        public FacilityController(FacilityLogic facilityLogic, ILogger<FacilityController> logger)
        {
            _facilityLogic = facilityLogic;
            _logger = logger;
        }

        [HttpGet("/facility/{facilityId}")]
        public ActionResult<HealthFacility> Get(Guid facilityId)
        {
            if(facilityId != Guid.Empty)
            {
                _logger.LogInformation($"[Get] Information has been requested for facility: {facilityId}");
                return _facilityLogic.GetHealthFacility(facilityId);
            }
            _logger.LogInformation($"[Get] Information has been requested for invalid facility: {facilityId}");
            return StatusCode(400);
        }

        [HttpGet("/facility/all/")]
        public ActionResult<IEnumerable<HealthFacility>> All()
        {
            _logger.LogInformation("[All] All facilities have been requested");
            return _facilityLogic.GetAll().ToList();
        }

        [HttpDelete("/facility/{facilityId}")]
        public StatusCodeResult Delete(Guid facilityId)
        {
            if(facilityId != Guid.Empty && _facilityLogic.GetHealthFacility(facilityId) != null)
            {
                _facilityLogic.DeleteHealthFacility(facilityId);
                _logger.LogInformation($"[Delete] A request to delete facility: {facilityId} has been made");
                return StatusCode(200);
            }
            _logger.LogInformation($"[Delete] Invalid delete request for facility has been made");
            return StatusCode(400);
        }

        [HttpPost("/facility/")]
        public StatusCodeResult Post(FacilityViewModel model)
        {
            if (ModelState.IsValid)
            {
                HealthFacility facility = new()
                {
                    Id = Guid.NewGuid(),
                    FacilityAddress = model.FacilityAddress,
                    FacilityName = model.FacilityName
                };
                _facilityLogic.Add(facility);
                _logger.LogInformation($"[POST] A new facility has been made for: {facility.FacilityName}");
                return StatusCode(200);
            }
            _logger.LogInformation($"[POST] An invalid facility was received");
            return StatusCode(400);
        }
    }
}
