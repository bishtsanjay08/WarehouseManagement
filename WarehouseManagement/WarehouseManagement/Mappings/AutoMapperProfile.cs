using AutoMapper;
using WarehouseManagement.DTOs;
using WarehouseManagement.Models;

namespace WarehouseManagement.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StoreCreateDto, Store>();
            CreateMap<Store, StoreDto>();
            CreateMap<StoreUpdateDto, Store>()
            .ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
