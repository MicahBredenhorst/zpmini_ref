using System;
using System.ComponentModel.DataAnnotations;

namespace ZPMini.API.ViewModel
{
    public class PatientViewModel
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBrith { get; set; }
    }
}
