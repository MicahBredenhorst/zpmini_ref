using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ZPMini.API.DataAnnotation;
using ZPMini.API.ViewModel;
using ZPMini.Data.Entity;
using ZPMini.Logic.Interface;

namespace ZPMini.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PatientInformationController : ControllerBase
    {
        private readonly IInformationOwnershipLogic _informationOwnershipLogic;
        private readonly ILogger<PatientInformationController> _logger;
        private readonly IPatientInformationLogic _patientInformationLogic;
        private readonly IFacilityLogic _facilityLogic;
        private readonly IMapper _mapper;

        public PatientInformationController(ILogger<PatientInformationController> logger, 
            IInformationOwnershipLogic informationOwnershipLogic, 
            IFacilityLogic facilityLogic,
            IPatientInformationLogic patientInformationLogic,
            IMapper mapper)
        {
            _informationOwnershipLogic = informationOwnershipLogic;
            _patientInformationLogic = patientInformationLogic;
            _facilityLogic = facilityLogic;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("/patientinformation/{patientInformationId}")]
        public ActionResult<PatientInformation> Get([GuidNotEmpty]Guid patientInformationId)
        {
            PatientInformation information = _patientInformationLogic.GetById(patientInformationId);
            if (information != null)
            {
                _logger.LogInformation($"[Get] Information has been requested for patient: {patientInformationId}");
                return information;
            }
            _logger.LogInformation($"[Get] Information has been requested for invalid patient: {patientInformationId}");
            return StatusCode(400, "Information not found");
        }

        [HttpPost("/patientinformation/")]
        public StatusCodeResult Post(PatientInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                PatientInformation patientInformation = _mapper.Map<PatientInformation>(model);
                _patientInformationLogic.Add(patientInformation);

                if (model.FacilityId != Guid.Empty && _facilityLogic.Exists(model.FacilityId))
                {
                    _logger.LogInformation($"[Post] Ownership has been added for information piece: { patientInformation.Id} to facility: {model.FacilityId}");
                    _informationOwnershipLogic.AddOwnership(model.FacilityId, patientInformation.Id);
                }
                _logger.LogInformation($"[Post] New patient information has been added for patient: {patientInformation.Id}");
                return StatusCode(200);
            }
            _logger.LogInformation($"[Post] An invalid patient information form has been submited");
            return StatusCode(400);
        }

        [HttpGet("/patientinformation/all/{patientId}")]
        public ActionResult<IEnumerable<PatientInformation>> All([GuidNotEmpty] Guid patientId)
        {

            List<PatientInformation> patientInformation = _patientInformationLogic.GetAllByPatient(patientId).ToList();
            if(patientInformation != null)
            {
                _logger.LogInformation($"[All] All information has been requested for patient: {patientId}");
                return patientInformation;
            }
            _logger.LogInformation($"[All] All information has been requested for invalid patient: {patientId}");
            return StatusCode(400);
        }

        [HttpPost("/patientinformation/transfer/")]
        public ActionResult Transfer(InformationTransferViewModel model)
        {
            if (ModelState.IsValid)
            {
                var receivingFacility = _facilityLogic.GetHealthFacility(model.ReceiverId);
                if(receivingFacility != null)
                {
                    _logger.LogInformation($"[Transfer] An information transfer has been made by the owner for information {model.InformationId} to {model.ReceiverId}");
                    var information = _patientInformationLogic.GetById(model.InformationId);
                    if(receivingFacility.HealthFacilityPatients.Any(p => p.PatientId == information.PatientId))
                    {
                        _informationOwnershipLogic.AddOwnership(model.ReceiverId, model.InformationId);
                    }
                }
            }
            _logger.LogInformation($"[Transfer] An invalid information transfer has been made by the owner for information {model.InformationId} to {model.ReceiverId}");
            return StatusCode(400);
        }

        [HttpGet("/patientinformation/request/{requestId}")]
        public ActionResult<InformationOwnershipRequest> GetRequest([GuidNotEmpty] Guid requestId)
        {
            InformationOwnershipRequest request = _informationOwnershipLogic.GetOwnershipRequest(requestId);
            if(request != null)
            {
                _logger.LogInformation($"[GetRequest] Information ownership request requested for {request.ReceiverId}");
                return request;
            }
            _logger.LogInformation($"[GetRequest] An invalid information ownership request has been requested");
            return StatusCode(400);
        }

        [HttpPost("/patientinformation/request/")]
        public StatusCodeResult InformationRequest(PatientInformationRequestViewModel model)
        {
            if(_facilityLogic.Exists(model.RequestedFacility) && _facilityLogic.Exists(model.OwningFacility) && _patientInformationLogic.Exists(model.InformationId))
            {
                _logger.LogInformation($"[InformationRequest] Information has been requested by {model.RequestedFacility} to {model.OwningFacility} for information {model.InformationId}");
                if (_informationOwnershipLogic.RequestOwnership(model.RequestedFacility, model.OwningFacility, model.InformationId))
                    return StatusCode(200);
            }
            _logger.LogInformation($"[InformationRequest] The Information has been requested by {model.RequestedFacility} to {model.OwningFacility} for information {model.InformationId} was invalid");
            return StatusCode(400);
        }

        [HttpGet("/patientinformation/request/all")]
        public ActionResult<IEnumerable<InformationOwnershipRequest>> AllRequests([GuidNotEmpty] Guid facilityId)
        {
            return _informationOwnershipLogic.GetAllOwnershipRequests(facilityId).ToList();
        }

        [HttpPost("/patientinformation/accept/{requestId}")]
        public StatusCodeResult Accept([GuidNotEmpty] Guid requestId)
        {
            var request = _informationOwnershipLogic.GetOwnershipRequest(requestId);
            if (request != null)
            {
                _informationOwnershipLogic.AddOwnership(request.ReceiverId, request.InformationId);
                _informationOwnershipLogic.RemoveOwnershipRequest(requestId);
                _logger.LogInformation($"[Accept] An information request has been accepted by {request.OwnerId} for facility {request.ReceiverId} for information: {request.InformationId}");
                return StatusCode(200);
            }
            return StatusCode(400);
        }
    }
}
