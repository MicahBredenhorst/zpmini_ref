using System;
using System.Collections;
using System.Collections.Generic;
using ZPMini.Data.Entity;

namespace ZPMini.Data.Interface
{
    public interface IPatientInformationRepository : IRepository<PatientInformation>
    {
        public IEnumerable<Patient> GetAllByPatientId(Guid patientId); 
    }
}
