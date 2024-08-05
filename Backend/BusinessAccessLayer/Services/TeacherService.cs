using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs;
using Entities.DTOs.Response;
using Entities.ExtensionMethods.MappingProfiles;
using Microsoft.AspNetCore.Http;

namespace BusinessAccessLayer.Services;

public class TeacherService : ITeacherService
{
    #region Constructor

    public readonly IUnitOfWork _unitOfWork;
    private readonly ICommonService _commonService;
    public TeacherService(IUnitOfWork unitOfWork, ICommonService commonService)
    {
        _unitOfWork = unitOfWork;
        _commonService = commonService;
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
        AdmitRequest? admitRequest = await _unitOfWork.AdmitRequestRepository.GetFirstOrDefaultAsync(a => a.Id == admitRequestApprovalDTO.AdmitRequestId) ?? throw new CustomException(StatusCodes.Status404NotFound, MessageConstants.ErrorMessage.ADMIT_REQUEST_NOT_FOUND);

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