using API.Helpers;
using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using static API.Helpers.JwtAuthPolicies;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
[TeachersPolicy]
public class TeacherController : ControllerBase
{
    #region Constructor

    private readonly ITeacherService _teacherService;
    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    #endregion Constructor

    #region HTTP_Methods

    [HttpGet(APIRouteConstants.GET_ADMIT_REQUEST)]
    public async Task<IActionResult> GetAdmitRequest(long id)
    {
        return ResponseHelper.SuccessResponse(await _teacherService.GetAdmitRequest(id));
    }

    [HttpPost(APIRouteConstants.CREATE_LEAVE_REQUEST)]
    public async Task<IActionResult> CreateLeaveRequest(LeaveRequestDTO leaveRequestDTO)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _teacherService.CreateLeaveRequest(leaveRequestDTO);
        return ResponseHelper.SuccessResponse<object>(null, MessageConstants.SuccessMessage.LEAVE_REQUEST_CREATED);
    }

    [HttpPost(APIRouteConstants.LEAVE_REQUEST_LIST)]
    public async Task<IActionResult> LeaveRequestList(LeaveRequestsListDTO leaveRequestsListDTO)
    {
        return ResponseHelper.SuccessResponse(await _teacherService.GetAllLeaveRequest(leaveRequestsListDTO));
    }

    [HttpPost(APIRouteConstants.ADMIT_REQUEST_APPROVAL)]
    public async Task<IActionResult> AdmitRequestApproval(AdmitRequestApprovalDTO admitRequestApprovalDTO)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _teacherService.AdmitRequestApproval(admitRequestApprovalDTO);
        return ResponseHelper.SuccessResponse<object>(null);
    }

    [HttpGet(APIRouteConstants.GET_LEAVES_COUNT)]
    public async Task<IActionResult> GetLeavesCount(long userId)
    {
        LeavesCountDTO response = await _teacherService.GetLeavesCount(userId);
        return ResponseHelper.SuccessResponse(response);
    }

    #endregion HTTP_Methods
}
