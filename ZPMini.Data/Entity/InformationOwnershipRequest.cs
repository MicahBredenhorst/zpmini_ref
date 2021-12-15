using System;
using System.ComponentModel.DataAnnotations;

namespace ZPMini.Data.Entity
{
    public class InformationOwnershipRequest : InformationOwnership
    {
        [Required]
        public Guid ReceiverId { get; set; }
    }
}
