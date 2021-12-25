using System;
using System.Collections.Generic;
using ZPMini.Data.Entity;

namespace ZPMini.Logic.Interface
{
    public interface IPatientLogic
    {
        public IEnumerable<Patient> GetAll();
        public Patient GetPatientById(Guid patientId);
        public void AddPatient(Patient patient);
        public bool Exists(Guid patientId);
    }
}
