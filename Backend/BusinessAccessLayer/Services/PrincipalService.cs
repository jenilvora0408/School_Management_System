using BusinessAccessLayer.Interface;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs;
using Entities.ExtensionMethods.MappingProfiles;
using Microsoft.AspNetCore.Hosting;

namespace BusinessAccessLayer.Services;

public class PrincipalService : IPrincipalService
{
    #region Constructor

    public readonly IUnitOfWork _unitOfWork;
    private readonly IMailService _mailService;
    private readonly ICommonService _commonService;
    private readonly IHostingEnvironment _environment;
    public PrincipalService(IUnitOfWork unitOfWork, ICommonService commonService, IHostingEnvironment environment, IMailService mailService)
    {
        _unitOfWork = unitOfWork;
        _commonService = commonService;
        _environment = environment;
        _mailService = mailService;
    }

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
