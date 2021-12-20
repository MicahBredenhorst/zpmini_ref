using System;
using System.ComponentModel.DataAnnotations;
using ZPMini.API.DataAnnotation;

namespace ZPMini.API.ViewModel
{
    public class PatientAssignmentViewModel
    {
        [Required]
        [GuidNotEmpty]
        public Guid PatientId { get; set; }

        [Required]
        [GuidNotEmpty]
        public Guid FacilityId { get; set; }
    }
}