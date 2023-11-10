using AutoMapper;
using Entities.DataModels;
using Entities.DTOs.Request;

namespace BusinessAccessLayer.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            CreateMap<AdmitRequest, AdmitRequestDTO>().ReverseMap();
        }
    }
}
