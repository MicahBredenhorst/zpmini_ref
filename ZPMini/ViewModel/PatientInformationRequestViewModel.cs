using System;
using System.ComponentModel.DataAnnotations;
using ZPMini.API.DataAnnotation;

namespace ZPMini.API.ViewModel
{
    public class PatientInformationRequestViewModel
    {
        [Required]
        [GuidNotEmpty]
        public Guid RequestedFacility { get; set; }
        [Required]
        [GuidNotEmpty]
        public Guid OwningFacility { get; set; }
        [Required]
        [GuidNotEmpty]
        public Guid InformationId { get; set; }
    }
}
