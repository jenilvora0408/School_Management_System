namespace Common.Constants;

public static class MessageConstants
{
    #region Error_Messages

    public static class ErrorMessage
    {
        public const string DEFAULT_ERROR_MESSAGE = "Something went wrong!";

        public const string TOKEN_EXPIRED = "Your session has been expired!";

        public const string INVALID_MODELSTATE = "Invalid Entry";

        public const string INTERNAL_SERVER = "An error occurred while processing the request";

        public const string STRING_VALIDATION = "String cannot be empty or have white space";

        public const string INVALID_TOKEN = "Invalid Token!";

        public const string UNAUTHORIZE = "Access Unauthorized!";

        public const string USER_NOT_FOUND = "User not found!";

        public const string ADMIT_REQUEST_NOT_FOUND = "Admit Request not Found!";

        public const string INVALID_USER = "Invalid User!";

        public const string CLASS_NOT_FOUND = "Class not found!";

        public const string LEAVE_REQUEST_NOT_FOUND = "Leave Request not found!";

        public const string CONTACT_REQUEST_NOT_FOUND = "Contact Principal Request not found!";

        public const string CLASS_SUBJECT_NOT_FOUND = "The course you are trying to add for respective class & subject is not availabe at this moment!";

        public const string CLASS_SUBJECT_INVALID_CREDENTIALS = "The subject is not associated with the class!";

        public const string SUBJECT_NOT_FOUND = "Subject not found!";

        public const string CHAPTER_NOT_FOUND = "Chapter not found!";

        public const string DOCUMENT_NOT_FOUND = "Document not found!";

        public const string CHAPTER_DOCUMENT_ALREADY_PRESENT = "Document for this chapter already exists!";

        public const string STUDENT_NOT_FOUND = "Student not Found!";
    }

    public static class SuccessMessage
    {
        public const string OTP_SENT = "OTP has been sent to your registered email.";

        public const string LOGIN_SUCCESS = "Logged in Sucessfully!";

        public const string PASSWORD_RESETTED = "Password resetted successfully!";

        public const string LEAVE_REQUEST_CREATED = "Leave Request was created successfully!";

        public const string ADMIT_REQUEST_CREATED = "Admit Request was created successfully!";

        public const string CLASS_EDITED = "Class Information edited successfully!";

        public const string PROFILE_UPDATED = "Your profile has been updated successfully!";

        public const string LEAVE_APPROVED = "Leave Request has been approved successfully!";

        public const string LEAVE_DECLINED = "Leave Request has been declined successfully!";

        public const string CONTACT_PRINCIPAL_SUCCESS = "Your request has been sent to the Principal!";

        public const string SAVE_CONTACT_PRINCIPAL_RESPONSE = "Your response to the contact request has been saved successfully!";

        public const string DOCUMENT_ADDED = "The document has been added successfully!";

        public const string DOCUMENT_UPDATED = "The document has been updated successfully!";

        public const string DOCUMENT_REMOVED = "The document has been deleted successfully!";
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

        public const string DEFAULT_MODELSTATE = "Model state is Invalid!";

        public const string INVALID_OTP = "OTP is Invalid!";

        public const string INVALID_CREDENTIALS = "Invalid credentials!";
    }

    #endregion Validation_Messages

    #region Email_Constants

    public static class EmailConstants
    {
        public const string GENERIC_SUBJECT = "School || noreply email";

        public const string OTP_SUBJECT = "School || Verification OTP || No Reply";

        public const string GENERATE_LOGIN_CREDENTIALS_SUBJECT = "School || Generate Login Credentials || No Reply";

        public const string RESET_PASSWORD_SUBJECT = "School || ResetPassword || No Reply";

        public const string CONTACT_PRINCIPAL_RESPONSE = "School || Contact Principal Response || No Reply";

        public const string DECLINE_ADMIT_REQUEST = "School || Decline Admit Request || No Reply";

        public const string BLOCK_ADMIT_REQUEST = "School || Block Admit Request || No Reply";
    }

    #endregion Email_Constants
}
