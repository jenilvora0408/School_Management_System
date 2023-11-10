using Common.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Common.Validators
{
    public class StringValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string str)
            {
                if (str.Contains(" ") || str.Contains(""))
                {
                    throw new ModelValidationException("String cannot be empty or have white space");
                };
            }

            return true; // Non-string values are considered valid by default.
        }
    }
}
