using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using VisionEar.Apis.Dtos;
using VisionEar.Core.Entities;
using VisionEar.Core.Entities.Identity;
using VisionEar.Core.IRepository;
using VisionEar.Core.Specifications.ProductSpec;
using VisionEar.Repository.IDentity;
using VisionEar.Repository.Migrations.identity;

namespace VisionEar.Apis.Controllers
{
 
    public class AdminController : BaseApiController
    {
        private readonly IDashboardRepository<Products> productRepo;
        private readonly IMapper mapper;
        private readonly IGenericRepositroy<Products> pRoductGenRepo;
        private readonly IDashboardRepository<Brands> brandRepo;
        private readonly IDashboardRepository<Categories> categoriesRepo;

        public AdminController(IDashboardRepository<Products> ProductRepo,IMapper _mapper,IGenericRepositroy<Products> PRoductGenRepo ,IDashboardRepository<Brands> BrandRepo,IDashboardRepository<Categories> CategoriesRepo)
        {
            productRepo = ProductRepo;
            mapper = _mapper;
            pRoductGenRepo = PRoductGenRepo;
            brandRepo = BrandRepo;
            categoriesRepo = CategoriesRepo;
        }


        #region Products



        [HttpGet("GetAllProducts")]
        public async Task<ActionResult> GetAllProduct()
        {
            var spec = new ProductIncludes();
            var products = await pRoductGenRepo.GetAllWithspecAsync(spec);
            if (products is not null)
                return Ok(products);
            return NotFound();
        }
        


        [HttpDelete("Delete/{id}")]
        public async Task DeleteProduct(int id)
        {
            var product = await productRepo.GetById(id);
            if (product == null)
            {
                NotFound();
            }

            await productRepo.Delete(product);

 
        }
        
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductToReturnDto productDto)
        {
            try
            {
                // Fetch the existing product from the repository by its ID
                var existingProduct = await productRepo.GetById(id);

                // Check if the product exists
                if (existingProduct == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }

                // Map the properties from ProductToReturnDto to Products entity
                var product = mapper.Map(productDto, existingProduct);
                // mapper.Map<Products, ProductToReturnDto>(existingProduct);

                // Update the product
                 await productRepo.Update(product);

                return Ok(product); // Return the updated product
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the product: {ex.Message}");
            }
        }

         [HttpPost("Add")]
        public async Task<ActionResult> AddProduct([FromBody]Products product)
        {
           // var product = mapper.Map< ProductToReturnDto, Products>(productDto);
            await productRepo.Add(product);
            return Ok(product);
        }
        #endregion



        #region Brnads

        [HttpGet("GetBrands")]
        public async Task<ActionResult> GEtAllBrands()
        {
            var Brands = await brandRepo.GetAll();
            if (Brands is not null)
                return Ok(Brands);
            return NotFound();

        }
        [HttpPost("AddBrand")]
        public async Task<ActionResult> AddBrand(Brands brnad)
        {
            await brandRepo.Add(brnad);
            return Ok(brnad);

        }
        #endregion


        #region Categories

        [HttpGet("GetCategories")]
        public async Task<ActionResult> GEtAllCategories()
        {
            var Categories = await categoriesRepo.GetAll();
            if (Categories is not null)
                return Ok(Categories);
            return NotFound();

        }
        [HttpPost("AddCategory")]
        public async Task<ActionResult> AddCategory(Categories category)
        {
            await categoriesRepo.Add(category);
            return Ok(category);

        }

        #endregion



    }
}
