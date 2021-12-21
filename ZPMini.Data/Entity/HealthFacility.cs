using System.Collections.Generic;

namespace ZPMini.Data.Entity
{
    public class HealthFacility : BaseEntity
    {
        public string FacilityName { get; set; }
        public string FacilityAddress { get; set; }
        public virtual ICollection<InformationOwnership> InformationOwnership { get; set; }
        public virtual ICollection<InformationOwnershipRequest> InformationOwnershipRequests { get; set; }
        public virtual ICollection<HealthFacilityPatient> HealthFacilityPatients { get; set; }

    }
}
