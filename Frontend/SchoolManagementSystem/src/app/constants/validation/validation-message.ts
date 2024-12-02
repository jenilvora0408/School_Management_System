export class ValidationMessageConstant {
  public static email = 'Enter a valid email address';
  public static password =
    'Password should be 8 to 15 character, it must contain 1 uppercase, 1 smallcase, 1 symbol charcter, 1 number';
  public static phoneNumber = 'Please enter a valid 10-digit phone number';
  public static avatarImageSizeError = 'File size must be less than 1MB.';
  public static avatarExtensionError = "Only .jpg, .jpeg, and .png files are allowed.";
  public static canUploadMax7Images = "You can upload a maximum of 7 images only!";
  public static imageAlreadyUploaded = 'This image has already been uploaded.';
  public static filterError = "Something went wrong while applying filters!";
  public static shortResponse = "Response Message is too short!";
  public static responseCannotExceed2000 = 'The response message cannot exceed 2000 characters.';
  public static responseMessageRequired = "Response Message is required!";
  public static chapterAlreadyExists = "The chapter already exists!";
  public static classTeacherAlreadyAssigned = "Class Teacher has already been assigned to another Class!";
}
