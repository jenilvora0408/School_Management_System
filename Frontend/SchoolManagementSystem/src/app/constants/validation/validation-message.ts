export class ValidationMessageConstant {
  public static email = 'Enter a valid email address';
  public static password =
    'Password should be 8 to 15 character, it must contain 1 uppercase, 1 smallcase, 1 symbol charcter, 1 number';
  public static phoneNumber = 'Please enter a valid 10-digit phone number';
  public static avatarImageSizeError = 'File size must be less than 1MB.';
  public static avatarExtensionError = "Only .jpg, .jpeg, and .png files are allowed.";
  public static canUploadMax7Images = "You can upload a maximum of 7 images only!";
  public static imageAlreadyUploaded = 'This image has already been uploaded.';
}
