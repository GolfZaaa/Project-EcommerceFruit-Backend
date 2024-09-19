using AutoMapper;
using ProjectEcommerceFruit.Dtos;
using ProjectEcommerceFruit.Dtos.Address;
using ProjectEcommerceFruit.Dtos.Order;
using ProjectEcommerceFruit.Dtos.Product;
using ProjectEcommerceFruit.Dtos.ProductGI;
using ProjectEcommerceFruit.Dtos.Store;
using ProjectEcommerceFruit.Dtos.SystemSetting;
using ProjectEcommerceFruit.Dtos.User;
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
            CreateMap<UserDto, User>();

            CreateMap<StoreRequest, Store>();

            CreateMap<Address, AddressRespone>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

            CreateMap<AddressRequest, Address>();

            CreateMap<ProductGI, ProductGIRespone>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<Images, ImageRespone>();

            CreateMap<ProductGI, ProductGIRespone>()
                .ForMember(dest => dest.Store, opt => opt.MapFrom(src => src.Store));

            CreateMap<ProductGIRequest, ProductGI>();

            CreateMap<Product, ProductRespone>()
                .ForMember(dest => dest.ProductGI, opt => opt.MapFrom(src => src.ProductGI));
            //CreateMap<ProductRequest, Product>();

            CreateMap<ProductRequest, Product>()
                .ForMember(dest => dest.Images, opt => opt.Ignore());

            CreateMap<OrderRequest, Order>();
            CreateMap<Order, OrderRespone>();

            CreateMap<OrderItem, OrderItemRespone>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));

            CreateMap<User, UserRespone>()
                .ForMember(dest => dest.Stores, opt => opt.MapFrom(src => src.Stores));

            CreateMap<SystemSettingRequest, SystemSetting>();
            CreateMap<SlideShowRequest, SlideShow>();

            CreateMap<SystemSetting, SystemSettingRespone>();

            CreateMap<SlideShow, SlideShowRespone>();

            CreateMap<NEWSRequest, NEWS>();
        }
    }
}
