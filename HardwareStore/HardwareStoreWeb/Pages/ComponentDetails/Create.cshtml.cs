using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.ComponentDetails
{
    public class CreateModel : PageModel
    {
        private readonly HardwareStoreWeb.StoreContext _context;

        public CreateModel(HardwareStoreWeb.StoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ComponentId"] = new SelectList(_context.Components, "Id", "Id");
            ViewData["DetailTypeId"] = new SelectList(_context.DetailTypes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public ComponentDetail ComponentDetail { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.ComponentDetails == null || ComponentDetail == null)
            {
                return OnGet();
            }

            var component = await _context.Components.FindAsync(ComponentDetail.Id);
            if (component == null)
            {
                ViewData["ErrorMessage"] = "Комплектующее с данным ИД не существует!";
                return OnGet();
			}

            _context.ComponentDetails.Add(ComponentDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
