namespace Common.Constants;

public static class APIRouteConstants
{
    #region Common_Controller

    public const string COMMON_ENTITYLIST = "common-entity-list";

    public const string ADMIT_REQUEST_LIST = "admit-request-list";

    public const string GET_ALL_CLASSES_INFO = "get-all-classes-info";
    
    #endregion

    #region Principal_Controller

    public const string EDIT_CLASS = "edit-class";

    #endregion

    #region Teacher_Controller

    public const string GET_ADMIT_REQUEST = "get-admit-request/{id}";

    public const string CREATE_LEAVE_REQUEST = "create-leave-request";

    public const string LEAVE_REQUEST_LIST = "leave-request-list";

    public const string ADMIT_REQUEST_APPROVAL = "admit-request-approval";

    public const string GET_LEAVES_COUNT = "get-leaves-count/{userId}";

    #endregion

    #region User_Controller

    public const string CREATE_ADMIT_REQUEST = "create-admit-request";

    public const string LOGIN = "login";

    public const string VERIFY_OTP = "verify-otp";

    public const string SEND_OTP = "send-otp";

    public const string FORGET_PASSWORD = "forget-password";

    public const string RESET_PASSWORD = "reset-password";

    #endregion
}
