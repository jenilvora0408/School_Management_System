using System.Linq.Expressions;
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
public class CommonService(IUnitOfWork unitOfWork, IHostingEnvironment environment, IMailService mailService) : ICommonService
{
    #region Constructor

    public readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMailService _mailService = mailService;
    private readonly IHostingEnvironment _environment = environment;

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
        IEnumerable<User>? users = await _unitOfWork.UserRepository.GetListAsync(predicate: x => x.RoleId == (byte)UserRoleType.TEACHER, orderBy: c => c.FirstName);

        IEnumerable<TeachersListResponseDTO> response = UserMappingProfile.ToTeachersListResponseDTOs(users);

        return response;
    }

    public async Task<IEnumerable<SubjectsListResponseDTO>> GetAllSubjects()
    {
        IEnumerable<Subject> subjects = await _unitOfWork.SubjectRepository.GetListAsync(orderBy: c => c.SubjectName, includes: [x => x.SubjectTeacher]);

        IEnumerable<SubjectsListResponseDTO> response = SubjectMappingProfile.ToGetAllSubjects(subjects);

        return response;
    }

    public async Task<GetUserProfileDTO> GetUserProfile(long userId)
    {
        User user = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(user => user.Id == userId) ?? throw new CustomException(StatusCodes.Status404NotFound, MessageConstants.ErrorMessage.USER_NOT_FOUND);

        GetUserProfileDTO getUserProfileDTO = UserMappingProfile.ToGetUserProfile(user);

        return getUserProfileDTO;
    }

    public async Task UpdateUserProfile(GetUserProfileDTO getUserProfileDTO)
    {
        User user = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(user => user.Id == getUserProfileDTO.UserId) ?? throw new CustomException(StatusCodes.Status404NotFound, MessageConstants.ErrorMessage.USER_NOT_FOUND);

        UserMappingProfile.ToUpdateUserProfile(getUserProfileDTO, user);

        await _unitOfWork.UserRepository.UpdateAsync(user);
        await _unitOfWork.SaveAsync();
    }

    public async Task<string> LeaveRequestApproval(LeavesApprovalDTO leavesApprovalDTO)
    {
        Leave? leave = await _unitOfWork.LeaveRepository.GetFirstOrDefaultAsync(leave => leave.Id == leavesApprovalDTO.LeaveId) ?? throw new CustomException(StatusCodes.Status422UnprocessableEntity, MessageConstants.ErrorMessage.LEAVE_REQUEST_NOT_FOUND);

        LeaveMappingProfile.ToApproveOrDeclineLeave(leavesApprovalDTO, leave);

        await _unitOfWork.LeaveRepository.UpdateAsync(leave);
        await _unitOfWork.SaveAsync();

        string message = leavesApprovalDTO.ApprovalStatus == (byte)StatusType.APPROVED ? MessageConstants.SuccessMessage.LEAVE_APPROVED : MessageConstants.SuccessMessage.LEAVE_DECLINED;

        return message;
    }

    public async Task ContactPrincipalRequest(ContactPrincipalDTO contactPrincipalDTO)
    {
        User? user = await GetUserById(contactPrincipalDTO.UserId) ?? throw new CustomException(StatusCodes.Status422UnprocessableEntity, MessageConstants.ErrorMessage.USER_NOT_FOUND);

        ContactPrincipal contactPrincipal = ContactPrincipalMappingProfile.ToContactPrincipal(contactPrincipalDTO);

        await _unitOfWork.ContactPrincipalRepository.AddAsync(contactPrincipal);
        await _unitOfWork.SaveAsync();

        List<Document> documents = [];

        if (contactPrincipalDTO.DocumentContent != null && contactPrincipalDTO.DocumentContent.Any())
        {
            documents = DocumentMappingProfile.ToDocumentList(contactPrincipalDTO.DocumentContent, contactPrincipal.Id);
        }

        await _unitOfWork.DocumentRepository.AddRangeAsync(documents);
        await _unitOfWork.SaveAsync();

        User? users = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(user => user.RoleId == 1);

        MailDTO mailDto = new()
        {
            ToEmail = users.Email,
            Subject = EmailConstants.CONTACT_PRINCIPAL_RESPONSE,
            Body = MailBodyUtil.CreateContactPrincipalRequest($"{users.FirstName} {users.LastName}", $"{contactPrincipal.Users.FirstName} {contactPrincipal.Users.LastName}", contactPrincipal.Subject, _environment.WebRootPath)
        };
        await _mailService.SendMailAsync(mailDto);
    }

    public async Task<List<GetContactPrincipalListDTO>> GetOwnContactPrincipalRequests(long userId)
    {
        User? user = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(x => x.Id == userId) ?? throw new CustomException(StatusCodes.Status422UnprocessableEntity, MessageConstants.ErrorMessage.USER_NOT_FOUND);

        List<ContactPrincipal>? contactPrincipalRequests = await _unitOfWork.ContactPrincipalRepository.GetListAsync(predicate: x => x.UserId == userId, includes: [x => x.ContactOfType]);

        List<GetContactPrincipalListDTO> response = ContactPrincipalMappingProfile.ToViewOwnContactRequest(contactPrincipalRequests);

        return response;
    }

    public async Task<List<string>> GetContactPrincipalDocuments(int contactPrincipalId)
    {
        IEnumerable<Document> documents = await _unitOfWork.DocumentRepository.GetAllAsync(doc => doc.ContactPrincipalId == contactPrincipalId);
        List<string> documentContent = [];
        if (documents.Any())
        {
            foreach (Document item in documents) 
            {
                documentContent.Add(item.DocumentContent);
            }
        }
        return documentContent;
    }

    #endregion Http_Methods
}