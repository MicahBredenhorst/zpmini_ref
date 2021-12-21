using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;

namespace ZPMini.Data.Repository
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        private readonly DefaultContext _context;
        public PatientRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

        public Patient GetAllWithProperties(Guid patientId)
        {
            return _context.Patients.Where(p => p.Id == patientId).Include(p => p.PatientInformation).FirstOrDefault();
        }

        public bool Exists(Guid patientId)
        {
            return _context.Patients.Any(p => p.Id == patientId);
        }
    }
}
