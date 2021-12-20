using System;
using System.ComponentModel.DataAnnotations;
using ZPMini.API.DataAnnotation;

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
        [GuidNotEmpty]
        public Guid PatientId { get; set; }

        public Guid FacilityId { get; set; }

    }
}
