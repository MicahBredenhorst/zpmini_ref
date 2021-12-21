using System;
using System.ComponentModel.DataAnnotations;
using ZPMini.API.DataAnnotation;

namespace ZPMini.API.ViewModel
{
    public class InformationTransferViewModel
    {
        [GuidNotEmpty]
        [Required]
        public Guid ReceiverId { get; set; }  
        [GuidNotEmpty]
        [Required]
        public Guid InformationId { get; set; }
    }
}
