using AutoMapper;
using NTF_BE.Models.DTO;

namespace NTF_BE.Models.Profiles
{
    public class CropProfile : Profile
    {
        public CropProfile()
        {
            CreateMap<Crop, CropDTO>();
            CreateMap<CropDTO, Crop>();
        }
    }
}
