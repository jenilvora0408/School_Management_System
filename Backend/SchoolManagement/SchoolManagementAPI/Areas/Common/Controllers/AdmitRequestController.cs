﻿using BusinessAccessLayer.Interface;
using Common.Constants;
using Entities.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementAPI.Helpers;

namespace SchoolManagementAPI.Areas.Common.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmitRequestController : ControllerBase
    {
        #region Constructor

        private IAdmitRequestService _admitRequestService; 
        public AdmitRequestController(IAdmitRequestService admitRequestService)
        {
            _admitRequestService = admitRequestService;
        }

        #endregion


        #region Methods

        [HttpPost]
        [Route("admitRequest")]
        public async Task<IActionResult> AdmitRequest([FromForm] AdmitRequestDTO admitRequestDTO)
        {
            await _admitRequestService.AdmitRequest(admitRequestDTO);

            return ResponseHelper.SuccessResponse(null, MessageConstants.REQUEST_SUBMITTED);
        }

        #endregion
    }
}
