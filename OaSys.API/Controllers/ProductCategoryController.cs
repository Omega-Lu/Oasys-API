using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : Controller
    {
        private readonly OasysDBContext ProductCategoryDBContext;
        public ProductCategoryController(OasysDBContext ProductCategoryDBContext)
        {
            this.ProductCategoryDBContext = ProductCategoryDBContext;
        }

        //Get All ProductCategories
        [HttpGet]
        public async Task<IActionResult> GetAllProductCategories()
        {
            var ProductCategorys = await ProductCategoryDBContext.Product_Category.ToListAsync();
            return Ok(ProductCategorys);
        }

        //Get single ProductCategory
        [HttpGet("{id}")]
        [ActionName("GetProductCategory")]
        public async Task<IActionResult> GetProductCategory(int id)
        {
            var EmployeesType = await ProductCategoryDBContext.Product_Category.FirstOrDefaultAsync(x => x.PRODUCT_CATEGORY_ID == id);
            if (EmployeesType != null)
            {
                return Ok(EmployeesType);
            }
            return NotFound("Product Category not found");
        }

        //ad a single ProductCategory
        [HttpPost]
        public async Task<IActionResult> AddProductCategory([FromBody] Product_Category ProductCategory)
        {
            await ProductCategoryDBContext.Product_Category.AddAsync(ProductCategory);
            await ProductCategoryDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductCategory), new { id = ProductCategory.PRODUCT_CATEGORY_ID }, ProductCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductCategory(int id, [FromBody] Product_Category ProductCategory)
        {
            var existingProductCategory = await ProductCategoryDBContext.Product_Category.FirstOrDefaultAsync(x => x.PRODUCT_CATEGORY_ID == id);
            if (existingProductCategory != null)
            {
                existingProductCategory.CATEGORY_NAME = ProductCategory.CATEGORY_NAME;
                existingProductCategory.CATEGORY_DESCRIPTION = ProductCategory.CATEGORY_DESCRIPTION;
                await ProductCategoryDBContext.SaveChangesAsync();
                return Ok(existingProductCategory);
            }
            return NotFound("Employee Not Found");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            var existingProductCategory = await ProductCategoryDBContext.Product_Category.FirstOrDefaultAsync(x => x.PRODUCT_CATEGORY_ID == id);
            if (existingProductCategory != null)
            {
                ProductCategoryDBContext.Product_Category.Remove(existingProductCategory);
                await ProductCategoryDBContext.SaveChangesAsync();
                return Ok(existingProductCategory);
            }
            return NotFound("Employee not found");
        }

    }

}
