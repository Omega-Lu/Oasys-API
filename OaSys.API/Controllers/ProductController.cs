using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly OasysDBContext productDBContext;
        public ProductController(OasysDBContext productDBContext)
        {
            this.productDBContext = productDBContext;
        }
        //Get All Cards
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var Products = await productDBContext.Product.ToListAsync();
            return Ok(Products);
        }

        //Get single Product
        [HttpGet("{id}")]
        [ActionName("GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var Products = await productDBContext.Product.FirstOrDefaultAsync(x => x.PRODUCT_ID == id);
            if (Products != null)
            {
                return Ok(Products);
            }
            return NotFound("Product not found");
        }

        //add single Product
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product Product)
        {
            await productDBContext.Product.AddAsync(Product);
            await productDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = Product.PRODUCT_ID }, Product);
        }

        //Updating a Product
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product Product)
        {
            var existingProduct = await productDBContext.Product.FirstOrDefaultAsync(x => x.PRODUCT_ID == id);
            if (existingProduct != null)
            {
                existingProduct.PRODUCT_ID = id;
                existingProduct.PRODUCT_CATEGORY_ID = Product.PRODUCT_CATEGORY_ID;
                existingProduct.PRODUCT_TYPE_ID = Product.PRODUCT_TYPE_ID;
                existingProduct.PRODUCT_NAME = Product.PRODUCT_NAME;
                existingProduct.PRODUCT_DESCRIPTION = Product.PRODUCT_DESCRIPTION;
                existingProduct.QUANTITY_ON_HAND = Product.QUANTITY_ON_HAND;
                existingProduct.COST_PRICE = Product.COST_PRICE;
                existingProduct.SELLING_PRICE = Product.SELLING_PRICE;
                existingProduct.REORDER_LIMIT = Product.REORDER_LIMIT;
                await productDBContext.SaveChangesAsync();
                return Ok(existingProduct);
            }
            return NotFound("Product Not Found");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await productDBContext.Product.FirstOrDefaultAsync(x => x.PRODUCT_ID == id);
            if (existingProduct != null)
            {
                productDBContext.Product.Remove(existingProduct);
                await productDBContext.SaveChangesAsync();
                return Ok(existingProduct);
            }
            return NotFound("Product not found");
        }
    }
}
