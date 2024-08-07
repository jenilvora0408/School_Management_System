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

public class TeacherService : ITeacherService
{
    #region Constructor

    public readonly IUnitOfWork _unitOfWork;
    private readonly IMailService _mailService;
    private readonly ICommonService _commonService;
    private readonly IHostingEnvironment _environment;
    public TeacherService(IUnitOfWork unitOfWork, ICommonService commonService, IHostingEnvironment environment, IMailService mailService)
    {
        _unitOfWork = unitOfWork;
        _commonService = commonService;
        _environment = environment;
        _mailService = mailService;
    }

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
        User? user = await _commonService.GetUserById(leaveRequestDTO.LeaveRequestorId) ?? throw new CustomException(StatusCodes.Status404NotFound, MessageConstants.ErrorMessage.USER_NOT_FOUND);

        Leave leave = LeaveMappingProfile.ToCreateTeacherLeaveRequest(leaveRequestDTO);

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
            Predicate = leave => leave.UserId == leaveRequestsListDTO.UserId && leave.ApprovalStatus == leaveRequestsListDTO.Filter && (leave.Users.FirstName.Trim().ToLower().Contains(leaveRequestsListDTO.SearchQuery.Trim().ToLower()) || leave.Users.LastName.Trim().ToLower().Contains(leaveRequestsListDTO.SearchQuery.Trim().ToLower()) || leave.ReasonForLeave.Trim().ToLower().Contains(leaveRequestsListDTO.SearchQuery.Trim().ToLower())),
            Selects = responseInfo => new Leave()
            {
                Id = responseInfo.Id,
                UserId = responseInfo.UserId,
                ApprovalStatus = responseInfo.ApprovalStatus,
                ReasonForLeave = responseInfo.ReasonForLeave,
                StartDate = responseInfo.StartDate,
                EndDate = responseInfo.EndDate,
                LeaveStartType = responseInfo.LeaveStartType,
                LeaveEndType = responseInfo.LeaveEndType,
                LeaveDuration = responseInfo.LeaveDuration,
                LeaveType = responseInfo.LeaveType,
                Users = responseInfo.Users
            }
        };

        PageListResponseDTO<Leave> pageListResponse = await _unitOfWork.LeaveRepository.GetAllAsync(pageListRequestEntity);

        List<LeaveRequestsListResponseDTO> leaveRequestsListResponseDTOs = pageListResponse.Records.Select(leaves => new LeaveRequestsListResponseDTO
        {
            Id = leaves.Id,
            ReasonForLeave = leaves.ReasonForLeave,
            StartDate = leaves.StartDate,
            EndDate = leaves.EndDate,
            LeaveStartType = leaves.LeaveStartType,
            LeaveEndType = leaves.LeaveEndType,
            LeaveDuration = leaves.LeaveDuration,
            LeaveType = leaves.LeaveType,
            ApprovalStatus = leaves.ApprovalStatus
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

    #endregion HTTP_Methods

    #region Helper_Methods

    public string GeneratePassword()
    {
        int length = SystemConstants.PASSWORD_LENGTH;
        string chars = SystemConstants.PASSWORD_CHAR;
        Random random = new();
        string password = new(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());

        return password;
    }

    #endregion Helper_Methods
}