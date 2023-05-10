﻿using System;
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
	public class DetailsModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public DetailsModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public Supply Supply { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Supplies == null)
			{
				return NotFound();
			}

			var supply = await _context.Supplies.FirstOrDefaultAsync(m => m.Id == id);
			if (supply == null)
			{
				return NotFound();
			}
			else
			{
				Supply = supply;
			}
			return Page();
		}
	}
}
