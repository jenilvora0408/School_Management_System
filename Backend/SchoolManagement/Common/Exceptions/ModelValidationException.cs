using Common.Constants;

namespace Common.Exceptions
{
    public class ModelValidationException : Exception
    {
        public object? Errors { get; set; }

        public ModelValidationException() : base(ValidationConstants.VALIDATION_ERROR)
        { }

        public ModelValidationException(params string[] errorList) : this()
        {
            Errors = errorList.ToList();
        }

        public ModelValidationException(object errors) : this() { Errors = errors; }
    }
}
