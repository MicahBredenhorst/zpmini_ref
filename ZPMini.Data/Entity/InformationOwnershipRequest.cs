using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPMini.Data.Entity
{
    public class InformationOwnershipRequest
    {
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public Guid InformationId { get; set; }

        [Required]
        public Guid FacilityId { get; set; }

        [ForeignKey(nameof(FacilityId))]
        public virtual  HealthFacility HealthFacility { get; set; }

    }
}
