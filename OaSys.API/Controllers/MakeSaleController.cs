using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeSalesController : ControllerBase
    {
        private readonly OasysDBContext makeSalesDBContext;
        public MakeSalesController(OasysDBContext MakeSalesDBContext)
        {
            makeSalesDBContext = MakeSalesDBContext;
        }

        //Get All Sales
        [HttpGet]
        public async Task<IActionResult> GetAllSales()
        {
            var sales = await makeSalesDBContext.Sales.ToListAsync();
            return Ok(sales);
        }

        //Get a single sale
        [HttpGet]
        [ActionName("GetSale")]
        public async Task<IActionResult> GetSale(int id)
        {
            var sales = await makeSalesDBContext.Sales.FirstOrDefaultAsync(x => x.SALE_ID == id);
            if (sales != null)
            {
                return Ok(sales);
            }
            return NotFound("Sale Not Found");
        }

        //add a single Order
        [HttpPost]
        public async Task<IActionResult> AddSale([FromBody] Sales sales)
        {
            await makeSalesDBContext.Sales.AddAsync(sales);
            await makeSalesDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSale), new { id = sales.SALE_ID }, sales);
        }

        //Deleting an Order
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var existingSales = await makeSalesDBContext.Sales.FirstOrDefaultAsync(x => x.SALE_ID == id);
            if (existingSales != null)
            {
                makeSalesDBContext.Sales.Remove(existingSales);
                await makeSalesDBContext.SaveChangesAsync();
                return Ok(existingSales);
            }
            return NotFound("Order not found");
        }
    }
}
