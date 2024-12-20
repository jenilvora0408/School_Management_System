using System.ComponentModel.DataAnnotations;
using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using static API.Helpers.JwtAuthPolicies;

namespace API.Controllers;

[ApiController]
[Route("api/common")]

public class CommonController(ICommonService commonService, ITeacherService teacherService) : BaseController
{
    #region Constructor

    private readonly ICommonService _commonService = commonService;
    private readonly ITeacherService _teacherService = teacherService;

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
    [ProducesResponseType(422)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> LeaveRequestApproval(LeavesApprovalDTO leavesApprovalDTO)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        return GetResult(null, message: await _commonService.LeaveRequestApproval(leavesApprovalDTO));
    }

    [HttpPost("contact-principal")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(422)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> ContactPrincipal(ContactPrincipalDTO contactPrincipalDTO)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _commonService.ContactPrincipalRequest(contactPrincipalDTO);
        return GetResult(null, message: MessageConstants.SuccessMessage.CONTACT_PRINCIPAL_SUCCESS);
    }

    [HttpPost("view-own-contact-requests")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(422)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> ViewOwnContactRequests(UserPageListRequestDTO userPageListRequestDTO)
    {
        return GetResult(await _commonService.GetOwnContactPrincipalRequests(userPageListRequestDTO), message: null);
    }

    
    [HttpGet("contact-documents/{id}")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetContactPrincipalDocuments([Required] int id)
    {
        return GetResult(await _commonService.GetContactPrincipalDocuments(id), message: null);
    }

    [HttpPost("chapters-of-class-subject")]
    [StudentTeacherPolicy]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> ChaptersofClassSubject(ClassSubjectPageListRequestDTO classSubjectPageListRequestDTO)
    {
        return GetResult(await _teacherService.GetAllClassSubjectChapters(classSubjectPageListRequestDTO), message: null);
    }

    [HttpGet("chapter-document/{courseId}")]
    [StudentTeacherPolicy]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetChapterDocument(int courseId)
    {
        return GetResult(await _teacherService.GetChapterDocument(courseId), message: null);
    }
}
