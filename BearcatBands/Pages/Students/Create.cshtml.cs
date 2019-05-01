using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BearcatBands.Models;

namespace BearcatBands.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly BearcatBands.Models.BearcatBandsContext _context;

        public CreateModel(BearcatBands.Models.BearcatBandsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyStudent = new Student();

            // TryUpdateModelAsync will use the attached pageContext property 
            // from the pageModel to bind the name and enrollment date properties 
            // to emptyStudent. If that's successful, it will add it to the db.
            if (await TryUpdateModelAsync(
                emptyStudent, 
                "student", 
                s => s.FirstMidName, 
                s => s.LastName, 
                s => s.EnrollmentDate))
            {
                _context.Students.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return null;
        }
    }
}