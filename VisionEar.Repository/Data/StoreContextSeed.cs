using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VisionEar.Core.Entities;

namespace VisionEar.Repository.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext dbcontext)
        {
            #region Brands

            if (dbcontext.Brands.Count() == 0)
            {
                var brandsData = File.ReadAllText("../VisionEar.Repository/Data/DataSeed/Brands.json");
                var brands = JsonSerializer.Deserialize<List<Brands>>(brandsData);
                if(brands?.Count() > 0) {

                    foreach (var brand in brands)
                    {
                        await dbcontext.Brands.AddAsync(brand);
                    }
                    await dbcontext.SaveChangesAsync();
                }
            }
            #endregion

            #region Categories
            if (dbcontext.Categories.Count() == 0)
            {
                var CategoriesData = File.ReadAllText("../VisionEar.Repository/Data/DataSeed/Categories.json");
                var categories = JsonSerializer.Deserialize<List<Categories>>(CategoriesData);
                if(categories?.Count() > 0) {

                    foreach (var category in categories)
                    {
                        await dbcontext.Categories.AddAsync(category);
                    }
                    await dbcontext.SaveChangesAsync();
                }
            }
            #endregion
            if (dbcontext.Products.Count() == 0)
            {
                var ProductsData = File.ReadAllText("../VisionEar.Repository/Data/DataSeed/Products.json");
                var Products = JsonSerializer.Deserialize<List<Products>>(ProductsData);

                if ((Products?.Count > 0)) {

                    foreach (var product in Products)
                    {
                        await dbcontext.Products.AddAsync(product);
                    }
                    await dbcontext.SaveChangesAsync();
                }

            }
        }
    }
}
