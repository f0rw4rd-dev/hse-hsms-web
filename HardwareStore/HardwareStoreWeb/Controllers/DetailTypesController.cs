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
    public class DetailTypesController : ControllerBase
    {
        private readonly StoreContext _context;

        public DetailTypesController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/DetailTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailType>>> GetDetailTypes()
        {
          if (_context.DetailTypes == null)
          {
              return NotFound();
          }
            return await _context.DetailTypes.ToListAsync();
        }

        // GET: api/DetailTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailType>> GetDetailType(int id)
        {
          if (_context.DetailTypes == null)
          {
              return NotFound();
          }
            var detailType = await _context.DetailTypes.FindAsync(id);

            if (detailType == null)
            {
                return NotFound();
            }

            return detailType;
        }

        // PUT: api/DetailTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailType(int id, DetailType detailType)
        {
            if (id != detailType.Id)
            {
                return BadRequest();
            }

            _context.Entry(detailType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailTypeExists(id))
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

        // POST: api/DetailTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetailType>> PostDetailType(DetailType detailType)
        {
          if (_context.DetailTypes == null)
          {
              return Problem("Entity set 'StoreContext.DetailTypes'  is null.");
          }
            _context.DetailTypes.Add(detailType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetailType", new { id = detailType.Id }, detailType);
        }

        // DELETE: api/DetailTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetailType(int id)
        {
            if (_context.DetailTypes == null)
            {
                return NotFound();
            }
            var detailType = await _context.DetailTypes.FindAsync(id);
            if (detailType == null)
            {
                return NotFound();
            }

            _context.DetailTypes.Remove(detailType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetailTypeExists(int id)
        {
            return (_context.DetailTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
