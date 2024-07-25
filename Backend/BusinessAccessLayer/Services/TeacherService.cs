using System.Linq.Expressions;
using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs;
using Entities.ExtensionMethods.MappingProfiles;
using Microsoft.AspNetCore.Http;

namespace BusinessAccessLayer.Services;

public class TeacherService : ITeacherService
{
    #region Constructor

    public readonly IUnitOfWork _unitOfWork;
    public TeacherService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion Constructor

    #region HTTP_Methods

    public async Task<ViewAdmitRequestDTO> GetAdmitRequest(long id)
    {
        AdmitRequest request = await _unitOfWork.AdmitRequestRepository.GetAsync(request => request.Id == id, [x => x.Classes, x => x.Mediums, x => x.Genders, x => x.BloodGroups, x => x.AdmitRequestRoles, x => x.ApprovedByUser, x => x.DeclinedByUser, x => x.BlockedByUser]) ?? throw new CustomException(StatusCodes.Status404NotFound, MessageConstants.ErrorMessage.ADMIT_REQUEST_NOT_FOUND);

        ViewAdmitRequestDTO viewAdmitRequestDTO = AdmitRequestMappingProfile.ToGetAdmitRequest(request);

        return viewAdmitRequestDTO;
    }

    #endregion HTTP_Methods
}
