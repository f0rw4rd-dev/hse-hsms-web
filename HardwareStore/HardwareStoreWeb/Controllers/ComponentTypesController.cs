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
    public class ComponentTypesController : ControllerBase
    {
        private readonly StoreContext _context;

        public ComponentTypesController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/ComponentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponentType>>> GetComponentTypes()
        {
          if (_context.ComponentTypes == null)
          {
              return NotFound();
          }
            return await _context.ComponentTypes.ToListAsync();
        }

        // GET: api/ComponentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentType>> GetComponentType(int id)
        {
          if (_context.ComponentTypes == null)
          {
              return NotFound();
          }
            var componentType = await _context.ComponentTypes.FindAsync(id);

            if (componentType == null)
            {
                return NotFound();
            }

            return componentType;
        }

        // PUT: api/ComponentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponentType(int id, ComponentType componentType)
        {
            if (id != componentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(componentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentTypeExists(id))
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

        // POST: api/ComponentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComponentType>> PostComponentType(ComponentType componentType)
        {
          if (_context.ComponentTypes == null)
          {
              return Problem("Entity set 'StoreContext.ComponentTypes'  is null.");
          }
            _context.ComponentTypes.Add(componentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponentType", new { id = componentType.Id }, componentType);
        }

        // DELETE: api/ComponentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponentType(int id)
        {
            if (_context.ComponentTypes == null)
            {
                return NotFound();
            }
            var componentType = await _context.ComponentTypes.FindAsync(id);
            if (componentType == null)
            {
                return NotFound();
            }

            _context.ComponentTypes.Remove(componentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponentTypeExists(int id)
        {
            return (_context.ComponentTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
