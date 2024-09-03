using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using Entities.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(IUserService userService) : BaseController
{
    #region Constructor

    private readonly IUserService _userService = userService;

    #endregion Constructor

    [HttpPost("create-admit-request")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> CreateAdmitRequest(AdmitRequestDTO request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _userService.CreateAdmitRequest(request, cancellationToken);
        return GetResult(null, message: MessageConstants.SuccessMessage.ADMIT_REQUEST_CREATED);
    }

    [HttpPost("login")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Login(LoginCredentialsDTO userCredential)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        return GetResult(await _userService.Login(userCredential), MessageConstants.SuccessMessage.OTP_SENT);
    }

    [HttpPost("verify-otp")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> VerifyOtp(LoginOtpDTO otpData)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        return GetResult(await _userService.VerifyOtp(otpData), MessageConstants.SuccessMessage.LOGIN_SUCCESS);
    }

    [HttpPost("send-otp")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(500)]
    public async Task<IActionResult> SendOtp(EmailRequestDTO emailRequestDTO)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _userService.SendOtp(emailRequestDTO.Email);
        return GetResult(null, message: MessageConstants.SuccessMessage.OTP_SENT);
    }

    [HttpPost("forget-password")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> ForgetPassword(EmailRequestDTO emailRequestDTO)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _userService.ForgetPassword(emailRequestDTO.Email);
        return GetResult(null, message: MessageConstants.SuccessMessage.OTP_SENT);
    }

    [HttpPut("reset-password")]
    [ProducesResponseType(200, Type = typeof(ApiResponse))]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> ResetPassword(LoginCredentialsDTO loginCredentialsDTO)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _userService.ResetPassword(loginCredentialsDTO);
        return GetResult(null, MessageConstants.SuccessMessage.PASSWORD_RESETTED);
    }
}
