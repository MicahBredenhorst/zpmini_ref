using System;
using System.Collections.Generic;
using System.Linq;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;

namespace ZPMini.Data.Repository
{
    public class PatientInformationRepository : BaseRepository<PatientInformation>, IPatientInformationRepository
    {
        private readonly DefaultContext _context;
        public PatientInformationRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetAllByPatientId(Guid patientId)
        {
            return _context.Patients.Where(p => p.Id == patientId);
        }

        public bool Exists(Guid patientInformaitonId)
        {
            return _context.PatientInformation.Any(p => p.Id == patientInformaitonId);
        }
    }
}
