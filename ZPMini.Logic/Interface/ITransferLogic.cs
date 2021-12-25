using System;

namespace ZPMini.Logic.Interface
{
    public interface ITransferLogic
    {
        public bool TransferPatient(Guid patientId, Guid receivingFacilityId);
        public void TransferInformation(Guid receivingFacility, Guid informationId);
        public void RequestInformationTransfer(Guid requestingFacility, Guid owningFacility, Guid informationId);
    }
}
