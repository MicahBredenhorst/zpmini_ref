using Microsoft.Extensions.Logging;
using System;
using ZPMini.Data.Entity;


namespace ZPMini.Logic
{
    public class TransferLogic
    {
        private readonly ILogger<TransferLogic> _logger;
        private readonly PatientLogic _patientLogic;
        private readonly InformationOwnershipLogic _informationOwnershipLogic;
        private readonly FacilityLogic _facilityLogic;

        public TransferLogic(PatientLogic patientLogic, 
            InformationOwnershipLogic informationOwnershipLogic, 
            FacilityLogic facilityLogic, ILogger<TransferLogic> logger)
        {
            _patientLogic = patientLogic;
            _informationOwnershipLogic = informationOwnershipLogic;
            _facilityLogic = facilityLogic; 
            _logger = logger;
        }

        public bool TransferPatient(Guid patientId, Guid receivingFacilityId)
        { 
            Patient patient = _patientLogic.GetPatientById(patientId);
            HealthFacility healthFacility = _facilityLogic.GetHealthFacility(receivingFacilityId);
            if(patient != null && healthFacility != null)
            {
                _logger.LogInformation($"[TransferPatient] A transfer request for patient: {patient.LastName} to facility: {healthFacility.FacilityName} has been made");
                healthFacility.Patients.Add(patient);
                return true;
            }
            return false;
        }

        public void TransferInformation(Guid receivingFacility, Guid informationId)
        {
            _logger.LogInformation($"[TransferInformation] The information: {informationId} will be transfered");
            _informationOwnershipLogic.AddOwnership(receivingFacility, informationId);
        }

        public void RequestInformationTransfer(Guid requestingFacility, Guid owningFacility, Guid informationId)
        {
            _logger.LogInformation($"[RequestInformationTransfer] Information has been requested from facility: {owningFacility}");
            if(!_informationOwnershipLogic.RequestOwnership(requestingFacility, owningFacility, informationId)){
                _logger.LogInformation($"[RequestInformationTransfer] Information does not belong to {owningFacility}");
            }           
        }
    }
}
