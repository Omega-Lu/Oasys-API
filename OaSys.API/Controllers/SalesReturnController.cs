using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReturnController : ControllerBase
    {
        private readonly OasysDBContext salesReturnDBContext;
        public SalesReturnController(OasysDBContext SalesReturnDBContext)
        {
            salesReturnDBContext = SalesReturnDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSalesReturns()
        {
            var salesReturn = await salesReturnDBContext.SalesReturn.ToListAsync();
            return Ok(salesReturn);
        }

        //get a single sales return
        [HttpGet]

        public async Task<IActionResult> GetSalesReturn(int id)
        {
            var salesReturns = await salesReturnDBContext.SalesReturn.FirstOrDefaultAsync(x => x.Return_ID == id);
            if(salesReturns != null)
            {
                return Ok(salesReturns);
            }
            return NotFound("Sales Return Not Found");
        }

        //Add Sales Return
        [HttpPost]

        public async Task<IActionResult> AddSalesReturn([FromBody] SalesReturn salesReturn)
        {
            await salesReturnDBContext.SalesReturn.AddAsync(salesReturn);
            await salesReturnDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSalesReturn), new { id = salesReturn.Return_ID }, salesReturn);
        }

        //Updating SalesReturn
        [HttpPut]
        public async Task<IActionResult> UpdateSalesReturn(int id, [FromBody] SalesReturn salesReturn)
        {
            var existingSalesReturn = await salesReturnDBContext.SalesReturn.FirstOrDefaultAsync(x => x.Return_ID == id);
            if(existingSalesReturn != null)
            {
                existingSalesReturn.Return_ID = id;
                existingSalesReturn.Sale_ID = salesReturn.Sale_ID;
                await salesReturnDBContext.SaveChangesAsync();
                return Ok(existingSalesReturn);
            }
            return NotFound("SalesReturn Not Found");

        }

        //Deleting SalesReturn
        [HttpDelete]

        public async Task<IActionResult> DeleteSalesReturn(int id)
        {
            var existingSalesReturn = await salesReturnDBContext.SalesReturn.FirstOrDefaultAsync(x => x.Return_ID == id);
            if(existingSalesReturn != null)
            {
                salesReturnDBContext.SalesReturn.Remove(existingSalesReturn);
                await salesReturnDBContext.SaveChangesAsync();
                return Ok(existingSalesReturn);
            }
            return NotFound("SalesReturn Not Found");
        }

    }
}