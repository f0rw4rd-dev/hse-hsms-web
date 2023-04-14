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
    public class ComponentStoragesController : ControllerBase
    {
        private readonly StoreContext _context;

        public ComponentStoragesController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/ComponentStorages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponentStorage>>> GetComponentStorages()
        {
          if (_context.ComponentStorages == null)
          {
              return NotFound();
          }
            return await _context.ComponentStorages.ToListAsync();
        }

        // GET: api/ComponentStorages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentStorage>> GetComponentStorage(int id)
        {
          if (_context.ComponentStorages == null)
          {
              return NotFound();
          }
            var componentStorage = await _context.ComponentStorages.FindAsync(id);

            if (componentStorage == null)
            {
                return NotFound();
            }

            return componentStorage;
        }

        // PUT: api/ComponentStorages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponentStorage(int id, ComponentStorage componentStorage)
        {
            if (id != componentStorage.Id)
            {
                return BadRequest();
            }

            _context.Entry(componentStorage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentStorageExists(id))
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

        // POST: api/ComponentStorages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComponentStorage>> PostComponentStorage(ComponentStorage componentStorage)
        {
          if (_context.ComponentStorages == null)
          {
              return Problem("Entity set 'StoreContext.ComponentStorages'  is null.");
          }
            _context.ComponentStorages.Add(componentStorage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponentStorage", new { id = componentStorage.Id }, componentStorage);
        }

        // DELETE: api/ComponentStorages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponentStorage(int id)
        {
            if (_context.ComponentStorages == null)
            {
                return NotFound();
            }
            var componentStorage = await _context.ComponentStorages.FindAsync(id);
            if (componentStorage == null)
            {
                return NotFound();
            }

            _context.ComponentStorages.Remove(componentStorage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponentStorageExists(int id)
        {
            return (_context.ComponentStorages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
