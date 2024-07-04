namespace Common.Constants;

public static class MessageConstants
{
    #region Error_Messages

    public static class ErrorMessage
    {
        public const string INVALID_MODELSTATE = "Invalid Entry";

        public const string INTERNAL_SERVER = "An error occurred while processing the request";

        public const string STRING_VALIDATION = "String cannot be empty or have white space";
    }

    public static class SuccessMessage
    {
        public const string OTP_SENT = "OTP has been sent to your registered email.";
    }

    #endregion Error_Messages

    #region Validation_Messages

    public static class ValidationConstants
    {
        public const string VALIDATION_ERROR = "One or more validation failures have occured!";

        public const string INVALID_EMAIL = "Email is Invalid!";

        public const string INVALID_FIRST_NAME = "First Name is Invalid!";

        public const string INVALID_LAST_NAME = "Last Name is Invalid!";

        public const string ACCESS_ALREADY_PROVIDED = "You already have access to this portal!";

        public const string ACCESS_BLOCKED = "Your access to this portal has been blocked!";

        public const string ADMIT_REQUEST_ALREADY_EXISTS = "A request from this email is already present. Please wait while we update you further!";

        public const string INVALID_LOGIN_CREDENTIAL = "Invalid username or password.";
    }

    #endregion Validation_Messages

    #region Email_Constants

    public static class EmailConstants
    {
        public const string GENERIC_SUBJECT = "School || noreply email";

        public const string OTP_SUBJECT = "School || Verification OTP || No Reply";

        public const string RESET_PASSWORD_SUBJECT = "School || ResetPassword || No Reply";
    }

    #endregion Email_Constants
}
