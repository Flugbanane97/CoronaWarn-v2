using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoronaWarn;

namespace CoronaWarn.Pages.Benutzers
{
    public class CreateModel : PageModel
    {
        private readonly CoronaWarn.coronawarnContext _context;

        public CreateModel(CoronaWarn.coronawarnContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Benutzer Benutzer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Benutzers.Add(Benutzer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
