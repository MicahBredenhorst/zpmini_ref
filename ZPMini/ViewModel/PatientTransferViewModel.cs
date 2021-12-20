using System;
using System.ComponentModel.DataAnnotations;
using ZPMini.API.DataAnnotation;

namespace ZPMini.API.ViewModel
{
    public class PatientTransferViewModel
    {
        [Required]
        [GuidNotEmpty]
        public Guid PatientId { get; set; }
        [Required]
        [GuidNotEmpty]
        public Guid FacilityId { get; set; }
    }
}
