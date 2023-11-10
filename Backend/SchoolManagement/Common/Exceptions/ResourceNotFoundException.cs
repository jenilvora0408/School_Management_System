using System.Net;

namespace Common.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
        public List<string> Messages { get; set; }
        public Dictionary<string, object>? Metadata { get; set; }

        public ResourceNotFoundException(string message, Dictionary<string, object>? metadata = null) : base(message)
        {
            StatusCode = (int)HttpStatusCode.NotFound;
            Metadata = metadata;
            Messages = new List<string>() { message };
        }

        public ResourceNotFoundException(List<string> messages, Dictionary<string, object>? metaData = null) : base(messages[0])
        {
            StatusCode = (int)HttpStatusCode.NotFound;
            Messages = messages;
            Metadata = metaData;
        }
    }
}
