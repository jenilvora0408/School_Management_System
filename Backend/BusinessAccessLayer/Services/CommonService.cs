using System.Linq.Expressions;
using BusinessAccessLayer.Interface;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs;
using Entities.ExtensionMethods.MappingProfiles;

namespace BusinessAccessLayer.Services;

public class CommonService(IUnitOfWork unitOfWork) : ICommonService
{
    #region Constructor

    public readonly IUnitOfWork _unitOfWork = unitOfWork;

    #endregion Constructor

    #region Http_Methods

    public async Task<User?> GetUserByEmail(string email)
    {
        User? user = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(user => user.Email == email);
        return user;
    }

    public async Task<User?> GetUserById(long id)
    {
        User? user = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(user => user.Id == id);
        return user;
    }

    public async Task<CommonEntityListResponseDTO> GetEntityList()
    {
        CommonEntityListResponseDTO commonEntityListResponse = new();

        //Get List of Genders
        Expression<Func<Gender, bool>> allGenderRecordsPredicate = x => true;
        List<Gender> gendersList = await _unitOfWork.GenderRepository.GetAllAsync(allGenderRecordsPredicate);

        commonEntityListResponse.ListOfGenders = GenderMappingProfile.ToGenericEntityResponseDTOs(gendersList);

        //Get List of Blood Groups
        Expression<Func<BloodGroup, bool>> allBloodGroupRecordsPredicate = x => true;
        List<BloodGroup> bloodGroupList = await _unitOfWork.BloodGroupRepository.GetAllAsync(allBloodGroupRecordsPredicate);

        commonEntityListResponse.ListOfBloodGroups = BloodGroupMappingProfile.ToGenericEntityResponseDTOs(bloodGroupList);

        //Get List of Classes
        Expression<Func<Class, bool>> allClassesRecordsPredicate = x => true;
        List<Class> classesList = await _unitOfWork.ClassRepository.GetAllAsync(allClassesRecordsPredicate);

        commonEntityListResponse.ListOfClasses = ClassMappingProfile.ToGenericEntityResponseDTOs(classesList);

        //Get List of Mediums
        Expression<Func<Medium, bool>> allMediumRecordsPredicate = x => true;
        List<Medium> mediumsList = await _unitOfWork.MediumRepository.GetAllAsync(allMediumRecordsPredicate);

        commonEntityListResponse.ListOfMediums = MediumMappingProfile.ToGenericEntityResponseDTOs(mediumsList);

        return commonEntityListResponse;
    }

    public async Task<PageListResponseDTO<AdmitRequestListResponseDTO>> GetAdmitRequestsList(PageListRequestDTO admitRequestList)
    {
        PageListRequestEntity<AdmitRequest> pageListRequestEntity = new()
        {
            PageIndex = admitRequestList.PageIndex,
            PageSize = admitRequestList.PageSize,
            SortColumn = !string.IsNullOrEmpty(admitRequestList.SortColumn) ? admitRequestList.SortColumn : null!,
            SortOrder = admitRequestList.SortOrder,
            Predicate = admitRequest => admitRequest.ApprovalStatus == admitRequestList.Filter && (admitRequest.FirstName.Trim().ToLower().Contains(admitRequestList.SearchQuery.Trim().ToLower()) || admitRequest.LastName.Trim().ToLower().Contains(admitRequestList.SearchQuery.Trim().ToLower())),
            Selects = responseInfo => new AdmitRequest()
            {
                Id = responseInfo.Id,
                FirstName = responseInfo.FirstName,
                LastName = responseInfo.LastName,
                Email = responseInfo.Email,
                PhoneNumber = responseInfo.PhoneNumber,
                Classes = responseInfo.Classes,
                AdmitRequestRoles = responseInfo.AdmitRequestRoles,
                ApprovalStatus = responseInfo.ApprovalStatus
            }
        };

        PageListResponseDTO<AdmitRequest> pageListResponse = await _unitOfWork.AdmitRequestRepository.GetAllAsync(pageListRequestEntity);

        List<AdmitRequestListResponseDTO> admitRequestListResponseDTOs = pageListResponse.Records.Select(admitRequest => new AdmitRequestListResponseDTO
        {
            Id = admitRequest.Id,
            Name = $"{admitRequest.FirstName} {admitRequest.LastName}",
            Email = admitRequest.Email,
            PhoneNumber = admitRequest.PhoneNumber,
            ClassName = admitRequest.Classes != null ? admitRequest.Classes.ClassName : null,
            RequestedRole = admitRequest.AdmitRequestRoles.Title,
            ApprovalStatus = admitRequest.ApprovalStatus
        }).ToList();

        return new PageListResponseDTO<AdmitRequestListResponseDTO>(pageListResponse.PageIndex, pageListResponse.PageSize, pageListResponse.TotalRecords, admitRequestListResponseDTOs);
    }

    public async Task<List<ClassesListResponseDTO>> GetAllClasses()
    {
        List<Class>? classes = await _unitOfWork.ClassRepository.GetListAsync(includes:
        [
            c => c.ClassTeachers
        ], orderBy: c => c.Id);

        List<ClassesListResponseDTO> classesListResponseDTO = ClassMappingProfile.ToClassesListResponseDTOs(classes);

        return classesListResponseDTO;
    }

    public async Task<IEnumerable<TeachersListResponseDTO>> GetAllTeachers()
    {
        IEnumerable<User>? users = await _unitOfWork.UserRepository.GetListAsync(predicate: x => x.RoleId == Convert.ToByte(2), orderBy: c => c.FirstName);

        IEnumerable<TeachersListResponseDTO> response = UserMappingProfile.ToTeachersListResponseDTOs(users);

        return response;
    }

    #endregion Http_Methods
}