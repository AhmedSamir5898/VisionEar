using AutoMapper;
using VisionEar.Apis.Dtos;
using VisionEar.Core.Entities;

namespace VisionEar.Apis.Helper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Products, ProductToReturnDto>()
                 .ForMember(B => B.Brand_name, O => O.MapFrom(P => P.Brands.brand_name))
               
                 .ForMember(C => C.Category_name, O => O.MapFrom(P => P.Categories.category_name))
         
                 .ForMember(U=>U.picture_url,O=>O.MapFrom<ProductPictureUrlResolve>());
            CreateMap<ProductToReturnDto, Products>()
            .ForMember(dest => dest.code, opt => opt.MapFrom(src => src.code))
            .ForMember(dest => dest.currency, opt => opt.MapFrom(src => src.currency))
            .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.description))
            .ForMember(dest => dest.picture_url, opt => opt.MapFrom(src => src.picture_url))
            .ForMember(dest => dest.price, opt => opt.MapFrom(src => src.price))
            .ForMember(dest => dest.product_name, opt => opt.MapFrom(src => src.product_name)); ;
            //CreateMap<Products, ProductToReturnDto>().ReverseMap();
            //CreateMap<Brands, CategoriesToReturnDto>().ReverseMap();
            //CreateMap<Categories, CategoriesToReturnDto>().ReverseMap();
        }
    }
}
