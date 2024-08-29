using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using Entities.DTOs;
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
    public async Task<IActionResult> CreateAdmitRequest(AdmitRequestDTO request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _userService.CreateAdmitRequest(request, cancellationToken);
        return GetResult(null, message: MessageConstants.SuccessMessage.ADMIT_REQUEST_CREATED);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCredentialsDTO userCredential)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        return GetResult(await _userService.Login(userCredential), MessageConstants.SuccessMessage.OTP_SENT);
    }

    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOtp(LoginOtpDTO otpData)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        return GetResult(await _userService.VerifyOtp(otpData), MessageConstants.SuccessMessage.LOGIN_SUCCESS);
    }

    [HttpPost("send-otp")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> SendOtp(EmailRequestDTO emailRequestDTO)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _userService.SendOtp(emailRequestDTO.Email);
        return GetResult(null, message: MessageConstants.SuccessMessage.OTP_SENT);
    }

    [HttpPost("forget-password")]
    public async Task<IActionResult> ForgetPassword(EmailRequestDTO emailRequestDTO)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _userService.ForgetPassword(emailRequestDTO.Email);
        return GetResult(null, message: MessageConstants.SuccessMessage.OTP_SENT);
    }

    [HttpPut("reset-password")]
    public async Task<IActionResult> ResetPassword(LoginCredentialsDTO loginCredentialsDTO)
    {
        if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
        await _userService.ResetPassword(loginCredentialsDTO);
        return GetResult(null, MessageConstants.SuccessMessage.PASSWORD_RESETTED);
    }

    [HttpGet("check-admit-request-status/{email}")]
    public async Task<IActionResult> CheckAdmitRequestStatus(string email)
    {
        string responseMessage = await _userService.CheckAdmitRequestStatus(email);
        return GetResult(responseMessage, null);
    }
}
