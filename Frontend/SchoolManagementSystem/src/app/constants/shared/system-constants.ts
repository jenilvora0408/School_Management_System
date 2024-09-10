export class UserRole {
  public static principal = 'principal';
  public static teacher = 'teacher';
  public static student = 'student';

  public static principalRoleId = '1';
  public static teacherRoleId = '2';
  public static studentRoleId = '3';
}

export class SystemConstants {
  public static EncryptionKey = 'SchoolPortal';
  public static Ascending = 'ascending';
  public static Descending = 'descending';
  public static DefaultAvatar = '../../../../assets/images/avatar.jpg';
}

export class StatusConstants {
  public static pending = 'Pending';
  public static approved = 'Approved';
  public static declined = 'Declined';
  public static blocked = 'Blocked';
}

export class LeaveTypeConstants {
  public static sickLeave = 'Sick Leave';
  public static casualLeave = 'Casual Leave';
  public static adhocLeave = 'Adhoc Leave';
}
