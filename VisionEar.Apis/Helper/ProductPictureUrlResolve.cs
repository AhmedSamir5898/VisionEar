using AutoMapper;
using AutoMapper.Execution;
using VisionEar.Apis.Dtos;
using VisionEar.Core.Entities;

namespace VisionEar.Apis.Helper
{
    public class ProductPictureUrlResolve : IValueResolver<Products, ProductToReturnDto, string>
    {
        private readonly IConfiguration configuration;

        public ProductPictureUrlResolve(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Products source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.picture_url))
                return $"{configuration["BasePictureUrl"]}/{source.picture_url}";
            return string.Empty;
           
        }
    }
}
