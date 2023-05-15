using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.DetailTypes
{
	public class EditModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public EditModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		[BindProperty]
		public DetailType DetailType { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.DetailTypes == null)
			{
				return NotFound();
			}

			var detailtype = await _context.DetailTypes.FirstOrDefaultAsync(m => m.Id == id);
			if (detailtype == null)
			{
				return NotFound();
			}
			DetailType = detailtype;
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return await OnGetAsync(DetailType.Id);
			}

            var detailTypeExist = await _context.DetailTypes.Where(x => x.Name == DetailType.Name && x.Id != DetailType.Id).AnyAsync();
            if (detailTypeExist)
            {
                ViewData["ErrorMessage"] = "Тип характеристик с таким названием уже существует!";
                return await OnGetAsync(DetailType.Id);
            }

            _context.Attach(DetailType).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!DetailTypeExists(DetailType.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Index");
		}

		private bool DetailTypeExists(int id)
		{
			return (_context.DetailTypes?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
