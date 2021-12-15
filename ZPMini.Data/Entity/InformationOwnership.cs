using System;
using System.ComponentModel.DataAnnotations;

namespace ZPMini.Data.Entity
{
    public class InformationOwnership : BaseEntity
    {
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public Guid InformationId { get; set; }
    }
}
