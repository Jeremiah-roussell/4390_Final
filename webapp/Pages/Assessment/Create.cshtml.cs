using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using webapp.Models;

namespace webapp.Pages.Assessment
{
    public class CreateModel : PageModel
    {
        private readonly PARDbContext _context;

        public CreateModel(PARDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Assessment Assessment { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Assessment.Add(Assessment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
