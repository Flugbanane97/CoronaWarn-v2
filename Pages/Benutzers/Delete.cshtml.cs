using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoronaWarn;

namespace CoronaWarn.Pages.Benutzers
{
    public class DeleteModel : PageModel
    {
        private readonly CoronaWarn.coronawarnContext _context;

        public DeleteModel(CoronaWarn.coronawarnContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Benutzer = await _context.Benutzers.FindAsync(id);

            if (Benutzer != null)
            {
                _context.Benutzers.Remove(Benutzer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
