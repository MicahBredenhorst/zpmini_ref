using System;

namespace ZPMini.Data.Entity
{
    public class BaseEntity
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
