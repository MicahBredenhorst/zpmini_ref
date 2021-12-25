using System;
using System.ComponentModel.DataAnnotations;

namespace ZPMini.API.DataAnnotation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
    public class StringLengthRangeAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} is not in range";
        private readonly int _min = 1;
        private readonly int _max = 1;

        public StringLengthRangeAttribute(int min, int max) : base(DefaultErrorMessage) 
        {
            _min = min;
            _max = max;
        }

        public override bool IsValid(object value)
        {
            string input = ((string)value).Trim();
            if (input.Length > _min && input.Length < _max)
                return true;
            return false;
        }
    }
}
