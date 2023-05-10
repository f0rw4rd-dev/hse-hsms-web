using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.ComponentTypes
{
	public class IndexModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public IndexModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public IList<ComponentType> ComponentType { get; set; } = default!;

		public async Task OnGetAsync()
		{
			if (_context.ComponentTypes != null)
			{
				ComponentType = await _context.ComponentTypes.ToListAsync();
			}
		}
	}
}
