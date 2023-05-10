using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.Supplies
{
	public class IndexModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public IndexModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public IList<Supply> Supply { get; set; } = default!;

		public async Task OnGetAsync()
		{
			if (_context.Supplies != null)
			{
				Supply = await _context.Supplies
				.Include(s => s.Component)
				.Include(s => s.Supplier)
				.Include(s => s.Warehouse).ToListAsync();
			}
		}
	}
}
