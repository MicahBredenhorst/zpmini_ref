using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
