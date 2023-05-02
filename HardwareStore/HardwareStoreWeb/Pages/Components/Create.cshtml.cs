using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.Components
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
            ViewData["ComponentTypeId"] = new SelectList(_context.ComponentTypes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Component Component { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Components == null || Component == null)
            {
                return Page();
            }

            _context.Components.Add(Component);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
