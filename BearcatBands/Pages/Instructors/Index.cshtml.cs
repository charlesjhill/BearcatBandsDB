using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BearcatBands.Models;

namespace BearcatBands.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly BearcatBands.Models.BearcatBandsContext _context;

        public IndexModel(BearcatBands.Models.BearcatBandsContext context)
        {
            _context = context;
        }

        public IList<Instructor> Instructor { get;set; }

        public async Task OnGetAsync()
        {
            Instructor = await _context.Instructors.ToListAsync();
        }
    }
}
