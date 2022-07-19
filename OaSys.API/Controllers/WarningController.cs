using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarningController : Controller
    {
        private readonly OasysDBContext WarningDBContext;
        public WarningController(OasysDBContext WarningDBContext)
        {
            this.WarningDBContext = WarningDBContext;
        }
        //Get All Cards
        [HttpGet]
        public async Task<IActionResult> GetAllWarnings()
        {
            var Warnings = await WarningDBContext.Warning.ToListAsync();
            return Ok(Warnings);
        }

        //Get single Warning
        [HttpGet("{id}")]
        [ActionName("GetWarning")]
        public async Task<IActionResult> GetWarning(int id)
        {
            var Warnings = await WarningDBContext.Warning.FirstOrDefaultAsync(x => x.WARNING_ID == id);
            if (Warnings != null)
            {
                return Ok(Warnings);
            }
            return NotFound("Warning not found");
        }

        //add single Warning
        [HttpPost]
        public async Task<IActionResult> AddWarning([FromBody] Warning Warning)
        {
            await WarningDBContext.Warning.AddAsync(Warning);
            await WarningDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWarning), new { id = Warning.WARNING_ID }, Warning);
        }

        //Updating a Warning
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarning(int id, [FromBody] Warning Warning)
        {
            var existingWarning = await WarningDBContext.Warning.FirstOrDefaultAsync(x => x.WARNING_ID == id);
            if (existingWarning != null)
            {
                existingWarning.WARINING_NAME = Warning.WARINING_NAME;
                existingWarning.REASON = Warning.REASON;
                await WarningDBContext.SaveChangesAsync();
                return Ok(existingWarning);
            }
            return NotFound("Warning Not Found");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarning(int id)
        {
            var existingWarning = await WarningDBContext.Warning.FirstOrDefaultAsync(x => x.WARNING_ID == id);
            if (existingWarning != null)
            {
                WarningDBContext.Warning.Remove(existingWarning);
                await WarningDBContext.SaveChangesAsync();
                return Ok(existingWarning);
            }
            return NotFound("Warning not found");
        }
    }
}