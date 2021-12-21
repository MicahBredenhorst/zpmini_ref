using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPMini.Data.Entity
{
    public class InformationOwnership
    {
        [Required]
        public Guid OwnerId { get; set; }
        public HealthFacility HealthFacility { get; set; }

        [Required]
        public Guid InformationId { get; set; }
        public PatientInformation PatientInformation { get; set; }

    }
}
