using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs;
using Entities.ExtensionMethods.MappingProfiles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
