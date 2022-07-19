using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : Controller
    {
        private readonly OasysDBContext supplierDBContext;
        public SupplierController(OasysDBContext supplierDBContext)
        {
            this.supplierDBContext = supplierDBContext;
        }
        //Get All Cards
        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var Suppliers = await supplierDBContext.Supplier.ToListAsync();
            return Ok(Suppliers);
        }

        //Get single Supplier
        [HttpGet("{id}")]
        [ActionName("GetSupplier")]
        public async Task<IActionResult> GetSupplier(int id)
        {
            var Suppliers = await supplierDBContext.Supplier.FirstOrDefaultAsync(x => x.SUPPLIER_ID == id);
            if (Suppliers != null)
            {
                return Ok(Suppliers);
            }
            return NotFound("Supplier not found");
        }

        //add single Supplier
        [HttpPost]
        public async Task<IActionResult> AddSupplier([FromBody] Supplier Supplier)
        {
            await supplierDBContext.Supplier.AddAsync(Supplier);
            await supplierDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSupplier), new { id = Supplier.SUPPLIER_ID }, Supplier);
        }

        //Updating a Supplier
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, [FromBody] Supplier Supplier)
        {
            var existingSupplier = await supplierDBContext.Supplier.FirstOrDefaultAsync(x => x.SUPPLIER_ID == id);
            if (existingSupplier != null)
            {
                existingSupplier.SUPPLIER_ID = id;
                existingSupplier.NAME = Supplier.NAME;
                existingSupplier.VAT_NUMBER = Supplier.VAT_NUMBER;
                existingSupplier.CONTACT_NUMBER = Supplier.CONTACT_NUMBER;
                existingSupplier.ALT_NUMBER = Supplier.ALT_NUMBER;
                existingSupplier.EMAIL = Supplier.EMAIL;
                await supplierDBContext.SaveChangesAsync();
                return Ok(existingSupplier);
            }
            return NotFound("Supplier Not Found");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var existingSupplier = await supplierDBContext.Supplier.FirstOrDefaultAsync(x => x.SUPPLIER_ID == id);
            if (existingSupplier != null)
            {
                supplierDBContext.Supplier.Remove(existingSupplier);
                await supplierDBContext.SaveChangesAsync();
                return Ok(existingSupplier);
            }
            return NotFound("Supplier not found");
        }
    }
}
