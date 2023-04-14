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
    public class ComponentDetailsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ComponentDetailsController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/ComponentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponentDetail>>> GetComponentDetails()
        {
          if (_context.ComponentDetails == null)
          {
              return NotFound();
          }
            return await _context.ComponentDetails.ToListAsync();
        }

        // GET: api/ComponentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentDetail>> GetComponentDetail(int id)
        {
          if (_context.ComponentDetails == null)
          {
              return NotFound();
          }
            var componentDetail = await _context.ComponentDetails.FindAsync(id);

            if (componentDetail == null)
            {
                return NotFound();
            }

            return componentDetail;
        }

        // PUT: api/ComponentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponentDetail(int id, ComponentDetail componentDetail)
        {
            if (id != componentDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(componentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentDetailExists(id))
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

        // POST: api/ComponentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComponentDetail>> PostComponentDetail(ComponentDetail componentDetail)
        {
          if (_context.ComponentDetails == null)
          {
              return Problem("Entity set 'StoreContext.ComponentDetails'  is null.");
          }
            _context.ComponentDetails.Add(componentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponentDetail", new { id = componentDetail.Id }, componentDetail);
        }

        // DELETE: api/ComponentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponentDetail(int id)
        {
            if (_context.ComponentDetails == null)
            {
                return NotFound();
            }
            var componentDetail = await _context.ComponentDetails.FindAsync(id);
            if (componentDetail == null)
            {
                return NotFound();
            }

            _context.ComponentDetails.Remove(componentDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponentDetailExists(int id)
        {
            return (_context.ComponentDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
