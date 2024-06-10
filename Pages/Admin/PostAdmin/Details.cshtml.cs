using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test3.Data;
using Test3.Models;

namespace Test3.Pages.Admin.PostAdmin
{
    public class DetailsModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;

        public DetailsModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Post Post { get; set; } = default!;
        public SubCategory SubCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            else
            {
                Post = post;
            }
            return Page();
        }
    }
}
