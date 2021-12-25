using System;
using System.Collections.Generic;
using ZPMini.Data.Entity;

namespace ZPMini.Logic.Interface
{
    public interface IPatientInformationLogic
    {
        public IEnumerable<PatientInformation> GetAllByPatient(Guid patientId);
        public PatientInformation GetById(Guid id);
        public void Add(PatientInformation patientInformation);
        public bool Exists(Guid patientInformationId);
    }
}
