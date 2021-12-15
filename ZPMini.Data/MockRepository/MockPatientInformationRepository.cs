using System;
using System.Collections.Generic;
using System.Linq;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;

namespace ZPMini.Data.MockRepository
{
    public class MockPatientInformationRepository : IPatientInformationRepository
    {
        public readonly List<PatientInformation> mockPatientInformation = new();

        public MockPatientInformationRepository()
        {
            mockPatientInformation.Add(new PatientInformation
            {
                Id = Guid.Parse("01125017-7C17-4FEB-80F2-5A27433D6AAC"),
                Title = "Information about medication use",
                Description = "A detailed description about that medical information"
            });

            mockPatientInformation.Add(new PatientInformation
            {
                Id = Guid.Parse("5DEB6DA0-EFA5-47FD-9DD0-8C61EC3637FB"),
                Title = "Information about allegries",
                Description = "A detailed description about that medical information"
            });

            mockPatientInformation.Add(new PatientInformation
            {
                Id = Guid.Parse("522490FF-D914-4000-8422-418A06008E48"),
                Title = "Letter of Referral",
                Description = "A detailed description about that medical information"
            });

        }

        public void Add(PatientInformation entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PatientInformation entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public PatientInformation Get(Guid id)
        {
            return mockPatientInformation.Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<PatientInformation> GetAll()
        {
            return mockPatientInformation;
        }

        public IEnumerable<Patient> GetAllByPatientId(Guid patientId)
        {
            throw new NotImplementedException();
        }

        public void Update(PatientInformation entity)
        {
            throw new NotImplementedException();
        }
    }
}
