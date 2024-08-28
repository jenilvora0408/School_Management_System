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
        AdmitRequest request = await _unitOfWork.AdmitRequestRepository.GetAsync(request => request.Id == id, [x => x.Classes, x => x.Mediums, x => x.Genders, x => x.BloodGroups, x => x.AdmitRequestRoles, x => x.ApprovedByUser, x => x.DeclinedByUser, x => x.BlockedByUser]) ?? throw new CustomException(StatusCodes.Status404NotFound, MessageConstants.ErrorMessage.ADMIT_REQUEST_NOT_FOUND);

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
                (leaveRequestsListDTO.Filter == 1 && leave.ApprovalStatus == 1) ||
                (leaveRequestsListDTO.Filter == 2 && leave.ApprovalStatus == 2) ||
                (leaveRequestsListDTO.Filter == 3 && leave.ApprovalStatus == 3) ||
                (leaveRequestsListDTO.Filter == 8 && leave.LeaveType == SystemConstants.SICK_LEAVE)
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
        AdmitRequest? admitRequest = await _unitOfWork.AdmitRequestRepository.GetFirstOrDefaultAsync(a => a.Id == admitRequestApprovalDTO.AdmitRequestId) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.ADMIT_REQUEST_NOT_FOUND);

        AdmitRequestMappingProfile.ToApproveAdmitRequest(admitRequestApprovalDTO, admitRequest);

        await _unitOfWork.AdmitRequestRepository.UpdateAsync(admitRequest);
        await _unitOfWork.SaveAsync();

        if (admitRequestApprovalDTO.ApprovedBy != 0 || admitRequestApprovalDTO.ApprovedBy != null)
        {
            GenerateCredentialsDTO generateCredentialsDTO = new()
            {
                UserName = admitRequest.Email,
                Password = GeneratePassword()
            };

            string password = PasswordUtil.HashPassword(generateCredentialsDTO.Password);

            User user = new();
            user = UserMappingProfile.ToSaveAdmitRequestUser(admitRequest, password);

            if (user.RoleId == Convert.ToByte(3))
            {
                Student student = new();
                student = StudentMappingProfile.ToAddStudents(admitRequest);
                await _unitOfWork.StudentRepository.AddAsync(student);
            };

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveAsync();

            MailDTO mailDto = new()
            {
                ToEmail = admitRequest.Email,
                Subject = EmailConstants.GENERATE_LOGIN_CREDENTIALS_SUBJECT,
                Body = MailBodyUtil.SendCredentialsForLogin(admitRequest.FirstName + " " + admitRequest.LastName, generateCredentialsDTO.UserName, generateCredentialsDTO.Password, _environment.WebRootPath)
            };

            await _mailService.SendMailAsync(mailDto);
        }
    }

    public async Task<LeavesCountDTO> GetLeavesCount(long userId)
    {
        IList<Leave> allLeaves = await _unitOfWork.LeaveRepository.GetAllAsync(leave => leave.UserId == userId);

        int totalLeavesCount = allLeaves.Count;
        int pendingRequestsCount = allLeaves.Count(leave => leave.ApprovalStatus == Convert.ToByte(1));
        int approvedLeavesCount = allLeaves.Count(leave => leave.ApprovalStatus == Convert.ToByte(2));
        int declinedLeavesCount = allLeaves.Count(leave => leave.ApprovalStatus == Convert.ToByte(3));
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
        const int length = 8;
        const string lowercase = "abcdefghijklmnopqrstuvwxyz";
        const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string digits = "0123456789";
        const string specialChars = "$@$!%*?&";

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


    #endregion Helper_Methods
}