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

    private static string CreateMessage(string body)
    {
        return body;
    }
}
