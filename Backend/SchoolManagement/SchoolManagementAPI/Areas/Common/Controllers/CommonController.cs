using BusinessAccessLayer.Interface;
using Entities.DataModels;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementAPI.Helpers;

namespace SchoolManagementAPI.Areas.Common.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        #region Constructor
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("getCommonEntityList")]
        public async Task<IActionResult> GetCommonEntityList()
        {
            return ResponseHelper.SuccessResponse(await _commonService.GetEntityList());
        }

        #endregion
    }
}
