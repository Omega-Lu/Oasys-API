using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerAccountController : Controller
    {
        private readonly OasysDBContext customeraccountDBContext;
        public CustomerAccountController(OasysDBContext customeraccountDBContext)
        {
            this.customeraccountDBContext = customeraccountDBContext;
        }

        //Get All Cards
        [HttpGet]
        public async Task<IActionResult> GetAllCustomerAccounts()
        {
            var CustomerAccounts = await customeraccountDBContext.Customer_Account.ToListAsync();
            return Ok(CustomerAccounts);
        }

        //Get single Employee
        [HttpGet("{id}")]
        [ActionName("GetCustomerAccount")]
        public async Task<IActionResult> GetCustomerAccount(int id)
        {
            var EmployeesType = await customeraccountDBContext.Customer_Account.FirstOrDefaultAsync(x => x.CUSTOMER_ACCOUNT_ID == id);
            if (EmployeesType != null)
            {
                return Ok(EmployeesType);
            }
            return NotFound("Employee not found");
        }

        //ad a single emplyee
        [HttpPost]
        public async Task<IActionResult> AddCustomerAccount([FromBody] Customer_Account CustomerAccount)
        {
            await customeraccountDBContext.Customer_Account.AddAsync(CustomerAccount);
            await customeraccountDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomerAccount), new { id = CustomerAccount.CUSTOMER_ACCOUNT_ID }, CustomerAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAccount(int id, [FromBody] Customer_Account CustomerAccount)
        {
            var existingCustomerAccount = await customeraccountDBContext.Customer_Account.FirstOrDefaultAsync(x => x.CUSTOMER_ACCOUNT_ID == id);
            if (existingCustomerAccount != null)
            {
                existingCustomerAccount.CUSTOMER_ACCOUNT_ID = id;
                existingCustomerAccount.NAME = CustomerAccount.NAME;
                existingCustomerAccount.SURNAME = CustomerAccount.SURNAME;
                existingCustomerAccount.EMAIL = CustomerAccount.EMAIL;
                existingCustomerAccount.CONTACT_NUMBER = CustomerAccount.CONTACT_NUMBER;
                existingCustomerAccount.CREDIT_LIMIT = CustomerAccount.CREDIT_LIMIT;

                await customeraccountDBContext.SaveChangesAsync();
                return Ok(existingCustomerAccount);
            }
            return NotFound("Employee Not Found");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAccount(int id)
        {
            var existingCustomerAccount = await customeraccountDBContext.Customer_Account.FirstOrDefaultAsync(x => x.CUSTOMER_ACCOUNT_ID == id);
            if (existingCustomerAccount != null)
            {
                customeraccountDBContext.Customer_Account.Remove(existingCustomerAccount);
                await customeraccountDBContext.SaveChangesAsync();
                return Ok(existingCustomerAccount);
            }
            return NotFound("Employee not found");
        }

    }
}
