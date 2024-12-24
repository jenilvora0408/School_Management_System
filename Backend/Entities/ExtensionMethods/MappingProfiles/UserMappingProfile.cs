using Common.Constants;
using Entities.DataModels;
using Entities.DTOs;

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

    public static IEnumerable<TeachersListResponseDTO> ToTeachersListResponseDTOs(this IEnumerable<User> users, IEnumerable<Class> classes) 
    {
        return users.Select(user => new TeachersListResponseDTO()
        {
            UserId = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            IsAssigned = classes.Any(cls => cls.ClassTeacherId == user.Id),
            AssignedClassId = classes.Where(cls => cls.ClassTeacherId == user.Id).Select(cls => (int?)cls.Id).FirstOrDefault(),
        }).ToList();
    }

    public static GetUserProfileDTO ToGetUserProfile(User user) => new()
    {
        UserId = user.Id,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Email = user.Email,
        PhoneNumber = user.PhoneNumber,
        Address = user.Address,
        City = user.City,
        Headline = user.Headline,
        Avatar = user.Avatar
    };

    public static void ToUpdateUserProfile (GetUserProfileDTO getUserProfileDTO, User user)
    {
        user.FirstName = getUserProfileDTO.FirstName;
        user.LastName = getUserProfileDTO.LastName;
        user.Email = getUserProfileDTO.Email;
        user.PhoneNumber = getUserProfileDTO.PhoneNumber;
        user.Address = getUserProfileDTO.Address;
        user.City = getUserProfileDTO.City;
        user.Headline = getUserProfileDTO.Headline;
        user.Avatar = getUserProfileDTO.Avatar ?? string.Empty;
    }

    public static UnassignedTeachersDTO ToUnassignedTeachersDTO(this User user)
    {
        return new UnassignedTeachersDTO
        {
            UserId = user.Id,
            UserName = $"{user.FirstName} {user.LastName}"
        };
    }
}
