using API.Helpers;
using BusinessAccessLayer.Interface;
using Common.Exceptions;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    #region Constructor

    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    #endregion Constructor

    [HttpPost("create-admit-request")]
    public async Task<IActionResult> CreateAdmitRequest(AdmitRequestDTO request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            throw new ModelStateException(ModelState);

        await _userService.CreateAdmitRequest(request, cancellationToken);
        return ResponseHelper.SuccessResponse<object>(null, message: "Admit request created successfully!");
    }
}
