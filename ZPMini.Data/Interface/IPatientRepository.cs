using System;
using ZPMini.Data.Entity;

namespace ZPMini.Data.Interface
{
    public interface IPatientRepository : IRepository<Patient>
    {
        public Patient GetAllWithProperties(Guid patientId);
        public bool Exists(Guid parientId);
    }
}
