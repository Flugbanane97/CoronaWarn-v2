using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoronaWarn;

namespace CoronaWarn.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private readonly CoronaWarn.coronawarnContext _context;

        public IndexModel(CoronaWarn.coronawarnContext context)
        {
            _context = context;
        }

        public IList<Location> Location { get;set; }

        public async Task OnGetAsync()
        {
            Location = await _context.Locations.ToListAsync();
        }
    }
}
