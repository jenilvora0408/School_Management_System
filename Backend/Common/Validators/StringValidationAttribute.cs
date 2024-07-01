using System.ComponentModel.DataAnnotations;
using System.Net;
using Common.Constants;
using Common.Exceptions;

namespace Common.Validators;

public class StringValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is string str)
        {
            if (str.Contains(" "))
            {
                throw new ModelValidationException(MessageConstants.ErrorMessage.STRING_VALIDATION);
            };
        }

        return true; // Non-string values are considered valid by default.
    }
}
