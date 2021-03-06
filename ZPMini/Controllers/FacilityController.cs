using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ZPMini.API.DataAnnotation;
using ZPMini.API.ViewModel;
using ZPMini.Data.Entity;
using ZPMini.Logic;
using ZPMini.Logic.Interface;

namespace ZPMini.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityLogic _facilityLogic;
        private readonly ILogger<FacilityController> _logger;
        private readonly IMapper _mapper;

        public FacilityController(IFacilityLogic facilityLogic, 
            ILogger<FacilityController> logger,
            IMapper mapper)
        {
            _facilityLogic = facilityLogic;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("/facility/{facilityId}")]
        public ActionResult<HealthFacility> Get([GuidNotEmpty] Guid facilityId)
        {
            _logger.LogInformation($"[Get] Information has been requested for facility: {facilityId}");
            var facility = _facilityLogic.GetHealthFacility(facilityId);
            if (facility != null)
                return facility;
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
        public ActionResult Delete([GuidNotEmpty] Guid facilityId)
        {
            if(_facilityLogic.Exists(facilityId))
            {
                _facilityLogic.DeleteHealthFacility(facilityId);
                _logger.LogInformation($"[Delete] A request to delete facility: {facilityId} has been made");
                return StatusCode(200);
            }
            _logger.LogInformation($"[Delete] Invalid delete request for facility has been made");
            return StatusCode(400, "facility could not be deleted");
        }

        [HttpPost("/facility/")]
        public ActionResult Post(FacilityViewModel model)
        {
            if (ModelState.IsValid)
            {
                HealthFacility facility = _mapper.Map<HealthFacility>(model);
                _facilityLogic.Add(facility);
                _logger.LogInformation($"[POST] A new facility has been made for: {facility.FacilityName}");
                return StatusCode(200);
            }
            _logger.LogInformation($"[POST] An invalid facility was received");
            return StatusCode(400, "An invalid facility was posted");
        }
    }
}
