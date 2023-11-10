using System.Net;

namespace Common.Exceptions
{
    public class FileNullException : Exception
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
        public List<string> Messages { get; set; }
        public Dictionary<string, object>? Metadata { get; set; }

        public FileNullException(string message, Dictionary<string, object>? metadata = null) : base(message)
        {
            StatusCode = (int)HttpStatusCode.NotFound;
            Metadata = metadata;
            Messages = new List<string>() { message };
        }

        public FileNullException(List<string> messages, Dictionary<string, object>? metaData = null) : base(messages[0])
        {
            StatusCode = (int)HttpStatusCode.NotFound;
            Messages = messages;
            Metadata = metaData;
        }
    }
}
