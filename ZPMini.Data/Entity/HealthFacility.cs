using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPMini.Data.Entity
{
    public class HealthFacility : BaseEntity
    {
        public string FacilityName { get; set; }
        public string FacilityAddress { get; set; }
        public virtual ICollection<InformationOwnership> InformationOwnership { get; set; }
        public virtual ICollection<InformationOwnershipRequest> InformationOwnershipRequests { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }

    }
}
