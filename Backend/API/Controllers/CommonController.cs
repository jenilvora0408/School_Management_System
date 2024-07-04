using API.Helpers;
using BusinessAccessLayer.Interface;
using Entities.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("common-entity-list")]
    public async Task<IActionResult> GetCommonEntityList()
    {
        CommonEntityListResponseDTO response = await _commonService.GetEntityList();
        return ResponseHelper.SuccessResponse(response);
    }
}
