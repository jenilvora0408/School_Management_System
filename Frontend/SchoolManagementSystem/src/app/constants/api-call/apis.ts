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
}
