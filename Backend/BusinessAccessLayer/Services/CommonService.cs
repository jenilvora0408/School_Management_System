using System.Linq.Expressions;
using BusinessAccessLayer.Interface;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs.Common;

namespace BusinessAccessLayer.Services;

public class CommonService : ICommonService
{
    #region Constructor

    public readonly IUnitOfWork _unitOfWork;
    public CommonService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion Constructor

    #region Http_Methods

    public async Task<User?> GetUserByEmail(string email)
    {
        User? user = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(user => user.Email == email);
        return user;
    }

    public async Task<CommonEntityListResponseDTO> GetEntityList()
    {
        CommonEntityListResponseDTO commonEntityListResponse = new();

        //Get List of Genders
        Expression<Func<Gender, bool>> allGenderRecordsPredicate = x => true;
        List<Gender> gendersList = await _unitOfWork.GenderRepository.GetAllAsync(allGenderRecordsPredicate);

        commonEntityListResponse.ListOfGenders = new List<GenericEntityResponseDTO>();
        foreach (Gender gender in gendersList)
        {
            ((List<GenericEntityResponseDTO>)commonEntityListResponse.ListOfGenders).Add(new GenericEntityResponseDTO
            {
                Id = gender.Id,
                Title = gender.Title
            });
        }

        //Get List of Blood Groups
        Expression<Func<BloodGroup, bool>> allBloodGroupRecordsPredicate = x => true;
        List<BloodGroup> bloodGroupList = await _unitOfWork.BloodGroupRepository.GetAllAsync(allBloodGroupRecordsPredicate);

        commonEntityListResponse.ListOfBloodGroups = new List<GenericEntityResponseDTO>();
        foreach (BloodGroup bloodGroup in bloodGroupList)
        {
            ((List<GenericEntityResponseDTO>)commonEntityListResponse.ListOfBloodGroups).Add(new GenericEntityResponseDTO
            {
                Id = bloodGroup.Id,
                Title = bloodGroup.Title
            });
        }

        //Get List of Classes
        Expression<Func<Class, bool>> allClassesRecordsPredicate = x => true;
        List<Class> classesList = await _unitOfWork.ClassRepository.GetAllAsync(allClassesRecordsPredicate);

        commonEntityListResponse.ListOfClasses = new List<GenericEntityResponseDTO>();
        foreach (Class classes in classesList)
        {
            ((List<GenericEntityResponseDTO>)commonEntityListResponse.ListOfClasses).Add(new GenericEntityResponseDTO
            {
                Id = (byte)classes.Id,
                Title = classes.ClassName
            });
        }

        //Get List of Mediums
        Expression<Func<Medium, bool>> allMediumRecordsPredicate = x => true;
        List<Medium> mediumsList = await _unitOfWork.MediumRepository.GetAllAsync(allMediumRecordsPredicate);

        commonEntityListResponse.ListOfMediums = new List<GenericEntityResponseDTO>();
        foreach (Medium medium in mediumsList)
        {
            ((List<GenericEntityResponseDTO>)commonEntityListResponse.ListOfMediums).Add(new GenericEntityResponseDTO
            {
                Id = medium.Id,
                Title = medium.Title
            });
        }

        return commonEntityListResponse;
    }


    #endregion Http_Methods
}

