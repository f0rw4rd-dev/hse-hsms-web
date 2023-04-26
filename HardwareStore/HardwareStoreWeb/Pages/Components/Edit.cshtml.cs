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

namespace HardwareStoreWeb.Pages.Components
{
    public class EditModel : PageModel
    {
        private readonly HardwareStoreWeb.StoreContext _context;

        public EditModel(HardwareStoreWeb.StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Component Component { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Components == null)
            {
                return NotFound();
            }

            var component =  await _context.Components.FirstOrDefaultAsync(m => m.Id == id);
            if (component == null)
            {
                return NotFound();
            }
            Component = component;
           ViewData["ComponentTypeId"] = new SelectList(_context.ComponentTypes, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Component).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentExists(Component.Id))
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

        private bool ComponentExists(int id)
        {
          return (_context.Components?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
