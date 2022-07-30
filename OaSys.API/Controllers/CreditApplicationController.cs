using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditApplicationController : ControllerBase
    {
        private readonly OasysDBContext creditApplicationDBContext;
        public CreditApplicationController(OasysDBContext creditApplicationDBContext)
        {
            this.creditApplicationDBContext = creditApplicationDBContext;
        }

        //Get All Cards
        [HttpGet]
        public async Task<IActionResult> GetAllCreditApplications()
        {
            var creditApplication = await creditApplicationDBContext.CreditApplication.ToListAsync();
            return Ok(creditApplication);
        }

        //Get single Employee
        [HttpGet("{id}")]
        [ActionName("GetCustomerAccount")]
        public async Task<IActionResult> GetCreditApplication(int id)
        {
            var creditApplicationType = await creditApplicationDBContext.CreditApplication.FirstOrDefaultAsync(x => x.CUSTOMER_ACCOUNT_ID == id);
            if (creditApplicationType != null)
            {
                return Ok(creditApplicationType);
            }
            return NotFound("CreditApplication not found");
        }

        //ad a single emplyee
        [HttpPost]
        public async Task<IActionResult> AddCustomerAccount([FromBody] Customer_Account CreditApplication)
        {
            await creditApplicationDBContext.Customer_Account.AddAsync(CreditApplication);
            await creditApplicationDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCreditApplication), new { id = CreditApplication.CUSTOMER_ACCOUNT_ID }, CreditApplication);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCreditApplication(int id, [FromBody] CreditApplication CreditApplication)
        {
            var existingCreditApplication = await creditApplicationDBContext.Customer_Account.FirstOrDefaultAsync(x => x.CUSTOMER_ACCOUNT_ID == id);
            if (existingCreditApplication != null)
            {
                existingCreditApplication.CUSTOMER_ACCOUNT_ID = id;
                existingCreditApplication.NAME = CreditApplication.NAME;
                existingCreditApplication.SURNAME = CreditApplication.SURNAME;
                existingCreditApplication.EMAIL = CreditApplication.EMAIL;
                existingCreditApplication.CONTACT_NUMBER = CreditApplication.CONTACT_NUMBER;
                existingCreditApplication.CREDIT_LIMIT = CreditApplication.CREDIT_LIMIT;

                await creditApplicationDBContext.SaveChangesAsync();
                return Ok(existingCreditApplication);
            }
            return NotFound("Employee Not Found");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreditApplication(int id)
        {
            var existingCreditApplication = await creditApplicationDBContext.CreditApplication.FirstOrDefaultAsync(x => x.CUSTOMER_ACCOUNT_ID == id);
            if (existingCreditApplication != null)
            {
                creditApplicationDBContext.CreditApplication.Remove(existingCreditApplication);
                await creditApplicationDBContext.SaveChangesAsync();
                return Ok(existingCreditApplication);
            }
            return NotFound("Credit Application not found");
        }
    }
}
