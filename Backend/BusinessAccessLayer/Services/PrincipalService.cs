using BusinessAccessLayer.Interface;
using Common.Constants;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs;
using Entities.ExtensionMethods.MappingProfiles;
using Microsoft.AspNetCore.Hosting;
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
        Class request = ClassMappingProfile.ToUpsertClasses(classRequestDTO);
        await _unitOfWork.ClassRepository.UpdateAsync(request);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<SubjectsListResponseDTO>> GetSubjectsByClass(int classId)
    {
        List<ClassSubject> classSubjects = await _unitOfWork.ClassSubjectRepository.GetListAsync(predicate: x => x.ClassId == classId, includes: [x => x.Classes, x => x.Subjects, x => x.Subjects.SubjectTeacher]);

        List<SubjectsListResponseDTO> subjectsListResponseDTOs = ClassSubjectMappingProfile.ToClassSubjectListResponseDTOs(classSubjects);

        return subjectsListResponseDTOs;
    }

    public async Task<PageListResponseDTO<LeaveRequestsListResponseDTO>> GetAllLeaveRequest(PageListRequestDTO leaveRequestsListDTO)
    {
        PageListRequestEntity<Leave> pageListRequestEntity = new()
        {
            PageIndex = leaveRequestsListDTO.PageIndex,
            PageSize = leaveRequestsListDTO.PageSize,
            SortColumn = !string.IsNullOrEmpty(leaveRequestsListDTO.SortColumn) ? leaveRequestsListDTO.SortColumn : null!,
            SortOrder = leaveRequestsListDTO.SortOrder,
            Predicate = leave =>
                leave.ApprovalFromUserId == (long)UserRoleType.PRINCIPAL && (
                leaveRequestsListDTO.Filter == (int)StatusType.ALL ||
                (leaveRequestsListDTO.Filter == (int)StatusType.PENDING && leave.ApprovalStatus == (byte)StatusType.PENDING) ||
                (leaveRequestsListDTO.Filter == (int)StatusType.APPROVED && leave.ApprovalStatus == (byte)StatusType.APPROVED) ||
                (leaveRequestsListDTO.Filter == (int)StatusType.DECLINED && leave.ApprovalStatus == (byte)StatusType.DECLINED) ||
                (leaveRequestsListDTO.Filter == SystemConstants.SICK_LEAVE_TYPE && leave.LeaveType == SystemConstants.SICK_LEAVE)
            ),
        };

        PageListResponseDTO<Leave> pageListResponse = await _unitOfWork.LeaveRepository.GetAllAsync(pageListRequestEntity);

        List<LeaveRequestsListResponseDTO> leaveRequestsListResponseDTOs = LeaveMappingProfile.ToGetLeavesForPrincipal(pageListResponse.Records);

        return new PageListResponseDTO<LeaveRequestsListResponseDTO>(pageListResponse.PageIndex, pageListResponse.PageSize, pageListResponse.TotalRecords, leaveRequestsListResponseDTOs);

    }

    #endregion HTTP_Methods
}
