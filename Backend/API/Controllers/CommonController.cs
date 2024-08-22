using API.Helpers;
using BusinessAccessLayer.Interface;
using Common.Constants;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using static API.Helpers.JwtAuthPolicies;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CommonController : ControllerBase
{
    #region Constructor

    private readonly ICommonService _commonService;
    public CommonController(ICommonService commonService)
    {
        _commonService = commonService;
    }

    #endregion Constructor

    [HttpGet(APIRouteConstants.COMMON_ENTITYLIST)]
    public async Task<IActionResult> GetCommonEntityList()
    {
        CommonEntityListResponseDTO response = await _commonService.GetEntityList();
        return ResponseHelper.SuccessResponse(response);
    }

    [HttpPost(APIRouteConstants.ADMIT_REQUEST_LIST)]
    [TeachersPolicy]
    public async Task<IActionResult> GetAdmitRequestList(PageListRequestDTO pageListRequest)
    {
        return ResponseHelper.SuccessResponse(await _commonService.GetAdmitRequestsList(pageListRequest));
    }

    [HttpGet(APIRouteConstants.GET_ALL_CLASSES_INFO)]
    public async Task<IActionResult> GetAllClassesInfo()
    {
        return ResponseHelper.SuccessResponse(await _commonService.GetAllClasses());
    }
}
