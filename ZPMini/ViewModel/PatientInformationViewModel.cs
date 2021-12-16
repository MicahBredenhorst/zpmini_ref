using System;
using System.ComponentModel.DataAnnotations;

namespace ZPMini.API.ViewModel
{
    public class PatientInformationViewModel
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public Guid PatientId { get; set; }

        public Guid FacilityId { get; set; }

    }
}
