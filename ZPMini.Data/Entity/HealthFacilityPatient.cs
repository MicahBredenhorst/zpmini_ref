using System;

namespace ZPMini.Data.Entity
{
    public class HealthFacilityPatient
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid FacilityId { get; set; }
        public HealthFacility HealthFacility { get; set; }
    }
}
