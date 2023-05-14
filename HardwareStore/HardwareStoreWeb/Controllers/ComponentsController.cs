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
	public class ComponentsController : ControllerBase
	{
		private readonly StoreContext _context;

		public ComponentsController(StoreContext context)
		{
			_context = context;
		}

		// GET: api/Components
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Component>>> GetComponents()
		{
			if (_context.Components == null)
			{
				return NotFound();
			}
			return await _context.Components.ToListAsync();
		}

		// GET: api/Components/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Component>> GetComponent(int id)
		{
			if (_context.Components == null)
			{
				return NotFound();
			}
			var component = await _context.Components.FindAsync(id);

			if (component == null)
			{
				return NotFound();
			}

			return component;
		}
	}
}
