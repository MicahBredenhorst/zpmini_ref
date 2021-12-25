using System;
using System.Collections.Generic;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;
using ZPMini.Factory.Interface;
using ZPMini.Logic.Interface;

namespace ZPMini.Logic
{
    public class PatientLogic : IPatientLogic
    {
        private readonly IPatientRepository _patientRepository;

        public PatientLogic(IRepositoryFactory repositoryFactory)
        {
            _patientRepository = repositoryFactory.CreatePatientRepository();
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetPatientById(Guid patientId)
        {
            return _patientRepository.GetAllWithProperties(patientId);
        }

        public void AddPatient(Patient patient)
        {
            _patientRepository.Add(patient);
        }

        public bool Exists(Guid patientId)
        {
            return _patientRepository.Exists(patientId);
        }

    }
}
