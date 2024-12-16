import { environment } from '../../../environments/environment';

export class ApiCallConstant {
  public static readonly BASE_URL = environment.baseUrl;

  //Controller name
  public static readonly COMMON_CONTROLLER = this.BASE_URL + 'common/';
  public static readonly USER_CONTROLLER = this.BASE_URL + 'user/';
  public static readonly TEACHER_CONTROLLER = this.BASE_URL + 'teacher/';
  public static readonly PRINCIPAL_CONTROLLER = this.BASE_URL + 'principal/';

  //Common Controller Methods
  public static readonly GET_COMMON_ENTITY_DATA =
    this.COMMON_CONTROLLER + 'common-entity-list';

  public static readonly GET_ADMIT_REQUEST_LIST =
    this.COMMON_CONTROLLER + 'admit-request-list';

  public static readonly GET_ALL_CLASSES_INFO =
    this.COMMON_CONTROLLER + 'get-all-classes-info';

  public static readonly GET_ALL_TEACHERS =
    this.COMMON_CONTROLLER + 'get-all-teachers';

  public static readonly GET_ALL_SUBJECTS =
    this.COMMON_CONTROLLER + 'get-all-subjects';

  public static readonly GET_MY_PROFILE =
    this.COMMON_CONTROLLER + 'get-user-profile';

  public static readonly UPDATE_USER_PROFILE =
    this.COMMON_CONTROLLER + 'update-user-profile';

  public static readonly LEAVE_REQUEST_APPROVAL =
    this.COMMON_CONTROLLER + 'leave-request-approval';

  public static readonly CONTACT_PRINCIPAL =
    this.COMMON_CONTROLLER + 'contact-principal';

  public static readonly VIEW_OWN_CONTACT_REQUESTS =
    this.COMMON_CONTROLLER + 'view-own-contact-requests';

  public static readonly GET_CONTACT_PRINCIPAL_DOCUMENTS =
    this.COMMON_CONTROLLER + 'contact-documents';

  //User Controller Methods
  public static readonly CREATE_ADMIT_REQUEST =
    this.USER_CONTROLLER + 'create-admit-request';

  public static readonly LOGIN_URL = this.USER_CONTROLLER + 'login';

  public static readonly VERIFY_OTP_URL = this.USER_CONTROLLER + 'verify-otp';

  public static readonly SEND_OTP = this.USER_CONTROLLER + 'send-otp';

  public static readonly FORGET_PASSWORD =
    this.USER_CONTROLLER + 'forget-password';

  public static readonly RESET_PASSWORD =
    this.USER_CONTROLLER + 'reset-password';

  public static readonly CHECK_STATUS_OF_REQUEST =
    this.USER_CONTROLLER + 'check-admit-request-status';

  //Teacher Controller Methods
  public static readonly VIEW_ADMIT_REQUEST =
    this.TEACHER_CONTROLLER + 'get-admit-request';

  public static readonly ADMIT_REQUEST_APPROVAL =
    this.TEACHER_CONTROLLER + 'admit-request-approval';

  public static readonly GET_LEAVE_REQUEST_LIST =
    this.TEACHER_CONTROLLER + 'leave-request-list';

  public static readonly CREATE_LEAVE_REQUEST =
    this.TEACHER_CONTROLLER + 'create-leave-request';

  public static readonly GET_LEAVES_COUNT =
    this.TEACHER_CONTROLLER + 'get-leaves-count';

  public static readonly GET_CLASSES_FOR_SUBJECT_TEACHER =
    this.TEACHER_CONTROLLER + 'get-classes-for-subject-teacher';

  public static readonly CHAPTERS_OF_CLASS_SUBJECT =
    this.TEACHER_CONTROLLER + 'chapters-of-class-subject';

  public static readonly GET_CHAPTER_DOCUMENT =
    this.TEACHER_CONTROLLER + 'chapter-document';

  public static readonly MANAGE_CHAPTER_DOCUMENT =
    this.TEACHER_CONTROLLER + 'manage-chapter-document';

  // Principal Controller Methods

  public static readonly GET_ALL_SUBJECTS_BY_CLASS_ID =
    this.PRINCIPAL_CONTROLLER + 'get-all-subjects-by-class';

  public static readonly EDIT_CLASS = this.PRINCIPAL_CONTROLLER + 'edit-class';

  public static readonly LEAVE_REQUESTS =
    this.PRINCIPAL_CONTROLLER + 'leave-requests-awaiting-approval';

  public static readonly CONTACT_PRINCIPAL_REQUESTS =
    this.PRINCIPAL_CONTROLLER + 'contact-principal-list';

  public static readonly POST_CONTACT_PRINCIPAL_RESPONSE =
    this.PRINCIPAL_CONTROLLER + 'principal-response';

  public static readonly GET_CHAPTERS_FOR_CLASS_SUBJECT =
    this.PRINCIPAL_CONTROLLER + 'get-all-courses-by-class-subject';

  public static readonly UPSERT_COURSE_CHAPTERS =
    this.PRINCIPAL_CONTROLLER + 'upsert-course-chapters';
}
