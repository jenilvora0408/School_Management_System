using BusinessAccessLayer.Interface;
using Entities.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
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
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetCommonEntityList()
    {
        CommonEntityListResponseDTO response = await _commonService.GetEntityList();
        return GetResult(response, message: null);
    }

    [HttpPost("admit-request-list")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401, Type = typeof(UnauthorizedHttpResult))]
    [ProducesResponseType(500, Type = typeof(ApiResponse))]
    [TeachersPolicy]
    public async Task<IActionResult> GetAdmitRequestList(PageListRequestDTO pageListRequest)
    {
        return GetResult(await _commonService.GetAdmitRequestsList(pageListRequest), message: null);
    }

    [HttpGet("get-all-classes-info")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500, Type = typeof(ApiResponse))]
    public async Task<IActionResult> GetAllClassesInfo()
    {
        return GetResult(await _commonService.GetAllClasses(), message: null);
    }

    [HttpGet("get-all-teachers")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500, Type = typeof(ApiResponse))]
    public async Task<IActionResult> GetAllTeachers()
    {
        return GetResult(await _commonService.GetAllTeachers(), message: null);
    }
}
