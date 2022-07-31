using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleProductController : ControllerBase
    {
        public readonly OasysDBContext saleProductDBContext;

        public SaleProductController(OasysDBContext saleProductDBContext)
        {
            this.saleProductDBContext = saleProductDBContext;
        }
        //get All Saleproducts
        [HttpGet]

        public async Task<IActionResult> GetAllSaleProducts()
        {
            var saleProduct = await saleProductDBContext.SaleProduct.ToListAsync();
            return Ok(saleProduct);
        }

        //Get Single SaleProduct
        [HttpGet]

        [HttpGet("{id}")]
        [ActionName("GetSaleProduct")]
        public async Task<IActionResult> GetSaleProduct(int id)
        {
            var saleProducts = await saleProductDBContext.SaleProduct.FirstOrDefaultAsync(x => x.PRODUCT_ID == id);
            if (saleProducts != null)
            {
                return Ok(saleProducts);
            }
            return NotFound("SaleProduct not found");
        }

        //add single SaleProducts
        [HttpPost]
        public async Task<IActionResult> AddSaleProduct([FromBody] SaleProduct saleProduct)
        {
            await saleProductDBContext.SaleProduct.AddAsync(saleProduct);
            await saleProductDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSaleProduct), new { id = saleProduct.PRODUCT_ID }, saleProduct);
        }

        //Updating a SaleProducts
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderProduct(int id, [FromBody] SaleProduct saleProduct)
        {
            var existingSaleProduct = await saleProductDBContext.SaleProduct.FirstOrDefaultAsync(x => x.PRODUCT_ID == id);
            if (existingSaleProduct != null)
            {
                existingSaleProduct.PRODUCT_ID = id;
                existingSaleProduct.SALE_ID = saleProduct.SALE_ID;
                existingSaleProduct.QUANTITY = saleProduct.QUANTITY;
                await saleProductDBContext.SaveChangesAsync();
                return Ok(existingSaleProduct);
            }
            return NotFound("SaleProduct Not Found");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var existingSaleProduct = await saleProductDBContext.SaleProduct.FirstOrDefaultAsync(x => x.PRODUCT_ID == id);
            if (existingSaleProduct != null)
            {
                saleProductDBContext.SaleProduct.Remove(existingSaleProduct);
                await saleProductDBContext.SaveChangesAsync();
                return Ok(existingSaleProduct);
            }
            return NotFound("SaleProduct not found");
        }
    }

    
}
