using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZPMini.Data.Entity
{
    public class Patient : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBrith { get; set; }
        public virtual ICollection<HealthFacilityPatient> HealthFacilityPatients  { get; set; }
        public virtual ICollection<PatientInformation> PatientInformation { get; set; }
    }
}
