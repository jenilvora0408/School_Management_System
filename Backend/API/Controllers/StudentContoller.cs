using BusinessAccessLayer.Interface;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using static API.Helpers.JwtAuthPolicies;

namespace API.Controllers;

[ApiController]
[Route("api/student")]
[StudentPolicy]
public class StudentContoller(IStudentService studentService) : BaseController
{
    #region Constructor

    private readonly IStudentService _studentService = studentService;

    #endregion Constructor

    [HttpPost("subjects")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(422)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> SubjectList(UserPageListRequestDTO userPageListRequestDTO)
    {
        return GetResult(await _studentService.GetStudentsSubjectsList(userPageListRequestDTO), message: null);
    }
}
