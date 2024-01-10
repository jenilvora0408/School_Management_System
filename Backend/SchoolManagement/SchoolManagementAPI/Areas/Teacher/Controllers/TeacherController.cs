using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Models;
using Entities.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementAPI.ExtAuthorization;
using SchoolManagementAPI.Helpers;

namespace SchoolManagementAPI.Areas.Teacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TeachersPolicy]
    public class TeacherController : ControllerBase
    {
        private readonly IAdmitRequestApprovalService _admitRequestApprovalService;
        private AuthHelper _authHelper;
        public TeacherController(IAdmitRequestApprovalService admitRequestApprovalService, AuthHelper authHelper)
        {
           _admitRequestApprovalService = admitRequestApprovalService;
            _authHelper = authHelper;
        }

        [HttpPost]
        [Route("approveAdmitRequests")]
        public async Task<IActionResult> ApproveAdmitRequests(ApproveAdmitResponseDTO approveAdmitResponseDTO)
        {
            LoggedUser loggedUser = _authHelper.GetLoggedUser();

            string response = await _admitRequestApprovalService.ApproveAdmitRequest(approveAdmitResponseDTO, loggedUser.UserId);

            return ResponseHelper.SuccessResponse(null, response);
        }
    }
}
