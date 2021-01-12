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
    public class IndexModel : PageModel
    {
        private readonly CoronaWarn.coronawarnContext _context;

        public IndexModel(CoronaWarn.coronawarnContext context)
        {
            _context = context;
        }

        public IList<Benutzer> Benutzer { get;set; }

        public async Task OnGetAsync()
        {
            Benutzer = await _context.Benutzers.ToListAsync();
        }
    }
}
