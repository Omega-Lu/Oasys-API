using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly OasysDBContext employeeDBContext;
        public EmployeeController(OasysDBContext employeeDBContext)
        {
            this.employeeDBContext = employeeDBContext;
        }
        //Get All Cards
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var Employees = await employeeDBContext.Employee.ToListAsync();
            return Ok(Employees);
        }

        //Get single Employee
        [HttpGet("{id}")]
        [ActionName("GetEmployee")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var Employees = await employeeDBContext.Employee.FirstOrDefaultAsync(x => x.EMPLOYEE_ID == id);
            if (Employees != null)
            {
                return Ok(Employees);
            }
            return NotFound("Employee not found");
        }

        //add single Employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee Employee)
        {
            await employeeDBContext.Employee.AddAsync(Employee);
            await employeeDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployee), new { id = Employee.EMPLOYEE_ID }, Employee);
        }

        //Updating a Employee
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee Employee)
        {
            var existingEmployee = await employeeDBContext.Employee.FirstOrDefaultAsync(x => x.EMPLOYEE_ID == id);
            if (existingEmployee != null)
            {
                existingEmployee.EMPLOYEE_ID = id;
                existingEmployee.NAME = Employee.NAME;
                existingEmployee.SURNAME = Employee.SURNAME;
                existingEmployee.TITLE = Employee.TITLE;
                existingEmployee.EMAIL = Employee.EMAIL;
                existingEmployee.CONTACT_NUMBER = Employee.CONTACT_NUMBER;
                await employeeDBContext.SaveChangesAsync();
                return Ok(existingEmployee);
            }
            return NotFound("Employee Not Found");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var existingEmployee = await employeeDBContext.Employee.FirstOrDefaultAsync(x => x.EMPLOYEE_ID == id);
            if (existingEmployee != null)
            {
                employeeDBContext.Employee.Remove(existingEmployee);
                await employeeDBContext.SaveChangesAsync();
                return Ok(existingEmployee);
            }
            return NotFound("Employee not found");
        }
    }
}
