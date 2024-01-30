using BusinessAccessLayer.Interface;
using Common.Constants;
using Entities.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SchoolManagementAPI.Helpers;

namespace SchoolManagementAPI.Areas.Common.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        #region Constructor

        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        #endregion

        #region Methods

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCredentialsDTO userCredential)
        {
            SetCookieHeaderValue? cookieHeaderValue = new SetCookieHeaderValue(SystemConstants.REMEMBER_ME_COOKIE_POLICY, userCredential.RememberMe.ToString())
            {
                Expires = DateTime.UtcNow.AddDays(90),
                Path = "/", // Set the cookie path
                Domain = "localhost", // Set the cookie domain                                                                                    
                Secure = true,
                SameSite = Microsoft.Net.Http.Headers.SameSiteMode.None // Set whether the cookie requires a secure connection (https)
            };

            Response.Headers[HeaderNames.SetCookie] = cookieHeaderValue.ToString();
            return ResponseHelper.SuccessResponse(await _authenticationService.Login(userCredential), MessageConstants.OTP_SENT);
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(LoginOtpDTO otpData)
        {
            bool remeberMe = Request.Cookies[SystemConstants.REMEMBER_ME_COOKIE_POLICY] is not null && Request.Cookies[SystemConstants.REMEMBER_ME_COOKIE_POLICY] == SystemConstants.TRUE_STRING;

            return ResponseHelper.SuccessResponse(await _authenticationService.VerifyOtp(otpData, remeberMe), MessageConstants.LOGIN_SUCCESS);
        }

        #endregion
    }
}
