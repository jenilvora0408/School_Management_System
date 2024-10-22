using System.ComponentModel.DataAnnotations;
using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using static API.Helpers.JwtAuthPolicies;

namespace API.Controllers;

[ApiController]
[Route("api/principal")]
// [PrincipalPolicy]
public class PrincipalController(IPrincipalService principalService) : BaseController
{
    #region Constructor

    private readonly IPrincipalService _principalService = principalService;

    #endregion

    [HttpPost("edit-class")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> EditClass(ClassRequestDTO classRequestDTO, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _principalService.UpsertClasses(classRequestDTO, cancellationToken);
        return GetResult(null, message: MessageConstants.SuccessMessage.CLASS_EDITED);
    }

    [HttpGet("get-all-subjects-by-class/{classId}")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetAllSubjects(int classId)
    {
        return GetResult(await _principalService.GetSubjectsByClass(classId), message: null);
    }

    [HttpPost("leave-requests-awaiting-approval")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetLeaveRequests(PageListRequestDTO pageListRequestDTO)
    {
        return GetResult(await _principalService.GetAllLeaveRequest(pageListRequestDTO), message: null);
    }

    [HttpPost("contact-principal-list")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> ContactPrincipalList(PageListRequestDTO pageListRequestDTO)
    {
        return GetResult(await _principalService.GetContactPrincipalList(pageListRequestDTO), message: null);
    }

    [HttpGet("contact-documents/{id}")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetContactPrincipalDocuments([Required] int id)
    {
        return GetResult(await _principalService.GetContactPrincipalDocuments(id), message: null);
    }

    [HttpPost("principal-response")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(401)]
    [ProducesResponseType(422)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostPrincipalResponse(ContactPrincipalResponseDTO contactPrincipalResponseDTO)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _principalService.PostContactPrincipalResponse(contactPrincipalResponseDTO);
        return GetResult(null, message: null);
    }
}
