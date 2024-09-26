using BusinessAccessLayer.Interface;
using Common.Constants;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using static API.Helpers.JwtAuthPolicies;

namespace API.Controllers;

[ApiController]
[Route("api/common")]

public class CommonController(ICommonService commonService) : BaseController
{
    #region Constructor

    private readonly ICommonService _commonService = commonService;

    #endregion Constructor

    [HttpGet("common-entity-list")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    public async Task<IActionResult> GetCommonEntityList()
    {
        CommonEntityListResponseDTO response = await _commonService.GetEntityList();
        return GetResult(response, message: null);
    }

    [HttpPost("admit-request-list")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    [TeachersPolicy]
    public async Task<IActionResult> GetAdmitRequestList(PageListRequestDTO pageListRequest)
    {
        return GetResult(await _commonService.GetAdmitRequestsList(pageListRequest), message: null);
    }

    [HttpGet("get-all-classes-info")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetAllClassesInfo()
    {
        return GetResult(await _commonService.GetAllClasses(), message: null);
    }

    [HttpGet("get-all-teachers")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetAllTeachers()
    {
        return GetResult(await _commonService.GetAllTeachers(), message: null);
    }

    [HttpGet("get-all-subjects")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    public async Task<IActionResult> GetAllSubjects()
    {
        return GetResult(await _commonService.GetAllSubjects(), message: null);
    }

    [HttpGet("get-user-profile/{userId}")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    public async Task<IActionResult> GetUserProfile(long userId)
    {
        return GetResult(await _commonService.GetUserProfile(userId), message: null);
    }

    [HttpPut("update-user-profile")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateUserProfile(GetUserProfileDTO getUserProfileDTO)
    {
        await _commonService.UpdateUserProfile(getUserProfileDTO);
        return GetResult(null, message: MessageConstants.SuccessMessage.PROFILE_UPDATED);
    }

    [HttpPatch("leave-request-approval")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> LeaveRequestApproval(LeavesApprovalDTO leavesApprovalDTO)
    {
        return GetResult(null, message: await _commonService.LeaveRequestApproval(leavesApprovalDTO));
    }
}
