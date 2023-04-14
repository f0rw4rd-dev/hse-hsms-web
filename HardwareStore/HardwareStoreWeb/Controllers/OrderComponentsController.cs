using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderComponentsController : ControllerBase
    {
        private readonly StoreContext _context;

        public OrderComponentsController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/OrderComponents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderComponent>>> GetOrderComponents()
        {
          if (_context.OrderComponents == null)
          {
              return NotFound();
          }
            return await _context.OrderComponents.ToListAsync();
        }

        // GET: api/OrderComponents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderComponent>> GetOrderComponent(int id)
        {
          if (_context.OrderComponents == null)
          {
              return NotFound();
          }
            var orderComponent = await _context.OrderComponents.FindAsync(id);

            if (orderComponent == null)
            {
                return NotFound();
            }

            return orderComponent;
        }

        // PUT: api/OrderComponents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderComponent(int id, OrderComponent orderComponent)
        {
            if (id != orderComponent.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderComponent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderComponentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderComponents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderComponent>> PostOrderComponent(OrderComponent orderComponent)
        {
          if (_context.OrderComponents == null)
          {
              return Problem("Entity set 'StoreContext.OrderComponents'  is null.");
          }
            _context.OrderComponents.Add(orderComponent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderComponent", new { id = orderComponent.Id }, orderComponent);
        }

        // DELETE: api/OrderComponents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderComponent(int id)
        {
            if (_context.OrderComponents == null)
            {
                return NotFound();
            }
            var orderComponent = await _context.OrderComponents.FindAsync(id);
            if (orderComponent == null)
            {
                return NotFound();
            }

            _context.OrderComponents.Remove(orderComponent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderComponentExists(int id)
        {
            return (_context.OrderComponents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
