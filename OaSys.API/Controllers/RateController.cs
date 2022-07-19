using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RateController : Controller
    {
        private readonly OasysDBContext RateDBContext;
        public RateController(OasysDBContext RateDBContext)
        {
            this.RateDBContext = RateDBContext;
        }
        //Get All Cards
        [HttpGet]
        public async Task<IActionResult> GetAllRates()
        {
            var Rates = await RateDBContext.Rate.ToListAsync();
            return Ok(Rates);
        }

        //Get single Rate
        [HttpGet("{id}")]
        [ActionName("GetRate")]
        public async Task<IActionResult> GetRate(int id)
        {
            var Rates = await RateDBContext.Rate.FirstOrDefaultAsync(x => x.RATE_ID == id);
            if (Rates != null)
            {
                return Ok(Rates);
            }
            return NotFound("Rate not found");
        }

        //add single Rate
        [HttpPost]
        public async Task<IActionResult> AddRate([FromBody] Rate Rate)
        {
            await RateDBContext.Rate.AddAsync(Rate);
            await RateDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRate), new { id = Rate.RATE_ID }, Rate);
        }

        //Updating a Rate
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRate(int id, [FromBody] Rate Rate)
        {
            var existingRate = await RateDBContext.Rate.FirstOrDefaultAsync(x => x.RATE_ID == id);
            if (existingRate != null)
            {
                existingRate.RATE_NAME = Rate.RATE_NAME;
                existingRate.RATE_AMOUNT = Rate.RATE_AMOUNT;
                await RateDBContext.SaveChangesAsync();
                return Ok(existingRate);
            }
            return NotFound("Rate Not Found");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRate(int id)
        {
            var existingRate = await RateDBContext.Rate.FirstOrDefaultAsync(x => x.RATE_ID == id);
            if (existingRate != null)
            {
                RateDBContext.Rate.Remove(existingRate);
                await RateDBContext.SaveChangesAsync();
                return Ok(existingRate);
            }
            return NotFound("Rate not found");
        }
    }
}
