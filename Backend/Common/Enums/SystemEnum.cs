namespace Common.Enums;

public class SystemEnum
{
    public enum UserRoleType : byte
    {
        PRINCIPAL = 1,
        TEACHER = 2,
        STUDENT = 3,
        LAB_INSTRUCTOR = 4,
    }

    public enum StatusType : byte
    {
        PENDING = 1,
        APPROVED = 2,
        DECLINED = 3,
        SUSPENDED = 4,
        BLOCKED = 5,
        DELETED = 10
    }

    public enum GenderType : byte
    {
        MALE = 1,
        FEMALE = 2,
        OTHER = 3
    }

    public enum BloodGroupTypes : byte
    {
        A_POSITIVE = 1,
        A_NEGATIVE = 2,
        B_POSITIVE = 3,
        B_NEGATIVE = 4,
        O_POSITIVE = 5,
        O_NEGATIVE = 6,
        AB_POSITIVE = 7,
        AB_NEGATIVE = 8,
    }

}
