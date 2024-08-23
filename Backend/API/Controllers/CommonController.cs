using API.Helpers;
using BusinessAccessLayer.Interface;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using static API.Helpers.JwtAuthPolicies;

namespace API.Controllers;

[ApiController]
[Route("api/common")]

public class CommonController(ICommonService commonService) : ControllerBase
{
    #region Constructor

    private readonly ICommonService _commonService = commonService;

    #endregion Constructor

    [HttpGet("common-entity-list")]
    public async Task<IActionResult> GetCommonEntityList()
    {
        CommonEntityListResponseDTO response = await _commonService.GetEntityList();
        return ResponseHelper.SuccessResponse(response);
    }

    [HttpPost("admit-request-list")]
    [TeachersPolicy]
    public async Task<IActionResult> GetAdmitRequestList(PageListRequestDTO pageListRequest)
    {
        return ResponseHelper.SuccessResponse(await _commonService.GetAdmitRequestsList(pageListRequest));
    }

    [HttpGet("get-all-classes-info")]
    public async Task<IActionResult> GetAllClassesInfo()
    {
        return ResponseHelper.SuccessResponse(await _commonService.GetAllClasses());
    }

    [HttpGet("get-all-teachers")]
    public async Task<IActionResult> GetAllTeachers()
    {
        return ResponseHelper.SuccessResponse(await _commonService.GetAllTeachers());
    }
}
