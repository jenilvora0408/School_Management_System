export class ApiCallConstant {
  public static readonly BASE_URL = 'https://localhost:44389/api/';

  //Area name
  public static readonly AREA_DOCTOR = this.BASE_URL + 'doctors';
  public static readonly AREA_PATIENT = this.BASE_URL + 'patient';
  public static readonly AREA_LAB = this.BASE_URL + 'lab';
  public static readonly AREA_AUTHENTICATION = this.BASE_URL + 'authentication';
  public static readonly AREA_HEADER = this.BASE_URL + 'header';

  //for authentication
  public static readonly LOGIN_URL = this.AREA_AUTHENTICATION + '/login';
  public static readonly VERIFY_OTP_URL =
    this.AREA_AUTHENTICATION + '/verify-otp';
  public static readonly RESEND_OTP_URL =
    this.AREA_AUTHENTICATION + '/resend-otp';
  public static readonly FORGOT_PASSWORD_URL =
    this.AREA_AUTHENTICATION + '/forgot-password';
  public static readonly RESET_PASSWORD_URL =
    this.AREA_AUTHENTICATION + '/reset-password';
  public static readonly REFRESH_TOKEN_URL =
    this.AREA_AUTHENTICATION + '/refresh-jwttoken';

  // Header
  public static readonly GET_AVATAR = this.BASE_URL + 'header/getavatar';
  public static readonly GET_FAQ = this.BASE_URL + 'header/faq';

  //Profile
  public static readonly GET_GENDER_DATA = this.BASE_URL + 'profile/getGenders';
  public static readonly GET_PROFILE_DETAILS =
    this.BASE_URL + 'profile/getprofiledetails';
  public static readonly UPDATE_PROFILE_DETAILS =
    this.BASE_URL + 'profile/updateProfileDetails';
  public static readonly SEND_PROFILE_OTP =
    this.BASE_URL + 'profile/sendProfileOtp';
  public static readonly VERIFY_PROFILE_OTP =
    this.BASE_URL + 'profile/verifyProfileOtp';

  //Doctor Module

  //For patient and lab registration

  public static readonly REGISTER_USER = this.AREA_DOCTOR + '/register-user';
  public static readonly UPDATE_USER = this.AREA_DOCTOR + '/update-user';
  public static readonly SEARCH_PATIENT = this.AREA_DOCTOR + '/patients/search';
  public static readonly GET_USER = this.AREA_DOCTOR + '/user';
  public static readonly GET_LAB_USER = this.AREA_DOCTOR + '/lab';
  public static readonly DELETE_USER = this.AREA_DOCTOR + '/delete-user';

  //For Ask for more infomration
  public static readonly REQUEST_MORE_INFO = 'request-more-info';
  public static readonly CLINICAL_PROCESS = 'clinical-process';

  public static readonly PATIENT_INFO_REQUEST =
    this.AREA_DOCTOR + `/patients/${this.REQUEST_MORE_INFO}`;
  public static readonly LOAD_MORE_QUESTIONS = `${this.AREA_PATIENT}/${this.REQUEST_MORE_INFO}`;
  public static readonly PATIENT_CLINICAL_PROFILE = `${this.AREA_DOCTOR}/${this.CLINICAL_PROCESS}/request-clinical-profile`;

  //Doctor Dashboard
  public static readonly GET_PATIENT =
    this.AREA_DOCTOR + '/patientListForDoctor';

  //Doctor Action Menu
  public static readonly GET_LAB_RESULT = this.AREA_DOCTOR + '/getlabresult';
  public static readonly DOWNLOAD_LAB_RESULT =
    this.AREA_HEADER + '/downloadfile';
  public static readonly PUBLISH_RESULT = this.AREA_DOCTOR + '/sendresult';
  public static readonly GET_PATIENT_DETAILS =
    this.AREA_DOCTOR + '/patientdetails';
  public static readonly GET_PATIENT_TEST_DETAILS =
    this.AREA_DOCTOR + '/getpatienttestdetails';
  public static readonly PRESCRIBE_TEST = this.AREA_DOCTOR + '/prescribetest';
  public static readonly SEE_CLINICAL_ANSWER = this.AREA_DOCTOR + '/getanswers';
  public static readonly ADD_CLINICAL_QUESTIONS =
    this.AREA_DOCTOR + '/addclinicalquestions';
  public static readonly GET_CLINICAL_QUESTIONS_FOR_DOCTOR =
    this.AREA_DOCTOR + '/getClinicalQuestionForDoctor';
  public static readonly COLLECT_SAMPLE =
    this.AREA_DOCTOR + '/clinical-process/collect-sample';
  public static readonly SHIP_SAMPLE =
    this.AREA_DOCTOR + '/clinical-process/ship-sample';
  public static readonly DELETE_CLINICAL_QUESTION =
    this.AREA_DOCTOR + '/deleteClinicalQuestion';

  //Patient Module
  public static readonly GET_DOCTOR_DETAILS =
    this.AREA_PATIENT + '/contact-doctor';
  public static readonly GET_STATUS_BY_ID_PATIENT =
    this.AREA_PATIENT + '/getstatusbyid';
  public static readonly GET_CLINICAL_PATH =
    this.AREA_PATIENT + '/getclinicalpath';
  public static readonly UPDATE_CLINICAL_ANSWER =
    this.AREA_PATIENT + '/clinicalanswers';
  public static readonly GET_CLINICAL_ENHANCEMENT =
    this.AREA_PATIENT + '/getclinicalenhancement';
  public static readonly POST_CLINICAL_ENHANCEMENT =
    this.AREA_PATIENT + '/clinicalenhancementanswers';

  //Lab Module
  public static readonly GET_PATIENT_LIST_LAB = this.AREA_LAB + '/patientlist';
  public static readonly GET_USER_BY_ID_LAB = this.AREA_LAB + '/getuserbyid';
  public static readonly UPLOAD_RESULT_LAB = this.AREA_LAB + '/postlabresult';
  public static readonly RECEIVED_SAMPLE_STATUS_UPDATE =
    this.AREA_LAB + '/clinical-process/receive-sample';

  //Notification
  public static readonly GET_NOTIFICATION_COUNT =
    this.BASE_URL + 'notification/getNotificationsCount';

  public static readonly GET_NOTIFICATIONS =
    this.BASE_URL + 'notification/getNotifications';

  public static readonly READ_NOTIFICATIONS =
    this.BASE_URL + 'notification/readNotifications';

  public static readonly DELETE_NOTIFICATIONS =
    this.BASE_URL + 'notification/deleteNotifications';

  public static readonly GET_SWIPE_SETTING =
    this.BASE_URL + 'notification/getSwipeSetting';

  public static readonly SAVE_SWIPE_SETTING =
    this.BASE_URL + 'notification/saveSwipeSetting';
}
