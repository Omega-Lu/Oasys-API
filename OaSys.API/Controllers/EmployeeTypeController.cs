using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeTypeController : Controller
    {
        private readonly OasysDBContext employeetypeDBContext;
        public EmployeeTypeController(OasysDBContext employeetypeDBContext)
        {
            this.employeetypeDBContext = employeetypeDBContext;
        }

        //Get All Cards
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeTypes()
        {
            var EmployeeTypes = await employeetypeDBContext.Employee_Type.ToListAsync();
            return Ok(EmployeeTypes);
        }

        //Get single Employee
        [HttpGet("{id}")]
        [ActionName("GetEmployeeType")]
        public async Task<IActionResult> GetEmployeeType(int id)
        {
            var EmployeesType = await employeetypeDBContext.Employee_Type.FirstOrDefaultAsync(x => x.EMPLOYEE_TYPE_ID == id);
            if (EmployeesType != null)
            {
                return Ok(EmployeesType);
            }
            return NotFound("Employee not found");
        }

        //ad a single emplyee
        [HttpPost]
        public async Task<IActionResult> AddEmployeeType([FromBody] Employee_Type EmployeeType)
        {
            await employeetypeDBContext.Employee_Type.AddAsync(EmployeeType);
            await employeetypeDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployeeType), new { id = EmployeeType.EMPLOYEE_TYPE_ID }, EmployeeType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeType(int id, [FromBody] Employee_Type EmployeeType)
        {
            var existingEmployeeType = await employeetypeDBContext.Employee_Type.FirstOrDefaultAsync(x => x.EMPLOYEE_TYPE_ID == id);
            if (existingEmployeeType != null)
            {
                existingEmployeeType.POSITION_NAME = EmployeeType.POSITION_NAME;
                await employeetypeDBContext.SaveChangesAsync();
                return Ok(existingEmployeeType);
            }
            return NotFound("Employee Not Found");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var existingEmployeeType = await employeetypeDBContext.Employee_Type.FirstOrDefaultAsync(x => x.EMPLOYEE_TYPE_ID == id);
            if (existingEmployeeType != null)
            {
                employeetypeDBContext.Employee_Type.Remove(existingEmployeeType);
                await employeetypeDBContext.SaveChangesAsync();
                return Ok(existingEmployeeType);
            }
            return NotFound("Employee not found");
        }

    }

}
