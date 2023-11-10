using System.Net;

namespace Common.Exceptions
{
    public class ForbiddenException : Exception
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.Forbidden;
        public List<string> Messages { get; set; }
        public Dictionary<string, object>? Metadata { get; set; }

        public ForbiddenException(string message, Dictionary<string, object>? metadata = null) : base(message)
        {
            StatusCode = (int)HttpStatusCode.Forbidden;
            Metadata = metadata;
            Messages = new List<string>() { message };
        }

        public ForbiddenException(List<string> messages, Dictionary<string, object>? metaData = null) : base(messages[0])
        {
            StatusCode = (int)HttpStatusCode.Forbidden;
            Messages = messages;
            Metadata = metaData;
        }
    }
}
