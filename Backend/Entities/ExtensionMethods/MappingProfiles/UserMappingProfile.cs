using Entities.DataModels;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class UserMappingProfile
{
    public static void ToGenerateOtp(this User user, string otp, DateTime expiryTime)
    {
        user.OTP = otp;
        user.ExpiryTime = expiryTime;
    }

    public static void ToSetPassword(this User user, string password)
    {
        user.Password = password;
    }

    public static void ToVerifyOtp(this User user)
    {
        user.OTP = null;
        user.ExpiryTime = null;
    }
}
