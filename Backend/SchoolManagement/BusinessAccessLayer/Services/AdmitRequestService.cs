using AutoMapper;
using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Enums;
using Common.Exceptions;
using Common.Helpers;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs.Request;
using Microsoft.Extensions.Hosting;

namespace BusinessAccessLayer.Services
{
    public class AdmitRequestService : GenericService<AdmitRequest>, IAdmitRequestService
    {
        #region Constructor

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _env;
        public AdmitRequestService(IUnitOfWork unitOfWork, IMapper mapper, IHostEnvironment env) : base(unitOfWork.AdmitRequestRepository, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _env = env;
        }

        #endregion


        #region Methods

        public async Task AdmitRequest(AdmitRequestDTO admitRequestDTO)
        {
            User user = await _unitOfWork.AuthenticationRepository.GetUserByEmail(admitRequestDTO.Email);

            AdmitRequest admit = await GetFirstOrDefaultAsync(x => x.Email == admitRequestDTO.Email);

            if (user != null || admit != null)
                throw new ForbiddenException(ValidationConstants.EMAIL_ALREADY_EXIST);

            AdmitRequest admitRequest = new();
            _mapper.Map(admitRequestDTO, admitRequest);

            //Upload an Image
            KeyValuePair<string, string> fileData = await new FileHelper(_env).UploadFileToDestination(admitRequestDTO.Avatar);
            admitRequest.Avatar = fileData.Key;

            await AddAsync(admitRequest);
        }

        #endregion
    }
}
