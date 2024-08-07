using Common.Constants;
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

    public static User ToSaveAdmitRequestUser(this AdmitRequest admitRequest, string password) => new()
    {
        FirstName = admitRequest.FirstName,
        LastName = admitRequest.LastName,
        Email = admitRequest.Email,
        Password = password,
        PhoneNumber = admitRequest.PhoneNumber,
        Address = admitRequest.Address,
        RoleId = admitRequest.AdmitRequestRoleId,
        GenderId = admitRequest.GenderId,
        Avatar = admitRequest.Avatar ?? SystemConstants.DEFAULT_AVATAR_ROUTE,
        BloodGroupId = admitRequest.BloodGroupId,
        DateOfBirth = admitRequest.DateOfBirth
    };
}
