using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPMini.Data.Entity
{
    public class InformationOwnership : BaseEntity
    {
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public Guid InformationId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual HealthFacility HealthFacility { get; set; }
    }
}
