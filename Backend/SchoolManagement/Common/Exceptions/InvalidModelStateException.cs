using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace Common.Exceptions
{
    public class InvalidModelStateException : Exception
    {
        #region Constructor

        public int StatusCode { get; set; }
        public List<string> Messages { get; set; }
        public Dictionary<string, object>? Metadata { get; set; }

        // Constructor that accepts an error message
        public InvalidModelStateException(string errorMessage) : base(errorMessage)
        {
            StatusCode = (int)HttpStatusCode.BadRequest;
            Messages = new List<string> { errorMessage };
        }

        // Constructor that accepts a ModelStateDictionary
        public InvalidModelStateException(ModelStateDictionary modelState) : base(ConcatenateErrorMessages(modelState))
        {
            StatusCode = (int)HttpStatusCode.BadRequest;
            Messages = GetErrorMessages(modelState);
        }

        #endregion

        #region Private_Methods

        private static string ConcatenateErrorMessages(ModelStateDictionary modelState)
        {
            List<string> messages = GetErrorMessages(modelState);
            return string.Join(Environment.NewLine, messages);
        }

        private static List<string> GetErrorMessages(ModelStateDictionary modelState)
        {
            List<string> messages = new List<string>();

            if (modelState != null && modelState.Count > 0)
            {
                foreach (var keyValuePair in modelState)
                {
                    foreach (var error in keyValuePair.Value.Errors)
                    {
                        messages.Add(error.ErrorMessage);
                    }
                }
            }
            return messages;
        }

        #endregion


    }
}
