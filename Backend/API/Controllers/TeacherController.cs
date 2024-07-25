using API.Helpers;
using BusinessAccessLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
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

    #endregion HTTP_Methods
}
