using AutoMapper;
using ProjectEcommerceFruit.Dtos;
using ProjectEcommerceFruit.Dtos.Store;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Helper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Store, StoreRespone>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

            CreateMap<User, UserDto>();

            CreateMap<StoreRequest, Store>();
        }
    }
}
