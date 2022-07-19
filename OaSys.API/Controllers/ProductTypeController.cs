using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTypeController : Controller
    {
        private readonly OasysDBContext ProductTypeDBContext;
        public ProductTypeController(OasysDBContext ProductTypeDBContext)
        {
            this.ProductTypeDBContext = ProductTypeDBContext;
        }

        //Get All Product Types
        [HttpGet]
        public async Task<IActionResult> GetAllProductTypes()
        {
            var ProductTypes = await ProductTypeDBContext.Product_Type.ToListAsync();
            return Ok(ProductTypes);
        }

        //Get single ProductType
        [HttpGet("{id}")]
        [ActionName("GetProductType")]
        public async Task<IActionResult> GetProductType(int id)
        {
            var EmployeesType = await ProductTypeDBContext.Product_Type.FirstOrDefaultAsync(x => x.PRODUCT_TYPE_ID == id);
            if (EmployeesType != null)
            {
                return Ok(EmployeesType);
            }
            return NotFound("Employee not found");
        }

        //add a single ProductType
        [HttpPost]
        public async Task<IActionResult> AddProductType([FromBody] Product_Type ProductType)
        {
            await ProductTypeDBContext.Product_Type.AddAsync(ProductType);
            await ProductTypeDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductType), new { id = ProductType.PRODUCT_TYPE_ID }, ProductType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductType(int id, [FromBody] Product_Type ProductType)
        {
            var existingProductType = await ProductTypeDBContext.Product_Type.FirstOrDefaultAsync(x => x.PRODUCT_TYPE_ID == id);
            if (existingProductType != null)
            {
                existingProductType.TYPE_NAME = ProductType.TYPE_NAME;
                existingProductType.PRODUCT_CATEGORY_ID = ProductType.PRODUCT_CATEGORY_ID;
                await ProductTypeDBContext.SaveChangesAsync();
                return Ok(existingProductType);
            }
            return NotFound("Employee Not Found");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var existingProductType = await ProductTypeDBContext.Product_Type.FirstOrDefaultAsync(x => x.PRODUCT_TYPE_ID == id);
            if (existingProductType != null)
            {
                ProductTypeDBContext.Product_Type.Remove(existingProductType);
                await ProductTypeDBContext.SaveChangesAsync();
                return Ok(existingProductType);
            }
            return NotFound("Product Type not found");
        }

    }

}
