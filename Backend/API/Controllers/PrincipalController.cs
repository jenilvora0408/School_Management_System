using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using Entities.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static API.Helpers.JwtAuthPolicies;

namespace API.Controllers;

[ApiController]
[Route("api/principal")]
[PrincipalPolicy]
public class PrincipalController(IPrincipalService principalService) : BaseController
{
    #region Constructor

    private readonly IPrincipalService _principalService = principalService;

    #endregion

    [HttpPost("edit-class")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401, Type = typeof(UnauthorizedHttpResult))]
    [ProducesResponseType(500, Type = typeof(ApiResponse))]
    public async Task<IActionResult> EditClass(ClassRequestDTO classRequestDTO, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _principalService.UpsertClasses(classRequestDTO, cancellationToken);
        return GetResult(null, message: MessageConstants.SuccessMessage.CLASS_EDITED);
    }

    [HttpGet("get-all-subjects/{classId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401, Type = typeof(UnauthorizedHttpResult))]
    [ProducesResponseType(500, Type = typeof(ApiResponse))]
    public async Task<IActionResult> GetAllSubjects(int classId)
    {
        return GetResult(await _principalService.GetSubjectsByClass(classId), message: null);
    }
}
