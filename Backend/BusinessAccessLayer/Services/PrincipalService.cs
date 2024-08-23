using BusinessAccessLayer.Interface;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs;
using Entities.ExtensionMethods.MappingProfiles;
using Microsoft.AspNetCore.Hosting;

namespace BusinessAccessLayer.Services;

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

    #endregion HTTP_Methods
}
