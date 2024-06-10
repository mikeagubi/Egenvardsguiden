using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test3.Data;
using Test3.Models;

namespace Test3.Pages.Admin.SubCategoryAdmin
{
    public class DetailsModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;

        public DetailsModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public SubCategory SubCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategory = await _context.SubCategory.FirstOrDefaultAsync(m => m.Id == id);
            if (subcategory == null)
            {
                return NotFound();
            }
            else
            {
                SubCategory = subcategory;
            }
            return Page();
        }
    }
}
