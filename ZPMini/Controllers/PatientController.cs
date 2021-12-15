using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ZPMini.API.ViewModel;
using ZPMini.Data.Entity;
using ZPMini.Logic;
using System;

namespace ZPMini.API.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly PatientLogic _patientLogic;
        private readonly TransferLogic _transferLogic;

        public PatientController(ILogger<PatientController> logger, PatientLogic patientLogic, TransferLogic transferLogic)
        {
            _logger = logger;
            _patientLogic = patientLogic;
            _transferLogic = transferLogic;
        }

        [HttpPost("/")]
        public StatusCodeResult Post(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: replace with model mapper [M.N]
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

        [HttpGet("/")]
        public ActionResult<Patient> Get(Guid patientId)
        {
            if(patientId != Guid.Empty)
            {
                _logger.LogInformation($"[GET] A patient with id {patientId} has been requested");
                Patient patient = _patientLogic.GetPatientById(patientId);
                if (patient != null)
                    return patient;
            }
            return StatusCode(404);
        }

        [HttpGet("/all")]
        public IEnumerable<Patient> All()
        {
            _logger.LogInformation("[ALL] All patients have been requested");
            return _patientLogic.GetAll();
        }


        [HttpPost("/transfer/")]
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
