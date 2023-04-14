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
    public class ConfigurationsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ConfigurationsController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/Configurations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Configuration>>> GetConfigurations()
        {
          if (_context.Configurations == null)
          {
              return NotFound();
          }
            return await _context.Configurations.ToListAsync();
        }

        // GET: api/Configurations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Configuration>> GetConfiguration(int id)
        {
          if (_context.Configurations == null)
          {
              return NotFound();
          }
            var configuration = await _context.Configurations.FindAsync(id);

            if (configuration == null)
            {
                return NotFound();
            }

            return configuration;
        }

        // PUT: api/Configurations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfiguration(int id, Configuration configuration)
        {
            if (id != configuration.Id)
            {
                return BadRequest();
            }

            _context.Entry(configuration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigurationExists(id))
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

        // POST: api/Configurations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Configuration>> PostConfiguration(Configuration configuration)
        {
          if (_context.Configurations == null)
          {
              return Problem("Entity set 'StoreContext.Configurations'  is null.");
          }
            _context.Configurations.Add(configuration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfiguration", new { id = configuration.Id }, configuration);
        }

        // DELETE: api/Configurations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiguration(int id)
        {
            if (_context.Configurations == null)
            {
                return NotFound();
            }
            var configuration = await _context.Configurations.FindAsync(id);
            if (configuration == null)
            {
                return NotFound();
            }

            _context.Configurations.Remove(configuration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfigurationExists(int id)
        {
            return (_context.Configurations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
