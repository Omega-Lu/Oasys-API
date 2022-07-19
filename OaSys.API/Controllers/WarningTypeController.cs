using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarningTypeController : Controller
    {
        private readonly OasysDBContext WarningTypeDBContext;
        public WarningTypeController(OasysDBContext WarningTypeDBContext)
        {
            this.WarningTypeDBContext = WarningTypeDBContext;
        }

        //Get All Cards
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeTypes()
        {
            var WarningTypes = await WarningTypeDBContext.Warning_Type.ToListAsync();
            return Ok(WarningTypes);
        }

        //Get single Employee
        [HttpGet("{id}")]
        [ActionName("GetWarningType")]
        public async Task<IActionResult> GetWarningType(int id)
        {
            var EmployeesType = await WarningTypeDBContext.Warning_Type.FirstOrDefaultAsync(x => x.WARNING_TYPE_ID == id);
            if (EmployeesType != null)
            {
                return Ok(EmployeesType);
            }
            return NotFound("Employee not found");
        }

        //ad a single emplyee
        [HttpPost]
        public async Task<IActionResult> AddWarningType([FromBody] Warning_Type WarningType)
        {
            await WarningTypeDBContext.Warning_Type.AddAsync(WarningType);
            await WarningTypeDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWarningType), new { id = WarningType.WARNING_TYPE_ID }, WarningType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarningType(int id, [FromBody] Warning_Type WarningType)
        {
            var existingWarningType = await WarningTypeDBContext.Warning_Type.FirstOrDefaultAsync(x => x.WARNING_TYPE_ID == id);
            if (existingWarningType != null)
            {
                existingWarningType.DESCRIPTION = WarningType.DESCRIPTION;
                await WarningTypeDBContext.SaveChangesAsync();
                return Ok(existingWarningType);
            }
            return NotFound("Employee Not Found");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var existingWarningType = await WarningTypeDBContext.Warning_Type.FirstOrDefaultAsync(x => x.WARNING_TYPE_ID == id);
            if (existingWarningType != null)
            {
                WarningTypeDBContext.Warning_Type.Remove(existingWarningType);
                await WarningTypeDBContext.SaveChangesAsync();
                return Ok(existingWarningType);
            }
            return NotFound("Employee not found");
        }

    }

}
