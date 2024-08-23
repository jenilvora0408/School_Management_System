using API.Helpers;
using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using static API.Helpers.JwtAuthPolicies;

namespace API.Controllers;

[ApiController]
[Route("api/principal")]
[PrincipalPolicy]
public class PrincipalController(IPrincipalService principalService) : ControllerBase
{
    #region Constructor

    private readonly IPrincipalService _principalService = principalService;

    #endregion

    [HttpPost("edit-class")]
    public async Task<IActionResult> EditClass(ClassRequestDTO classRequestDTO, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _principalService.UpsertClasses(classRequestDTO, cancellationToken);
        return ResponseHelper.SuccessResponse<object>(null, message: MessageConstants.SuccessMessage.CLASS_EDITED);
    }
}
