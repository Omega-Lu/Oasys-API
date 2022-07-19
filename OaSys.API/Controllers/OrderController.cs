using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OaSys.API.Data;
using OaSys.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OaSys.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OasysDBContext OrderDBContext;

        public OrderController(OasysDBContext supplierOrderDBContext)
        {
            this.OrderDBContext = OrderDBContext;
        }

        //Get All Supplier Orders USE HTTPGET FOR RECEIVING
        [HttpGet]

        public async Task<ActionResult> ReceiveAllOrders()
        {
            var Orders = await OrderDBContext.Order.ToListAsync();
            return Ok(Orders);
        }
        [HttpGet("id")]
        [Route("GetSupplierOrder")]

        public async Task<IActionResult> ReceiveSupplierOrder(int id)
        {
            var supplierOrders = await OrderDBContext.Order.FirstOrDefaultAsync(x => x.ORDER_ID == id);
            if (supplierOrders == null)
            {
                return NotFound("Order Not Found");
            }
            return Ok(supplierOrders);
        }
        //Create Supplier Order HTTPPOST

        [HttpPost]

        public async Task<IActionResult> CreateOrder([FromBody] Order Order)
        {
            await OrderDBContext.Order.AddAsync(Order);
            await OrderDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(ReceiveSupplierOrder), new { id = Order.ORDER_ID }, Order);
        }

        //Update Orders
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order Order)
        {
            var existingOrder = await OrderDBContext.Order.FirstOrDefaultAsync(x => x.ORDER_ID == id);
            if (existingOrder == null)
            {
                return NotFound("Order Not Found");
            }
            existingOrder.ORDER_ID = id;
            existingOrder.ORDER_STATUS = Order.ORDER_STATUS;
            existingOrder.DATE_PLACED = Order.DATE_PLACED;
            existingOrder.DATE_RECEIVED = Order.DATE_RECEIVED;
            return Ok(existingOrder);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteOrder(int id)
        {
            var existingOrder = await OrderDBContext.Order.FirstOrDefaultAsync(x => x.ORDER_ID == id);
            if (existingOrder != null)
            {
                OrderDBContext.Order.Remove(existingOrder);
                await OrderDBContext.SaveChangesAsync();
                return Ok(existingOrder);
            }
            return NotFound("Order Not Found"); 
        }









    }
}
