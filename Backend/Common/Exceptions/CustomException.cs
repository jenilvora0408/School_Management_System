namespace Common.Exceptions;

public class CustomException : Exception
{
    public int StatusCode { get; set; }
    public List<string> Messages { get; set; }

    public CustomException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
        Messages = new List<string>() { message };
    }

    public CustomException(int statusCode, List<string> message) : base(message[0])
    {
        StatusCode = statusCode;
        Messages = message;
    }
}
