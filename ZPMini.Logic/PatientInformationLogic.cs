using System;
using System.Collections.Generic;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;
using ZPMini.Factory.Interface;

namespace ZPMini.Logic
{
    public class PatientInformationLogic
    {
        private readonly IPatientInformationRepository _patientInformationRepository;
        public PatientInformationLogic(IRepositoryFactory repositoryFactory)
        {
            _patientInformationRepository = repositoryFactory.CreatePatientInformationRepository();
        }

        public IEnumerable<PatientInformation> GetAllByPatient(Guid patientId)
        {
            _patientInformationRepository.GetAllByPatientId(patientId);
            return new List<PatientInformation>();
        }

        public PatientInformation GetById(Guid id)
        {
            return _patientInformationRepository.Get(id);
        }

        public void Add(PatientInformation patientInformation)
        {
            _patientInformationRepository.Add(patientInformation);
        }
    }
}
