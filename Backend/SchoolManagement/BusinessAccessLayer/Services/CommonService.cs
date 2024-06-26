using AutoMapper;
using BusinessAccessLayer.Interface;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs.Common;
using Microsoft.Extensions.Hosting;
using System.Linq.Expressions;

namespace BusinessAccessLayer.Services
{
    public class CommonService : ICommonService
    {
        #region Constructor

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _env;
        public CommonService(IUnitOfWork unitOfWork, IMapper mapper, IHostEnvironment env)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _env = env;
        }

        #endregion

        #region Methods

        public async Task<CommonEntityListResponseDto> GetEntityList()
        {
            CommonEntityListResponseDto commonEntityListResponse = new();

            //Get List of Genders
            Expression<Func<Gender, bool>> allGenderRecordsPredicate = x => true;
            List<Gender> gendersList = await _unitOfWork.GenderRepository.GetAllAsync(allGenderRecordsPredicate);

            commonEntityListResponse.ListOfGenders = new List<GenericEntityResponseDto>();
            foreach (Gender gender in gendersList)
            {
                ((List<GenericEntityResponseDto>)commonEntityListResponse.ListOfGenders).Add(new GenericEntityResponseDto
                {
                    Id = gender.Id,
                    Title = gender.Title
                });
            }

            //Get List of Blood Groups
            Expression<Func<BloodGroup, bool>> allBloodGroupRecordsPredicate = x => true;
            List<BloodGroup> bloodGroupList = await _unitOfWork.BloodGroupRepository.GetAllAsync(allBloodGroupRecordsPredicate);

            commonEntityListResponse.ListOfBloodGroups = new List<GenericEntityResponseDto>();
            foreach (BloodGroup bloodGroup in bloodGroupList)
            {
                ((List<GenericEntityResponseDto>)commonEntityListResponse.ListOfBloodGroups).Add(new GenericEntityResponseDto
                {
                    Id = bloodGroup.Id,
                    Title = bloodGroup.Title
                });
            }

            //Get List of User Roles
            Expression<Func<UserRole, bool>> allUserRoleRecordsPredicate = x => true;
            List<UserRole> userRolesList = await _unitOfWork.UserRoleRepository.GetAllAsync(allUserRoleRecordsPredicate);

            commonEntityListResponse.ListOfUserRoles = new List<GenericEntityResponseDto>();
            foreach (UserRole userRole in userRolesList)
            {
                ((List<GenericEntityResponseDto>)commonEntityListResponse.ListOfUserRoles).Add(new GenericEntityResponseDto
                {
                    Id = userRole.Id,
                    Title = userRole.Title
                });
            }

            return commonEntityListResponse;
        }

        #endregion
    }
}
