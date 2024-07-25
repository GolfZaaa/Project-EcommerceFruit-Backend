using AutoMapper;
using ProjectEcommerceFruit.Dtos;
using ProjectEcommerceFruit.Dtos.Address;
using ProjectEcommerceFruit.Dtos.Product;
using ProjectEcommerceFruit.Dtos.ProductGI;
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

            CreateMap<Address, AddressRespone>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

            CreateMap<AddressRequest, Address>();

            CreateMap<ProductGI, ProductGIRespone>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<ProductGI, ProductGIRespone>()
                .ForMember(dest => dest.Store, opt => opt.MapFrom(src => src.Store));

            CreateMap<ProductGIRequest, ProductGI>();

            CreateMap<Product, ProductRespone>();

        }
    }
}
