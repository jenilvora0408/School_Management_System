export class ValidationPattern {
  public static email =
    /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
  public static password =
    /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{7,15}$/;
  public static phoneNumber = /^[5-9]{1}[0-9]{9}$/;
  public static names = /^[a-zA-Z]+$/;
  public static link = /^(https?:\/\/)?([\w-]+\.)+[\w-]+(\/[\w- .\/?%&=]*)?$/;
  public static number = /[0-9]/;
  
}
