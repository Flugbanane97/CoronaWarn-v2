using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoronaWarn;

namespace CoronaWarn.Pages.Benutzers
{
    public class EditModel : PageModel
    {
        private readonly CoronaWarn.coronawarnContext _context;

        public EditModel(CoronaWarn.coronawarnContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Benutzer Benutzer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Benutzer = await _context.Benutzers.FirstOrDefaultAsync(m => m.Id == id);

            if (Benutzer == null)
            {
                return NotFound();
            }
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

            _context.Attach(Benutzer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenutzerExists(Benutzer.Id))
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

        private bool BenutzerExists(int id)
        {
            return _context.Benutzers.Any(e => e.Id == id);
        }
    }
}
