using System;
using System.ComponentModel.DataAnnotations;

namespace ZPMini.API.DataAnnotation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
    public class GuidNotEmptyAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field must not be empty";
        public GuidNotEmptyAttribute() : base(DefaultErrorMessage) { }
        public override bool IsValid(object value)
        {
            if((Guid)value != Guid.Empty)
            {
                return true;
            }
            return false;
        }
    }
}
