using Entities.DataModels;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class StudentMappingProfile
{
    public static Student ToAddStudents(this AdmitRequest admitRequest) => new()
    {
        StudentName = admitRequest.FirstName + ' ' + admitRequest.LastName,
        ClassId = admitRequest.ClassId ?? 0,
        MediumId = admitRequest.MediumId ?? 0
    };
}
