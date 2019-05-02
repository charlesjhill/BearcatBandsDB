using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BearcatBands.Models;

namespace BearcatBands.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly BearcatBandsContext _context;

        public IndexModel(BearcatBandsContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Student> Students { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            // These exist to flip NameSort/DateSort between the two values in the ternary.
            // E.g. if sortOrder is empty, set NameSort to "name_desc"
            //      If sortOrder isn't empty, set NameSort to empty.
            // These are used on the cshtml to flip the route parameter hyperlinks on the columns
            NameSort = string.IsNullOrEmpty(sortOrder) 
                ? "name_desc" 
                : "";
            DateSort = sortOrder == "Date" 
                ? "date_desc" 
                : "Date";

            CurrentSort = sortOrder;
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Student> studentIQ = _context.Students.Select(s => s);

            if (!string.IsNullOrEmpty(searchString))
            {
                studentIQ = studentIQ.Where(s => s.LastName.Contains(searchString)
                                              || s.FirstMidName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    studentIQ = studentIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    studentIQ = studentIQ.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 10;
            Students = await PaginatedList<Student>.CreateAsync(
                studentIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
