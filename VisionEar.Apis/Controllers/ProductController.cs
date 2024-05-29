using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisionEar.Apis.Dtos;
using VisionEar.Core.Entities;
using VisionEar.Core.IRepository;
using VisionEar.Core.Specifications.ProductSpec;
using VisionEar.Repository.Data;

namespace VisionEar.Apis.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IGenericRepositroy<Products> productRepo;
        private readonly IMapper mapper;

        public ProductController(IGenericRepositroy<Products> productRepo,IMapper mapper )
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
        }


        [HttpGet("{Code}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(string Code)
        {
            
            var spec = new ProductIncludes(Code);
            var product = await productRepo.GetWithSpecAsync(spec);
            if (product is null)
                return NotFound();
            return Ok(mapper.Map<Products,ProductToReturnDto>(product));

        } 


    }
}
