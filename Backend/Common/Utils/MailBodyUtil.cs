using Common.Constants;

namespace Common.Utils;

public class MailBodyUtil
{
    public static string SendOtpForAuthenticationBody(string otp, string name, string mailTemplateLink)
    {
        string filePath = Path.Combine(mailTemplateLink, SystemConstants.MAIL_TEMPLATES, SystemConstants.OTP_MAIL_TEMPLATE_FILE);

        string body = File.ReadAllText(filePath);
        body = body.Replace("{otp}", otp);
        body = body.Replace("{userName}", name);
        body = body.Replace("{purpose}", "Login");
        return CreateMessage(body);
    }

    public static string SendOtpForResetPasswordBody(string otp, string name, string mailTemplateLink)
    {
        string filePath = Path.Combine(mailTemplateLink, SystemConstants.MAIL_TEMPLATES, SystemConstants.OTP_MAIL_TEMPLATE_FILE);

        string body = File.ReadAllText(filePath);
        body = body.Replace("{otp}", otp);
        body = body.Replace("{userName}", name);
        body = body.Replace("{purpose}", "setting up new password");
        return CreateMessage(body);
    }

    public static string SendCredentialsForLogin(string username, string email, string password, string mailTemplateLink)
    {
        string filePath = Path.Combine(mailTemplateLink, SystemConstants.MAIL_TEMPLATES, SystemConstants.GENERATE_CREDENTIALS);

        string body = File.ReadAllText(filePath);
        body = body.Replace("{email}", email);
        body = body.Replace("{userName}", username);
        body = body.Replace("{password}", password);
        return CreateMessage(body);
    }

    public static string PostContactPrincipalResponse(string username, string subject, string responseMessage, string mailTemplateLink)
    {
        string filePath = Path.Combine(mailTemplateLink, SystemConstants.MAIL_TEMPLATES, SystemConstants.CONTACT_PRINCIPAL_RESPONSE_FILE);

        string body = File.ReadAllText(filePath);
        body = body.Replace("{userName}", username);
        body = body.Replace("{subject}", subject);
        body = body.Replace("{responseMessage}", responseMessage);
        return CreateMessage(body);
    }

    public static string CreateContactPrincipalRequest(string principalName, string userName, string subject, string mailTemplateLink)
    {
        string filePath = Path.Combine(mailTemplateLink, SystemConstants.MAIL_TEMPLATES, SystemConstants.CONTACT_PRINCIPAL_REQUEST_FILE);

        string body = File.ReadAllText(filePath);
        body = body.Replace("{username}", userName);
        body = body.Replace("{subject}", subject);
        body = body.Replace("{principalName}", principalName);
        return CreateMessage(body);
    }

    public static string DeclineAdmitRequest(string username, string mailTemplateLink)
    {
        string filePath = Path.Combine(mailTemplateLink, SystemConstants.MAIL_TEMPLATES, SystemConstants.DECLINE_ADMIT_REQUEST_FILE);

        string body = File.ReadAllText(filePath);
        body = body.Replace("{userName}", username);
        return CreateMessage(body);
    }

    public static string BlockAdmitRequest(string username, string reasonForBlock, string mailTemplateLink)
    {
        string filePath = Path.Combine(mailTemplateLink, SystemConstants.MAIL_TEMPLATES, SystemConstants.BLOCK_ADMIT_REQUEST_FILE);

        string body = File.ReadAllText(filePath);
        body = body.Replace("{userName}", username);
        body = body.Replace("{reasonForBlock}", reasonForBlock);
        return CreateMessage(body);
    }

    private static string CreateMessage(string body)
    {
        return body;
    }
}
