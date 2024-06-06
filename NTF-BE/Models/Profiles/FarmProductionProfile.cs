using AutoMapper;
using NTF_BE.Models.DTO;

namespace NTF_BE.Models.Profiles
{
    public class FarmProductionProfile : Profile
    {
        public FarmProductionProfile()
        {
            CreateMap<FarmProduction, FarmProductionDTO>();
            CreateMap<FarmProductionDTO, FarmProduction>();
        }
    }
}
