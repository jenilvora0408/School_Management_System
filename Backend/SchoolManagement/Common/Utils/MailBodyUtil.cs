namespace Common.Utils;

public class MailBodyUtil
{
    private const string header = @"
<head>
  <style>
    /* Reset some default styles for better email rendering */
    body, div, p {
      margin: 0;
      padding: 0;
    }

    /* Main styles for the email */
    .email-container {
      font-family: Arial, sans-serif;
      max-width: 600px;
      margin: 0 auto;
      padding: 20px;
      border: 1px solid #ccc;
      background-color: #f4f4f4;
    }

    .email-header {
      background-color: #007bff;
      color: #fff;
      text-align: center;
      padding: 10px 0;
    }

    .email-content {
      padding: 20px;
      background-color: #fff;
    }

    .email-footer {
      text-align: center;
      padding: 10px 0;
      color: #777;
    }
  </style>
</head>";

    private const string footer = $@" <div class='email-footer'>
      <p>This email was sent from School Management System.</p>
    </div>";

    public static string SendOtpForAuthenticationBody(string otp)
    {
        string body = $@"<div class='email-container'>
    <div class='email-header'>
      <h1>Welcome to Our Community!</h1>
    </div>
    <div class='email-content'>
      <p>Dear User,</p>
      <p>Here is the otp for authentication and it is valid for 10 minutes only:</p>
      <ul>
        <li><strong>OTP:</strong> {otp}</li>
      </ul>
      <p>Thank you for using our service !</p>
    </div>
  </div>";
        return CreateMessage(body);
    }

    public static string SendOtpForProfileBody(string otp)
    {
        string body = $@"<div class='email-container'>
        <div class='email-header'>
            <h1>Profile Update OTP</h1>
        </div>
        <div class='email-content'>
            <p>Dear User,</p>
            <p>Your OTP for profile update is:</p>
        <ul>
            <li><strong>OTP:</strong> {otp}</li>
        </ul>
            <p>This OTP is valid for 10 minutes. Please use it to complete your profile update.</p>
            <p>Thank you for using our service!</p>
        </div>
    </div>";

        return CreateMessage(body);
    }


    public static string SendResetPasswordLink(string link)
    {
        string body = $@"<div class='email-container'>
    <div class='email-header'>
      <h1>Welcome to Our Community!</h1>
    </div>
    <div class='email-content'>
      <p>Dear User,</p>
      <p>Here is link for resetting your account password and it is valid for 10 minutes only:</p>
      <ul>
        <li>{link}</li>
      </ul>
      <p>Thank you for using our service !</p>
    </div>
  </div>";


        return CreateMessage(body);
    }

    private static string CreateMessage(string body)
    {
        return $@"<!DOCTYPE html>
                <html>
                    {header}
                    <body>
                        {body}
                        {footer}
                    </body>
                </html>
                ";
    }

}