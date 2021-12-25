using System.ComponentModel.DataAnnotations;
using ZPMini.API.DataAnnotation;

namespace ZPMini.API.ViewModel
{
    public class FacilityViewModel
    {
        [Required]
        [StringLengthRange(1, 100)]
        public string FacilityName { get; set; }
        [Required]
        [StringLengthRange(1, 100)]
        public string FacilityAddress { get; set; }
    }
}
