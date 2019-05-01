using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BearcatBands.Models;
using BearcatBands.Models.BandViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BearcatBands.Pages
{
    public class AboutModel : PageModel
    {
        private readonly BearcatBandsContext _context;

        public AboutModel(BearcatBandsContext context)
        {
            _context = context;
        }

        public IList<EnrollmentDateGroup> Students { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDateGroup> data =
                _context.Students
                .GroupBy(s => s.EnrollmentDate)
                .Select(group => new EnrollmentDateGroup()
                {
                    EnrollmentDate = group.Key,
                    StudentCount = group.Count()
                });

            Students = await data.AsNoTracking().ToListAsync();
        }
    }
}