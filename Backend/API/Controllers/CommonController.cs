using BusinessAccessLayer.Interface;
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
}
