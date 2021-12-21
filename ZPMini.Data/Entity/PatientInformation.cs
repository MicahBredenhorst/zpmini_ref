using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPMini.Data.Entity
{
    public class PatientInformation : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public Guid PatientId { get; set; }
        public virtual ICollection<InformationOwnership> InformationOwnerships { get; set; }
    }
}
