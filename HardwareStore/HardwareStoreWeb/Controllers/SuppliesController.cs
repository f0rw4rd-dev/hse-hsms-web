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
	public class SuppliesController : ControllerBase
	{
		private readonly StoreContext _context;

		public SuppliesController(StoreContext context)
		{
			_context = context;
		}

		// GET: api/Supplies
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Supply>>> GetSupplies()
		{
			if (_context.Supplies == null)
			{
				return NotFound();
			}
			return await _context.Supplies.OrderBy(x => x.Date).ToListAsync();
		}

		// GET: api/Supplies/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Supply>> GetSupply(int id)
		{
			if (_context.Supplies == null)
			{
				return NotFound();
			}
			var supply = await _context.Supplies.FindAsync(id);

			if (supply == null)
			{
				return NotFound();
			}

			return supply;
		}
	}
}
