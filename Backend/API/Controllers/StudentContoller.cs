using Microsoft.AspNetCore.Mvc;
using static API.Helpers.JwtAuthPolicies;

namespace API.Controllers;

[ApiController]
[Route("api/student")]
[StudentPolicy]
public class StudentContoller : ControllerBase
{

}
