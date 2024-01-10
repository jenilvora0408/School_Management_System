using AutoMapper;
using Entities.DataModels;
using Entities.DTOs.Request;
using Entities.DTOs.Response;

namespace BusinessAccessLayer.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            CreateMap<AdmitRequest, AdmitRequestDTO>().ReverseMap();

            CreateMap<AdmitRequestApproval, ApproveAdmitResponseDTO>().ReverseMap();

            CreateMap<User, AdmitRequest>().ReverseMap();
        }
    }
}
