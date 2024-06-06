using AutoMapper;
using NTF_BE.Models.DTO;

namespace NTF_BE.Models.Profiles
{
    public class FarmProfile : Profile
    {
        public FarmProfile()
        {
            CreateMap<Farm, FarmDTO>();
            CreateMap<FarmDTO, Farm>();
        }
    }
}
