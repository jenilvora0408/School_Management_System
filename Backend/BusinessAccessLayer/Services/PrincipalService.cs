using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using Common.Utils;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs;
using Entities.DTOs.Common;
using Entities.ExtensionMethods.MappingProfiles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using static Common.Constants.MessageConstants;
using static Common.Enums.SystemEnum;

namespace BusinessAccessLayer.Services;

[Obsolete]
public class PrincipalService(IUnitOfWork unitOfWork, ICommonService commonService, IHostingEnvironment environment, IMailService mailService) : IPrincipalService
{
    #region Constructor

    public readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMailService _mailService = mailService;
    private readonly ICommonService _commonService = commonService;
    private readonly IHostingEnvironment _environment = environment;

    #endregion Constructor

    #region HTTP_Methods

    public async Task UpsertClasses(ClassRequestDTO classRequestDTO, CancellationToken cancellationToken)
    {
        Class? existingClass = await _unitOfWork.ClassRepository.GetFirstOrDefaultAsync(x => x.Id == classRequestDTO.ClassId) ?? throw new CustomException(StatusCodes.Status422UnprocessableEntity, MessageConstants.ErrorMessage.CLASS_NOT_FOUND);

        if (classRequestDTO.ClassStrength.HasValue)
        {
            existingClass.ClassStrength = classRequestDTO.ClassStrength.Value;
        }

        if (classRequestDTO.ClassTeacherId.HasValue)
        {
            existingClass.ClassTeacherId = classRequestDTO.ClassTeacherId.Value;
        }

        if (classRequestDTO.SubjectDetails != null)
        {
            List<ClassSubject>? existingSubjects = await _unitOfWork.ClassSubjectRepository.GetListAsync(x => x.ClassId == classRequestDTO.ClassId);

            Dictionary<int, ClassSubject>? existingSubjectsDict = existingSubjects.ToDictionary(x => x.SubjectId);

            List<ClassSubject>? subjectsToRemove = existingSubjects.Where(x => !classRequestDTO.SubjectDetails.Any(y => y.SubjectId == x.SubjectId)).ToList();

            List<SubjectsListResponseDTO> subjectsToAdd = classRequestDTO.SubjectDetails.Where(x => !existingSubjectsDict.ContainsKey(x.SubjectId)).ToList();

            await _unitOfWork.ClassSubjectRepository.RemoveRangeAsync(subjectsToRemove);

            foreach (var subjectToAdd in subjectsToAdd)
            {
                ClassSubject classSubject = new()
                {
                    ClassId = classRequestDTO.ClassId,
                    SubjectId = subjectToAdd.SubjectId
                };

                await _unitOfWork.ClassSubjectRepository.AddAsync(classSubject);
            }
        }
        await _unitOfWork.ClassRepository.UpdateAsync(existingClass);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<SubjectsListResponseDTO>> GetSubjectsByClass(int classId)
    {
        List<ClassSubject> classSubjects = await _unitOfWork.ClassSubjectRepository.GetListAsync(predicate: x => x.ClassId == classId, includes: [x => x.Classes, x => x.Subjects, x => x.Subjects.SubjectTeacher]);

        List<SubjectsListResponseDTO> subjectsListResponseDTOs = ClassSubjectMappingProfile.ToClassSubjectListResponseDTOs(classSubjects);

        return subjectsListResponseDTOs;
    }

    public async Task<PageListResponseDTO<LeaveRequestsAwaitingApprovalDTO>> GetAllLeaveRequest(PageListRequestDTO leaveRequestsListDTO)
    {
        PageListRequestEntity<Leave> pageListRequestEntity = new()
        {
            PageIndex = leaveRequestsListDTO.PageIndex,
            PageSize = leaveRequestsListDTO.PageSize,
            SortColumn = !string.IsNullOrEmpty(leaveRequestsListDTO.SortColumn) ? leaveRequestsListDTO.SortColumn : null!,
            SortOrder = leaveRequestsListDTO.SortOrder,
            Predicate = leave =>
                leave.ApprovalFromUserId == (long)UserRoleType.PRINCIPAL && (leave.Users.FirstName.ToLower().Contains(leaveRequestsListDTO.SearchQuery.ToLower()) || leave.Users.LastName.ToLower().Contains(leaveRequestsListDTO.SearchQuery.ToLower()) || leave.Users.Email.ToLower().Contains(leaveRequestsListDTO.SearchQuery.ToLower())) && (
                leaveRequestsListDTO.Filter == (int)StatusType.ALL ||
                (leaveRequestsListDTO.Filter == (int)StatusType.PENDING && leave.ApprovalStatus == (byte)StatusType.PENDING) ||
                (leaveRequestsListDTO.Filter == (int)StatusType.APPROVED && leave.ApprovalStatus == (byte)StatusType.APPROVED) ||
                (leaveRequestsListDTO.Filter == (int)StatusType.DECLINED && leave.ApprovalStatus == (byte)StatusType.DECLINED) ||
                (leaveRequestsListDTO.Filter == SystemConstants.SICK_LEAVE_TYPE && leave.LeaveType == SystemConstants.SICK_LEAVE)
            ),
            IncludeExpressions = [x => x.Users]
        };

        PageListResponseDTO<Leave> pageListResponse = await _unitOfWork.LeaveRepository.GetAllAsync(pageListRequestEntity);

        List<LeaveRequestsAwaitingApprovalDTO> leaveRequestsListResponseDTOs = LeaveMappingProfile.ToGetLeavesForPrincipal(pageListResponse.Records);

        return new PageListResponseDTO<LeaveRequestsAwaitingApprovalDTO>(pageListResponse.PageIndex, pageListResponse.PageSize, pageListResponse.TotalRecords, leaveRequestsListResponseDTOs);
    }

    public async Task<PageListResponseDTO<GetContactPrincipalListDTO>> GetContactPrincipalList(PageListRequestDTO pageListRequestDTO)
    {
        PageListRequestEntity<ContactPrincipal> pageListRequestEntity = new()
        {
            PageIndex = pageListRequestDTO.PageIndex,
            PageSize = pageListRequestDTO.PageSize,
            SortColumn = SystemConstants.REQUEST_DATE_COLUMN,
            SortOrder = SystemConstants.DESCENDING,
            Predicate = contactPrincipal => pageListRequestDTO.Filter == (int)StatusType.ALL ||
                (pageListRequestDTO.Filter == (int)ContactTypes.Harassment && contactPrincipal.Type == (byte)ContactTypes.Harassment) ||
                (pageListRequestDTO.Filter == (int)ContactTypes.Awareness && contactPrincipal.Type == (byte)ContactTypes.Awareness) ||
                (pageListRequestDTO.Filter == (int)ContactTypes.Notice && contactPrincipal.Type == (byte)ContactTypes.Notice) ||
                (pageListRequestDTO.Filter == (int)ContactTypes.ExternalHelp && contactPrincipal.Type == (byte)ContactTypes.ExternalHelp) ||
                (pageListRequestDTO.Filter == (int)ContactTypes.Other && contactPrincipal.Type == (byte)ContactTypes.Other),
            IncludeExpressions = [x => x.Users, x => x.ContactOfType, x => x.Users.UserRoles]
        };

        PageListResponseDTO<ContactPrincipal> pageListResponse = await _unitOfWork.ContactPrincipalRepository.GetAllAsync(pageListRequestEntity);

        List<GetContactPrincipalListDTO> getContactPrincipalListDTO = ContactPrincipalMappingProfile.ToGetContactPrincipalList(pageListResponse.Records);

        return new PageListResponseDTO<GetContactPrincipalListDTO>(pageListResponse.PageIndex, pageListResponse.PageSize, pageListResponse.TotalRecords, getContactPrincipalListDTO);
    }

    public async Task PostContactPrincipalResponse(ContactPrincipalResponseDTO contactPrincipalResponseDTO)
    {
        ContactPrincipal? contactPrincipal = await _unitOfWork.ContactPrincipalRepository.GetAsync(cp => cp.Id == contactPrincipalResponseDTO.ContactPrincipalId, [x => x.Users]) ?? throw new CustomException(StatusCodes.Status422UnprocessableEntity, ErrorMessage.CONTACT_REQUEST_NOT_FOUND);

        ContactPrincipalMappingProfile.ToPostPrincipalResponse(contactPrincipal, contactPrincipalResponseDTO);

        await _unitOfWork.ContactPrincipalRepository.UpdateAsync(contactPrincipal);
        await _unitOfWork.SaveAsync();

        MailDTO mailDto = new()
        {
            ToEmail = contactPrincipal.Users.Email,
            Subject = EmailConstants.CONTACT_PRINCIPAL_RESPONSE,
            Body = MailBodyUtil.PostContactPrincipalResponse($"{contactPrincipal.Users.FirstName} {contactPrincipal.Users.LastName}", contactPrincipal.Subject, contactPrincipalResponseDTO.ResponseMessage, _environment.WebRootPath)
        };
        await _mailService.SendMailAsync(mailDto);
    }

    public async Task UpsertCourseChapters(AddCourseDTO addCourseDto)
    {
        ClassSubject classSubject = await _unitOfWork.ClassSubjectRepository.GetFirstOrDefaultAsync(x => x.Id == addCourseDto.ClassSubjectId) ?? throw new CustomException(StatusCodes.Status422UnprocessableEntity, message: ErrorMessage.CLASS_SUBJECT_NOT_FOUND);

        if (addCourseDto.AddChaptersDTO != null && addCourseDto.AddChaptersDTO.Any())
        {
            List<Course>? existingCourses = await _unitOfWork.CourseRepository
                .GetAllAsync(course => addCourseDto.AddChaptersDTO.Select(chapter => chapter.CourseId).Contains(course.Id));

            List<Course> courses = addCourseDto.AddChaptersDTO.ToCourseList(addCourseDto.ClassSubjectId, existingCourses);

            await _unitOfWork.CourseRepository.AddRangeAsync(courses.Where(course => course.Id == 0));
            await _unitOfWork.CourseRepository.UpdateRangeAsync(courses.Where(course => course.Id != 0));
            await _unitOfWork.SaveAsync();
        }
    }

    public async Task<List<GetCoursesForClassSubjectDTO>> GetAllChapetrsForClassSubject(int classSubjectId)
    {
        List<Course> courses = await _unitOfWork.CourseRepository.GetListAsync(predicate: x => x.ClassSubjectId == classSubjectId, includes: [x => x.ClassSubjects, x => x.ClassSubjects.Subjects, x => x.ClassSubjects.Classes]);

        List<GetCoursesForClassSubjectDTO> getCoursesForClassSubjectDTOs = courses.ToGetAllCourseForClassSubjects();

        return getCoursesForClassSubjectDTOs;
    }

    #endregion HTTP_Methods
}
