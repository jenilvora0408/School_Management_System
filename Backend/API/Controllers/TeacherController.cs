using API.Helpers;
using BusinessAccessLayer.Interface;
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

    [HttpGet("get-admit-request/{id}")]
    public async Task<IActionResult> GetAdmitRequest(long id)
    {
        return ResponseHelper.SuccessResponse(await _teacherService.GetAdmitRequest(id));
    }

    [HttpPost("create-leave-request")]
    public async Task<IActionResult> CreateLeaveRequest(LeaveRequestDTO leaveRequestDTO)
    {
        await _teacherService.CreateLeaveRequest(leaveRequestDTO);
        return ResponseHelper.SuccessResponse<object>(null);
    }

    [HttpPost("leave-request-list")]
    public async Task<IActionResult> LeaveRequestList(LeaveRequestsListDTO leaveRequestsListDTO)
    {
        return ResponseHelper.SuccessResponse(await _teacherService.GetAllLeaveRequest(leaveRequestsListDTO));
    }

    [HttpPost("admit-request-approval")]
    public async Task<IActionResult> AdmitRequestApproval(AdmitRequestApprovalDTO admitRequestApprovalDTO)
    {
        await _teacherService.AdmitRequestApproval(admitRequestApprovalDTO);
        return ResponseHelper.SuccessResponse<object>(null);
    }

    #endregion HTTP_Methods
}
