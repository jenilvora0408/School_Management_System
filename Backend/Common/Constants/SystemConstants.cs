namespace Common.Constants;

public static class SystemConstants
{
    public const string SUCCESS = "Success";

    public const string CONNECTION_STRING_NAME = "DefaultConnection";

    public static readonly string CORS_POLICY = "SchoolManagementCors";

    public static readonly string CORS_ALLOWED_ORIGIN = "http://localhost:4200";

    public static readonly int PASSWORD_ITERATION = 10;

    public const string MAIL_TEMPLATES = "MailTemplates";

    public const string OTP_MAIL_TEMPLATE_FILE = "OtpMailTemplate.html";

    public const string USER_ID_CLAIM = "UserId";

    public const string BEARER = "Bearer ";

    public const string ZERO_STRING = "0";

    public const int DEFAULT_PAGE_SIZE = 10;

    public const string ASCENDING = "ascending";

    public const string DESCENDING = "descending";

    public const string DEFAULT_SORTCOLUMN = "Id";

    #region ModelStateConstant

    public static class ModelStateConstant
    {
        public const string SORTORDER_REGEX = $"^({ASCENDING}|{DESCENDING})$";

        public const string VALIDATE_SORTORDER = "Sort Order must be ascending or descending!";
    }

    #endregion ModelStateConstant
}
