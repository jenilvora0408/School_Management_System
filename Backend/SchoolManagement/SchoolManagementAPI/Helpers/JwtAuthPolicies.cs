using Common.Constants;
using Microsoft.AspNetCore.Authorization;

namespace SchoolManagementAPI.Helpers
{
    public class StudentPolicyAttribute : AuthorizeAttribute
    {
        public StudentPolicyAttribute()
        {
            Policy = SystemConstants.STUDENT_POLICY;
        }
    }

    public class TeachersPolicyAttribute : AuthorizeAttribute
    {
        public TeachersPolicyAttribute()
        {
            Policy = SystemConstants.TEACHER_POLICY;
        }
    }

    public class LabInstructorsPolicyAttribute : AuthorizeAttribute
    {
        public LabInstructorsPolicyAttribute()
        {
            Policy = SystemConstants.LAB_INSTRUCTOR_POLICY;
        }
    }

    public class PrincipalPolicyAttribute : AuthorizeAttribute
    {
        public PrincipalPolicyAttribute()
        {
            Policy = SystemConstants.PRINCIPAL_POLICY;
        }
    }

    public class AllPolicyAttribute : AuthorizeAttribute
    {
        public AllPolicyAttribute()
        {
            Policy = SystemConstants.ALL_USER_POLICY;
        }
    }

    public class TeacherPrincipalPolicyAttribute : AuthorizeAttribute
    {
        public TeacherPrincipalPolicyAttribute()
        {
            Policy = SystemConstants.TEACHER_PRINCIPAL_POLICY;
        }
    }
}
