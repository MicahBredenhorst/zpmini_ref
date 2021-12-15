using System;
using System.ComponentModel.DataAnnotations;

namespace ZPMini.API.ViewModel
{
    public class PatientInformationRequestViewModel
    {
        [Required]
        public Guid RequestedFacility { get; set; }
        [Required]
        public Guid OwningFacility { get; set; }
        [Required]
        public Guid InformationId { get; set; }
    }
}
