using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test3.Data;
using Test3.Models;

namespace Test3.Pages.Admin.SubCategoryAdmin
{
    public class CreateModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;

        public CreateModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public SubCategory SubCategory { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SubCategory.Add(SubCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
