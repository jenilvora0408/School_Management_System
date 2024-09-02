using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using Entities.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static API.Helpers.JwtAuthPolicies;

namespace API.Controllers;

[ApiController]
[Route("api/teacher")]
[TeachersPolicy]
public class TeacherController(ITeacherService teacherService) : BaseController
{
    #region Constructor

    private readonly ITeacherService _teacherService = teacherService;

    #endregion Constructor

    #region HTTP_Methods

    [HttpGet("get-admit-request/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401, Type = typeof(UnauthorizedHttpResult))]
    [ProducesResponseType(500, Type = typeof(ApiResponse))]
    public async Task<IActionResult> GetAdmitRequest(long id)
    {
        return GetResult(await _teacherService.GetAdmitRequest(id), message: null);
    }

    [HttpPost("create-leave-request")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401, Type = typeof(UnauthorizedHttpResult))]
    [ProducesResponseType(404, Type = typeof(NotFound))]
    [ProducesResponseType(500, Type = typeof(ApiResponse))]
    public async Task<IActionResult> CreateLeaveRequest(LeaveRequestDTO leaveRequestDTO)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _teacherService.CreateLeaveRequest(leaveRequestDTO);
        return GetResult(null, message: MessageConstants.SuccessMessage.LEAVE_REQUEST_CREATED);
    }

    [HttpPost("leave-request-list")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401, Type = typeof(UnauthorizedHttpResult))]
    [ProducesResponseType(500, Type = typeof(ApiResponse))]
    public async Task<IActionResult> LeaveRequestList(LeaveRequestsListDTO leaveRequestsListDTO)
    {
        return GetResult(await _teacherService.GetAllLeaveRequest(leaveRequestsListDTO), message: null);
    }

    [HttpPost("admit-request-approval")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401, Type = typeof(UnauthorizedHttpResult))]
    [ProducesResponseType(404, Type = typeof(NotFound))]
    [ProducesResponseType(500, Type = typeof(ApiResponse))]
    public async Task<IActionResult> AdmitRequestApproval(AdmitRequestApprovalDTO admitRequestApprovalDTO)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _teacherService.AdmitRequestApproval(admitRequestApprovalDTO);
        return GetResult(null, message: null);
    }

    [HttpGet("get-leaves-count/{userId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401, Type = typeof(UnauthorizedHttpResult))]
    [ProducesResponseType(500, Type = typeof(ApiResponse))]
    public async Task<IActionResult> GetLeavesCount(long userId)
    {
        LeavesCountDTO response = await _teacherService.GetLeavesCount(userId);
        return GetResult(response, message: null);
    }

    #endregion HTTP_Methods
}
