export class SystemConstant {
  public static post = 'POST';
  public static delete = 'DELETE';
  public static put = 'PUT';
  public static authorization = 'authorization';
  public static expectedRole = 'expectedRole';
}

export class HeaderTabConstant {
  public static dashboard = 'Dashboard';
  public static patients = 'Patients';
  public static lab = 'Lab';
  public static faq = 'FAQ';
  public static contactUs = 'Contact Us';
  public static contactDoctor = 'Contact Doctor';
}

export class UserRole {
  public static principal = 'principal';
  public static teacher = 'teacher';
  public static student = 'student';

  public static principalRoleId = '1';
  public static teacherRoleId = '2';
  public static studentRoleId = '3';
}

export class QuestionTypeConstant {
  public static textValue = 'text';
  public static textViewValue = 'Text';
  public static radioValue = 'radio';
  public static radioViewValue = 'Radio';
  public static checkboxValue = 'checkbox';
  public static checkboxViewValue = 'Checkbox';
  public static selectValue = 'select';
  public static selectViewValue = 'Select';
}
