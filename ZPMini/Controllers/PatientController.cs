using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ZPMini.API.ViewModel;
using ZPMini.Data.Entity;
using ZPMini.Logic;
using System;
using ZPMini.API.DataAnnotation;

namespace ZPMini.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly PatientLogic _patientLogic;
        private readonly TransferLogic _transferLogic;
        private readonly FacilityLogic _facilityLogic;

        public PatientController(ILogger<PatientController> logger, PatientLogic patientLogic, TransferLogic transferLogic, FacilityLogic facilityLogic)
        {
            _logger = logger;
            _patientLogic = patientLogic;
            _transferLogic = transferLogic;
            _facilityLogic = facilityLogic;
        }

        [HttpPost("/patient/")]
        public StatusCodeResult Post(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                Patient patient = new()
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBrith = model.DateOfBrith
                };

                _patientLogic.AddPatient(patient);
                _logger.LogInformation($"[POST] A patient with id {patient.Id} has been added.");
                return StatusCode(200);
            }
            return StatusCode(400);
        }

        [HttpGet("/patient/{patientId}")]
        public ActionResult<Patient> Get([GuidNotEmpty]Guid patientId)
        {
            _logger.LogInformation($"[GET] A patient with id {patientId} has been requested");
            Patient patient = _patientLogic.GetPatientById(patientId);
            if (patient != null)
            {
                return patient;
            }
            _logger.LogInformation($"[GET] An unknown patient was requesteds");
            return StatusCode(404, "Patient not found");
        }

        [HttpGet("/patient/all")]
        public IEnumerable<Patient> All()
        {
            _logger.LogInformation("[All] All patients have been requested");
            return _patientLogic.GetAll();
        }

        [HttpPost("/patient/assign")]
        public StatusCodeResult AssignPatient(PatientAssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Patient patient = _patientLogic.GetPatientById(model.PatientId);
                if(patient != null)
                {
                    if (_facilityLogic.AssignPatient(patient, model.FacilityId))
                    {
                        _logger.LogInformation("[AssignPatient] A patient has been assigned to a facility");
                        return StatusCode(200);
                    }
                }   
            }
            _logger.LogInformation("[All] An invalid assignment to a facility has been made");
            return StatusCode(400);
        }

        [HttpPost("/patient/transfer/")]
        public StatusCodeResult TransferPatient(PatientTransferViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(_transferLogic.TransferPatient(model.PatientId, model.FacilityId))
                    return StatusCode(200);
            }
            _logger.LogInformation("[TRANSFER] An invalid patient transfer to another facility has been requested");
            return StatusCode(400);
        }
    }
}
