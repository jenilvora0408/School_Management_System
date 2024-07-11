export class ApiCallConstant {
  public static readonly BASE_URL = 'http://localhost:5108/api/';

  //Controller name
  public static readonly COMMON_CONTROLLER = this.BASE_URL + 'common/';
  public static readonly USER_CONTROLLER = this.BASE_URL + 'user/';

  //Common Controller name
  public static readonly GET_COMMON_ENTITY_DATA =
    this.COMMON_CONTROLLER + 'common-entity-list';

  //User Controller name
  public static readonly CREATE_ADMIT_REQUEST =
    this.USER_CONTROLLER + 'create-admit-request';

  public static readonly LOGIN_URL = this.USER_CONTROLLER + 'login';
  public static readonly VERIFY_OTP_URL = this.USER_CONTROLLER + 'verify-otp';
  public static readonly SEND_OTP = this.USER_CONTROLLER + 'send-otp';
  public static readonly FORGET_PASSWORD =
    this.USER_CONTROLLER + 'forget-password';
  public static readonly RESET_PASSWORD =
    this.USER_CONTROLLER + 'reset-password';
}
