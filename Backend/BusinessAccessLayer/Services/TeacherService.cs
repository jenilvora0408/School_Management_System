using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using Common.Utils;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs;
using Entities.DTOs.Common;
using Entities.DTOs.Response;
using Entities.ExtensionMethods.MappingProfiles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using static Common.Constants.MessageConstants;
using static Common.Enums.SystemEnum;

namespace BusinessAccessLayer.Services;

public class TeacherService(IUnitOfWork unitOfWork, ICommonService commonService, IHostingEnvironment environment, IMailService mailService) : ITeacherService
{
    #region Constructor

    public readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMailService _mailService = mailService;
    private readonly ICommonService _commonService = commonService;
    private readonly IHostingEnvironment _environment = environment;

    #endregion Constructor

    #region HTTP_Methods

    public async Task<ViewAdmitRequestDTO> GetAdmitRequest(long id)
    {
        AdmitRequest request = await _unitOfWork.AdmitRequestRepository.GetAsync(request => request.Id == id, [x => x.Classes, x => x.Mediums, x => x.Genders, x => x.BloodGroups, x => x.AdmitRequestRoles, x => x.ApprovedByUser, x => x.DeclinedByUser, x => x.BlockedByUser]) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.ADMIT_REQUEST_NOT_FOUND);

        ViewAdmitRequestDTO viewAdmitRequestDTO = AdmitRequestMappingProfile.ToGetAdmitRequest(request);

        return viewAdmitRequestDTO;
    }

    public async Task CreateLeaveRequest(LeaveRequestDTO leaveRequestDTO)
    {
        User? user = await _commonService.GetUserById(leaveRequestDTO.LeaveRequestorId) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.USER_NOT_FOUND);

        byte approvalFromUserId = user.RoleId;

        if (user.RoleId == 2)
        {
            User? principalUser = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(user => user.RoleId == Convert.ToByte(1)) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.USER_NOT_FOUND);

            approvalFromUserId = principalUser.RoleId;
        }

        else if (user.RoleId == 2)
        {
            User? teacherUser = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(user => user.RoleId == Convert.ToByte(2)) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.USER_NOT_FOUND);

            approvalFromUserId = teacherUser.RoleId;
        }


        Leave leave = LeaveMappingProfile.ToCreateTeacherLeaveRequest(leaveRequestDTO, approvalFromUserId);

        await _unitOfWork.LeaveRepository.AddAsync(leave);

        await _unitOfWork.SaveAsync();
    }

    public async Task<PageListResponseDTO<LeaveRequestsListResponseDTO>> GetAllLeaveRequest(LeaveRequestsListDTO leaveRequestsListDTO)
    {
        PageListRequestEntity<Leave> pageListRequestEntity = new()
        {
            PageIndex = leaveRequestsListDTO.PageIndex,
            PageSize = leaveRequestsListDTO.PageSize,
            SortColumn = !string.IsNullOrEmpty(leaveRequestsListDTO.SortColumn) ? leaveRequestsListDTO.SortColumn : null!,
            SortOrder = leaveRequestsListDTO.SortOrder,
            Predicate = leave =>
                leave.UserId == leaveRequestsListDTO.UserId && (
                leaveRequestsListDTO.Filter == 0 ||
                (leaveRequestsListDTO.Filter == (int)StatusType.PENDING && leave.ApprovalStatus == (byte)StatusType.PENDING) ||
                (leaveRequestsListDTO.Filter == (int)StatusType.APPROVED && leave.ApprovalStatus == (byte)StatusType.APPROVED) ||
                (leaveRequestsListDTO.Filter == (int)StatusType.DECLINED && leave.ApprovalStatus == (byte)StatusType.DECLINED) ||
                (leaveRequestsListDTO.Filter == SystemConstants.SICK_LEAVE_TYPE && leave.LeaveType == SystemConstants.SICK_LEAVE)
            ),
            Selects = responseInfo => new Leave()
            {
                Id = responseInfo.Id,
                UserId = responseInfo.UserId,
                ApprovalStatus = responseInfo.ApprovalStatus,
                ReasonForLeave = responseInfo.ReasonForLeave,
                StartDate = responseInfo.StartDate,
                EndDate = responseInfo.EndDate,
                LeaveDuration = responseInfo.LeaveDuration,
                LeaveType = responseInfo.LeaveType,
                Users = responseInfo.Users,
                AlternatePhoneNumber = responseInfo.AlternatePhoneNumber
            }
        };

        PageListResponseDTO<Leave> pageListResponse = await _unitOfWork.LeaveRepository.GetAllAsync(pageListRequestEntity);

        List<LeaveRequestsListResponseDTO> leaveRequestsListResponseDTOs = pageListResponse.Records.Select(leaves => new LeaveRequestsListResponseDTO
        {
            Id = leaves.Id,
            ReasonForLeave = leaves.ReasonForLeave,
            StartDate = leaves.StartDate,
            EndDate = leaves.EndDate,
            LeaveDuration = leaves.LeaveDuration,
            LeaveType = leaves.LeaveType,
            ApprovalStatus = leaves.ApprovalStatus,
            PhoneNumber = leaves.Users.PhoneNumber ?? string.Empty,
            AlternatePhoneNumber = leaves.AlternatePhoneNumber
        }).ToList();

        return new PageListResponseDTO<LeaveRequestsListResponseDTO>(pageListResponse.PageIndex, pageListResponse.PageSize, pageListResponse.TotalRecords, leaveRequestsListResponseDTOs);
    }

    public async Task AdmitRequestApproval(AdmitRequestApprovalDTO admitRequestApprovalDTO)
    {
        AdmitRequest? admitRequest = await _unitOfWork.AdmitRequestRepository
            .GetFirstOrDefaultAsync(a => a.Id == admitRequestApprovalDTO.AdmitRequestId)
            ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.ADMIT_REQUEST_NOT_FOUND);

        admitRequestApprovalDTO.ToApproveAdmitRequest(admitRequest);

        await _unitOfWork.AdmitRequestRepository.UpdateAsync(admitRequest);
        await _unitOfWork.SaveAsync();

        if (admitRequestApprovalDTO.ApprovedBy != 0 && admitRequestApprovalDTO.ApprovedBy != null)
        {
            await HandleApprovedRequest(admitRequest, admitRequestApprovalDTO);
        }
        else if (admitRequestApprovalDTO.DeclinedBy != 0 && admitRequestApprovalDTO.DeclinedBy != null)
        {
            await SendAdmitRequestMail(admitRequest.Email, EmailConstants.DECLINE_ADMIT_REQUEST,
                MailBodyUtil.DeclineAdmitRequest($"{admitRequest.FirstName} {admitRequest.LastName}", _environment.WebRootPath));
        }
        else
        {
            await SendAdmitRequestMail(admitRequest.Email, EmailConstants.BLOCK_ADMIT_REQUEST,
                MailBodyUtil.BlockAdmitRequest($"{admitRequest.FirstName} {admitRequest.LastName}", admitRequest.ReasonForBlock ?? string.Empty, _environment.WebRootPath));
        }
    }
    public async Task<LeavesCountDTO> GetLeavesCount(long userId)
    {
        IList<Leave> allLeaves = await _unitOfWork.LeaveRepository.GetAllAsync(leave => leave.UserId == userId);

        int totalLeavesCount = allLeaves.Count;
        int pendingRequestsCount = allLeaves.Count(leave => leave.ApprovalStatus == (byte)StatusType.PENDING);
        int approvedLeavesCount = allLeaves.Count(leave => leave.ApprovalStatus == (byte)StatusType.APPROVED);
        int declinedLeavesCount = allLeaves.Count(leave => leave.ApprovalStatus == (byte)StatusType.DECLINED);
        int sickLeavesCount = allLeaves.Count(leave => leave.LeaveType == SystemConstants.SICK_LEAVE);

        int remainingLeavesCount = 0;

        LeavesCountDTO leavesCountDTO = LeaveMappingProfile.ToGetLeavesCount(
            totalLeavesCount,
            pendingRequestsCount,
            approvedLeavesCount,
            declinedLeavesCount,
            remainingLeavesCount,
            sickLeavesCount
        );

        return leavesCountDTO;
    }

    #endregion HTTP_Methods

    #region Helper_Methods

    public static string GeneratePassword()
    {
        const int length = SystemConstants.PASSWORD_LENGTH;
        const string lowercase = SystemConstants.LOWERCASE_ALPHABETS;
        const string uppercase = SystemConstants.UPPERCASE_ALPHABETS;
        const string digits = SystemConstants.DIGITS;
        const string specialChars = SystemConstants.SPECIAL_CHARS;

        Random random = new();

        string password = new string(new char[]
        {
        uppercase[random.Next(uppercase.Length)],
        digits[random.Next(digits.Length)],
        specialChars[random.Next(specialChars.Length)],
        lowercase[random.Next(lowercase.Length)]
        });

        string allChars = lowercase + uppercase + digits + specialChars;
        password += new string(Enumerable.Repeat(allChars, length - 4)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        password = new string(password.OrderBy(c => random.Next()).ToArray());

        return password;
    }

    private async Task SendAdmitRequestMail(string email, string subject, string body)
    {
        MailDTO mailDto = new()
        {
            ToEmail = email,
            Subject = subject,
            Body = body
        };

        await _mailService.SendMailAsync(mailDto);
    }

    private async Task HandleApprovedRequest(AdmitRequest admitRequest, AdmitRequestApprovalDTO admitRequestApprovalDTO)
    {
        GenerateCredentialsDTO generateCredentialsDTO = new()
        {
            UserName = admitRequest.Email,
            Password = GeneratePassword()
        };

        string hashedPassword = PasswordUtil.HashPassword(generateCredentialsDTO.Password);

        User user = admitRequest.ToSaveAdmitRequestUser(hashedPassword);
        user.IsUserActive = true;
        user.IsUserDeleted = false;

        if (user.RoleId == (byte)UserRoleType.STUDENT)
        {
            Student student = admitRequest.ToAddStudents();
            await _unitOfWork.StudentRepository.AddAsync(student);
        }

        await _unitOfWork.UserRepository.AddAsync(user);
        await _unitOfWork.SaveAsync();

        await SendAdmitRequestMail(admitRequest.Email, EmailConstants.GENERATE_LOGIN_CREDENTIALS_SUBJECT, MailBodyUtil.SendCredentialsForLogin(
            $"{admitRequest.FirstName} {admitRequest.LastName}", generateCredentialsDTO.UserName, generateCredentialsDTO.Password, _environment.WebRootPath));
    }

    public async Task<SubjectTeacherInfoDTO> GetClassesForSubjectTeacher(long userId)
    {
        User? user = await _commonService.GetUserById(userId) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.USER_NOT_FOUND);

        Subject? subject = await _unitOfWork.SubjectRepository.GetAsync(sub => sub.SubjectTeacherId == userId, includes: [sub => sub.ClassSubjects]
        );

        if (subject == null || !subject.ClassSubjects.Any())
        {
            return user.ToEmptySubjectTeacherInfoDTO();
        }

        List<int>? classIds = subject.ClassSubjects.Select(cs => cs.ClassId).ToList();

        List<Class> classes = await _unitOfWork.ClassRepository.GetAllIncludeAsync(cls => classIds.Contains(cls.Id), includes: [cls => cls.ClassTeachers]);

        return subject.ToSubjectTeacherInfoDTO(user, classes);
    }

    public async Task<PageListResponseDTO<ClassSubjectChaptersPageListResponseDTO>>     GetAllClassSubjectChapters(ClassSubjectPageListRequestDTO classSubjectPageListRequestDTO)
    {
        Class? classData = await _unitOfWork.ClassRepository.GetFirstOrDefaultAsync(cs => cs.Id == classSubjectPageListRequestDTO.ClassId) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.CLASS_NOT_FOUND);

        Subject? subject = await _unitOfWork.SubjectRepository.GetFirstOrDefaultAsync(sub => sub.Id == classSubjectPageListRequestDTO.SubjectId) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.SUBJECT_NOT_FOUND);

        ClassSubject? classSubject = await _unitOfWork.ClassSubjectRepository.GetFirstOrDefaultAsync(cls => cls.ClassId == classSubjectPageListRequestDTO.ClassId && cls.SubjectId == classSubjectPageListRequestDTO.SubjectId) ?? throw new CustomException(StatusCodes.Status400BadRequest, ErrorMessage.CLASS_SUBJECT_INVALID_CREDENTIALS);

        PageListRequestEntity<Course> pageListRequestEntity = new()
        {
            PageIndex = classSubjectPageListRequestDTO.PageIndex,
            PageSize = classSubjectPageListRequestDTO.PageSize,
            SortColumn = !string.IsNullOrEmpty(classSubjectPageListRequestDTO.SortColumn) ? classSubjectPageListRequestDTO.SortColumn : null!,
            SortOrder = classSubjectPageListRequestDTO.SortOrder,
            Predicate = leave =>
                leave.ClassSubjectId == classSubject.Id && leave.ChapterName.ToLower().Contains(classSubjectPageListRequestDTO.SearchQuery.ToLower()),
        };

        PageListResponseDTO<Course> pageListResponse = await _unitOfWork.CourseRepository.GetAllAsync(pageListRequestEntity);

        List<ClassSubjectChaptersPageListResponseDTO> leaveRequestsListResponseDTOs = pageListResponse.Records.ToGetChaptersForClassSubject();

        return new PageListResponseDTO<ClassSubjectChaptersPageListResponseDTO>(pageListResponse.PageIndex, pageListResponse.PageSize, pageListResponse.TotalRecords, leaveRequestsListResponseDTOs);
    }

    public async Task<string> ManageChapterDocument(ManageChapterDocumentDTO manageChapterDocumentDTO)
    {
        string response = string.Empty;

        Course? course = await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(cs => cs.Id == manageChapterDocumentDTO.CourseId) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.CHAPTER_NOT_FOUND);

        if (manageChapterDocumentDTO.DocumentId == 0 && !string.IsNullOrWhiteSpace(manageChapterDocumentDTO.DocumentContent))
        {
            Document? existingDocument = await _unitOfWork.DocumentRepository.GetFirstOrDefaultAsync(doc => doc.CourseId == manageChapterDocumentDTO.CourseId);

            if (existingDocument != null)
                throw new CustomException(StatusCodes.Status422UnprocessableEntity, ErrorMessage.CHAPTER_DOCUMENT_ALREADY_PRESENT);

            Document newDocument = manageChapterDocumentDTO.ToDocument(course.Id);
            await _unitOfWork.DocumentRepository.AddAsync(newDocument);
            response = SuccessMessage.DOCUMENT_ADDED;
        }
        else
        {
            Document? document = await _unitOfWork.DocumentRepository.GetFirstOrDefaultAsync(doc => doc.Id == manageChapterDocumentDTO.DocumentId) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.DOCUMENT_NOT_FOUND);

            if (string.IsNullOrWhiteSpace(manageChapterDocumentDTO.DocumentContent))
            {
                await _unitOfWork.DocumentRepository.RemoveAsync(document);
                response = SuccessMessage.DOCUMENT_REMOVED;
            }
            else
            {
                document.UpdateFromDTO(manageChapterDocumentDTO);
                await _unitOfWork.DocumentRepository.UpdateAsync(document);
                response = SuccessMessage.DOCUMENT_UPDATED;
            }
        }

        await _unitOfWork.SaveAsync();
        return response;
    }

    public async Task<GetChapterDocumentDTO> GetChapterDocument(int courseId)
    {
        Course? course = await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(cs => cs.Id == courseId) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.CHAPTER_NOT_FOUND);

        Document? document = await _unitOfWork.DocumentRepository.GetFirstOrDefaultAsync(doc => doc.CourseId == courseId);

        if (document != null)
        {
            return document.ToGetDocument();
        }
        else
        {
            return new GetChapterDocumentDTO();
        }
    }

    #endregion Helper_Methods
}