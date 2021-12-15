using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;

namespace ZPMini.Data.MockRepository
{
    public class MockPatientRepository : IPatientRepository
    {
        private readonly List<Patient> mockPatientData = new();

        public MockPatientRepository()
        {
            mockPatientData.Add(new Patient
            {
                Id = Guid.Parse("E11C9F0F-6335-433B-BA55-804F2C2890B2"),
                FirstName = "Isaura",
                LastName = "de Borst",
                DateOfBrith = DateTime.Parse("21-09-1947"),
            });

            mockPatientData.Add(new Patient
            {
                Id = Guid.Parse("6B4AAD53-99E7-4511-B797-B40C74A872B3"),
                FirstName = "Gwenny ",
                LastName = "Kwabbe",
                DateOfBrith = DateTime.Parse("11-04-1978"),
            });

            mockPatientData.Add(new Patient
            {
                Id = Guid.Parse("227A2AD4-A90A-48B2-8913-41E5A57A87BC"),
                FirstName = "Brecht",
                LastName = "Knigge",
                DateOfBrith = DateTime.Parse("06-04-2000"),
            });

            mockPatientData.Add(new Patient
            {
                Id = Guid.Parse("84FE5974-ABDC-41C1-A0A9-A09C57AE44D3"),
                FirstName = "Margrietha",
                LastName = "Sommer",
                DateOfBrith = DateTime.Parse("06-06-1969"),
            });
        }

        public void Add(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Patient Get(Guid id)
        {
            return mockPatientData.Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Patient> GetAll()
        {
            return mockPatientData;
        }

        public void Update(Patient entity)
        {
            throw new NotImplementedException();
        }
    }
}
