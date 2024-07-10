using API.Helpers;
using BusinessAccessLayer.Interface;
using Common.Constants;
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

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCredentialsDTO userCredential)
    {
        return ResponseHelper.SuccessResponse(await _userService.Login(userCredential), MessageConstants.SuccessMessage.OTP_SENT);
    }

    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOtp(LoginOtpDTO otpData)
    {
        return ResponseHelper.SuccessResponse(await _userService.VerifyOtp(otpData), MessageConstants.SuccessMessage.LOGIN_SUCCESS);
    }

    [HttpPost("send-otp")]
    public async Task<IActionResult> SendOtp(EmailRequestDTO emailRequestDTO)
    {
        await _userService.SendOtp(emailRequestDTO.Email);
        return ResponseHelper.SuccessResponse<object>(null, MessageConstants.SuccessMessage.OTP_SENT);
    }
}
