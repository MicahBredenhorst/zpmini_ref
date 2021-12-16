using System.ComponentModel.DataAnnotations;

namespace ZPMini.API.ViewModel
{
    public class FacilityViewModel
    {
        [Required]
        public string FacilityName { get; set; }
        [Required]
        public string FacilityAddress { get; set; }
    }
}
