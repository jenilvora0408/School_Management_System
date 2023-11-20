namespace Common.Constants
{
    public class SystemConstants
    {
        #region Basic_Config

        public static readonly string CORS_POLICY = "SchoolManagementCors";

        public const string CONNECTION_STRING_NAME = "DefaultConnection";

        public static readonly int MAX_PAGE_SIZE_RESPONSE = 50;

        #endregion


        #region Claim_Type

        public const string USER_ID_CLAIM = "UserId";

        public const string AVATAR_CLAIM = "Avatar";

        #endregion


        #region Others

        public const string ZERO_STRING = "0";

        #endregion

        #region Session Constant

        public const string LOGGED_USER = "LoggedUser";

        public const string BEARER = "Bearer ";

        public const string REMEMBER_ME_COOKIE_POLICY = "rememberMe";

        public const string TRUE_STRING = "True";

        #endregion


        #region Policy Attribute

        public const string PRINCIPAL_POLICY = "Principal";

        public const string TEACHER_POLICY = "Teacher";

        public const string STUDENT_POLICY = "Student";

        public const string LAB_INSTRUCTOR_POLICY = "LabInstructor";

        public const string ALL_USER_POLICY = "AllUser";

        #endregion Policy Attribute


        #region Otp

        public const string AUTHENTICATION_OTP = "AuthenticationOtp";

        #endregion


        #region Path_Constants

        public const string WWWROOT_PATH = "/wwwroot";

        public const string IMAGES_PATH = "/images/";

        public const string DEFAULT_AVATAR = "'/Images/profile.png'";

        #endregion
    }
}
