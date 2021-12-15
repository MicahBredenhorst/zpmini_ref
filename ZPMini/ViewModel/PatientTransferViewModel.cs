using System;
using System.ComponentModel.DataAnnotations;

namespace ZPMini.API.ViewModel
{
    public class PatientTransferViewModel
    {
        [Required]
        public Guid PatientId { get; set; }
        [Required]
        public Guid FacilityId { get; set; }
    }
}
