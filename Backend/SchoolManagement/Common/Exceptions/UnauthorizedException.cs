using System.Net;

namespace Common.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.Unauthorized;
        public List<string> Messages { get; set; }
        public Dictionary<string, object>? Metadata { get; set; }

        public UnauthorizedException(string message, Dictionary<string, object>? metadata = null) : base(message)
        {
            StatusCode = (int)HttpStatusCode.Unauthorized;
            Metadata = metadata;
            Messages = new List<string>() { message };
        }

        public UnauthorizedException(List<string> messages, Dictionary<string, object>? metaData = null) : base(messages[0])
        {
            StatusCode = (int)HttpStatusCode.Unauthorized;
            Messages = messages;
            Metadata = metaData;
        }
    }
}
