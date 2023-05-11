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

namespace HardwareStoreWeb.Pages.ComponentDetails
{
    public class EditModel : PageModel
    {
        private readonly HardwareStoreWeb.StoreContext _context;

        public EditModel(HardwareStoreWeb.StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ComponentDetail ComponentDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ComponentDetails == null)
            {
                return NotFound();
            }

            var componentdetail = await _context.ComponentDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (componentdetail == null)
            {
                return NotFound();
            }
            ComponentDetail = componentdetail;
            ViewData["ComponentId"] = new SelectList(_context.Components, "Id", "Id");
            ViewData["DetailTypeId"] = new SelectList(_context.DetailTypes, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return await OnGetAsync(ComponentDetail.Id);
            }

            var component = await _context.Components.FindAsync(ComponentDetail.ComponentId);
            if (component == null)
            {
                ViewData["ErrorMessage"] = "Комплектующее с данным ИД не существует!";
                return await OnGetAsync(ComponentDetail.Id);
            }

            _context.Attach(ComponentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentDetailExists(ComponentDetail.Id))
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

        private bool ComponentDetailExists(int id)
        {
            return (_context.ComponentDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
