namespace Common.Constants;

public static class SystemConstants
{
    public const string SUCCESS = "Success";

    public const string CONNECTION_STRING_NAME = "DefaultConnection";

    public static readonly string CORS_POLICY = "SchoolManagementCors";

    public static readonly string CORS_ALLOWED_ORIGIN = "http://localhost:4200";

    public static readonly int PASSWORD_ITERATION = 10;

    public const string MAIL_TEMPLATES = "MailTemplates";

    public const string PRINCIPAL_NAME = "Anurag Patwardhan";

    public const string USER_ID_CLAIM = "UserId";

    public const string BEARER = "Bearer ";

    public const string ZERO_STRING = "0";

    public const int DEFAULT_PAGE_SIZE = 10;

    public const int INITIAL_PAGE_SIZE = 1;

    public const string ASCENDING = "ascending";

    public const string DESCENDING = "descending";

    public const string DEFAULT_SORTCOLUMN = "Id";

    public const int PASSWORD_LENGTH = 8;

    public const string LOGGED_USER = "LoggedUser";

    public const string DEFAULT_AVATAR_ROUTE = "../../../../assets/images/avatar.jpg";

    public const string SICK_LEAVE = "Sick Leave";

    public const string LOWERCASE_ALPHABETS = "abcdefghijklmnopqrstuvwxyz";

    public const string UPPERCASE_ALPHABETS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public const string DIGITS = "0123456789";

    public const string SPECIAL_CHARS = "$@$!%*?&";

    public const int OTP_EXPIRY_TIME = 10;

    public const int OTP_GENERATE_MIN_VALUE = 100000;

    public const int OTP_GENERATE_MAX_VALUE = 999999;

    public const int SICK_LEAVE_TYPE = 8;

    public const string REQUEST_DATE_COLUMN = "RequestDate";

    public const string USE_DOCUMENT_FOR_CONTACT_PRINCIPAL = "Contact Principal";

    public const string USE_DOCUMENT_FOR_CHAPTER_DOCUMENT = "Chapter Document";

    #region Policy Attribute

    public const string PRINCIPAL_POLICY = "Principal";

    public const string TEACHER_POLICY = "Teacher";

    public const string STUDENT_POLICY = "Student";

    public const string LAB_INSTRUCTOR_POLICY = "LabInstructor";

    public const string ALL_USER_POLICY = "AllUser";

    public const string TEACHER_PRINCIPAL_POLICY = "Teacher_Principal";

    public const string STUDENT_TEACHER_POLICY = "Student_Teacher";

    #endregion Policy Attribute

    #region ModelStateConstant

    public static class ModelStateConstant
    {
        public const string SORTORDER_REGEX = $"^({ASCENDING}|{DESCENDING})$";

        public const string VALIDATE_SORTORDER = "Sort Order must be ascending or descending!";
    }

    #endregion ModelStateConstant

    #region MailTemplateFiles

    public const string OTP_MAIL_TEMPLATE_FILE = "OtpMailTemplate.html";

    public const string GENERATE_CREDENTIALS = "GenerateCredentialsMailTemplate.html";

    public const string CONTACT_PRINCIPAL_RESPONSE_FILE = "ContactPrincipalResponseMailTemplate.html";

    public const string CONTACT_PRINCIPAL_REQUEST_FILE = "CreateContactPrincipalRequestMailTemplate.html";

    public const string DECLINE_ADMIT_REQUEST_FILE = "DeclineAdmitRequestMailTemplate.html";

    public const string BLOCK_ADMIT_REQUEST_FILE = "BlockAdmitRequestMailTemplate.html";

    #endregion
}
