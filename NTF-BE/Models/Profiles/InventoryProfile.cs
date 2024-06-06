using AutoMapper;
using NTF_BE.Models.DTO;

namespace NTF_BE.Models.Profiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<Inventory, InventoryDTO>();
            CreateMap<InventoryDTO, Inventory>();
        }
    }
}
