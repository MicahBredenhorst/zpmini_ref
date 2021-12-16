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
    public class PatientInformationController : ControllerBase
    {
        private readonly InformationOwnershipLogic _informationOwnershipLogic;
        private readonly ILogger<PatientInformationController> _logger;
        private readonly PatientInformationLogic _patientInformationLogic;

        public PatientInformationController(InformationOwnershipLogic informationOwnershipLogic, 
            ILogger<PatientInformationController> logger, 
            PatientInformationLogic patientInformationLogic)
        {
            _informationOwnershipLogic = informationOwnershipLogic;
            _logger = logger;
            _patientInformationLogic = patientInformationLogic;
        }

        [HttpGet("/patientinformation/{patientInformationId}")]
        public ActionResult<PatientInformation> Get(Guid patientInformationId)
        {
            if(patientInformationId != Guid.Empty)
            {
                PatientInformation information = _patientInformationLogic.GetById(patientInformationId);
                if (information != null)
                {
                    _logger.LogInformation($"[Get] Information has been requested for patient: {patientInformationId}");
                    return information;
                }
            }
            _logger.LogInformation($"[Get] Information has been requested for invalid patient: {patientInformationId}");
            return StatusCode(404);
        }

        [HttpPost("/patientinformation/")]
        public StatusCodeResult Post(PatientInformationViewModel model)
        {
            // FIXME: Json error on post for some reason
            if (ModelState.IsValid)
            {
                // TODO: Add modelmapper [MN]
                PatientInformation patientInformation = new()
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    Description = model.Description,
                    Title = model.Title,
                    PatientId = model.PatientId,
                };

                if(model.FacilityId != Guid.Empty)
                {
                    _logger.LogInformation($"[Post] Ownership has been added for information piece: { patientInformation.Id} to facility: {model.FacilityId}");
                    _informationOwnershipLogic.AddOwnership(model.FacilityId, patientInformation.Id);
                }

                _patientInformationLogic.Add(patientInformation);

                _logger.LogInformation($"[Post] New patient information has been added for patient: {patientInformation.Id}");
                return StatusCode(200);
            }
            _logger.LogInformation($"[Post] An invalid patient information form has been submited");
            return StatusCode(400);
        }

        [HttpGet("/patientinformation/all/{patientId}")]
        public ActionResult<IEnumerable<PatientInformation>> All(Guid patientId)
        {
            if(patientId != Guid.Empty)
            {
                List<PatientInformation> patientInformation = _patientInformationLogic.GetAllByPatient(patientId).ToList();
                if(patientInformation != null)
                {
                    _logger.LogInformation($"[All] All information has been requested for patient: {patientId}");
                    return patientInformation;
                }
            }
            _logger.LogInformation($"[All] All information has been requested for invalid patient: {patientId}");
            return StatusCode(400);
        }

        [HttpGet("/patientinformation/request/{requestId}")]
        public ActionResult<InformationOwnershipRequest> GetRequest(Guid requestId)
        {
            if(requestId != Guid.Empty)
            {
                InformationOwnershipRequest request = _informationOwnershipLogic.GetOwnershipRequest(requestId);
                if(request != null)
                {
                    _logger.LogInformation($"[GetRequest] Information ownership request requested for {request.ReceiverId}");
                    return request;
                }
            }
            _logger.LogInformation($"[GetRequest] An invalid information ownership request has been requested");
            return StatusCode(400);
        }

        [HttpPost("/patientinformation/request/")]
        public StatusCodeResult InformationRequest(PatientInformationRequestViewModel model)
        {
            if(model.OwningFacility != Guid.Empty && model.RequestedFacility != Guid.Empty && model.InformationId != Guid.Empty)
            {
                _logger.LogInformation($"[InformationRequest] Information has been requested by {model.RequestedFacility} to {model.OwningFacility} for information {model.InformationId}");
                if (_informationOwnershipLogic.RequestOwnership(model.RequestedFacility, model.OwningFacility, model.InformationId))
                    return StatusCode(200);
                _logger.LogInformation($"[InformationRequest] The Information has been requested by {model.RequestedFacility} to {model.OwningFacility} for information {model.InformationId} was invalid");
            }
            return StatusCode(400);
        }

        [HttpGet("/patientinformation/request/all")]
        public ActionResult<IEnumerable<InformationOwnershipRequest>> AllRequests(Guid facilityId)
        {
            if(facilityId != Guid.Empty)
            {
                return _informationOwnershipLogic.GetAllOwnershipRequests(facilityId).ToList();
            }
            return StatusCode(400);
        }

        [HttpPost("/patientinformation/accept/{requestId}")]
        public StatusCodeResult Accept(Guid requestId)
        {
            if(requestId != Guid.Empty)
            {
                var request = _informationOwnershipLogic.GetOwnershipRequest(requestId);
                if (request != null)
                {
                    _informationOwnershipLogic.AddOwnership(request.ReceiverId, request.InformationId);
                    _informationOwnershipLogic.RemoveOwnershipRequest(requestId);
                    _logger.LogInformation($"[Accept] An information request has been accepted by {request.OwnerId} for facility {request.ReceiverId} for information: {request.InformationId}");
                    return StatusCode(200);
                }
            }
            return StatusCode(400);
        }
    }
}
