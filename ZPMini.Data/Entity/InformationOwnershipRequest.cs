using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPMini.Data.Entity
{
    public class InformationOwnershipRequest : BaseEntity
    {
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public Guid InformationId { get; set; }

        [Required]
        public Guid ReceiverId { get; set; }

        [ForeignKey(nameof(ReceiverId))]
        public virtual  HealthFacility HealthFacility { get; set; }

    }
}
