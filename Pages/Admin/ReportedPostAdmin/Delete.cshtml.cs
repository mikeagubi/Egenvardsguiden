using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test3.Data;
using Test3.Models;

namespace Test3.Pages.Admin.ReportedPostAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;

        public DeleteModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ReportedPost ReportedPost { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportedpost = await _context.ReportedPost.FirstOrDefaultAsync(m => m.Id == id);

            if (reportedpost == null)
            {
                return NotFound();
            }
            else
            {
                ReportedPost = reportedpost;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportedpost = await _context.ReportedPost.FindAsync(id);
            if (reportedpost != null)
            {
                ReportedPost = reportedpost;
                _context.ReportedPost.Remove(ReportedPost);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
