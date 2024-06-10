using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test3.Data;
using Test3.Models;

namespace Test3.Pages.Admin.ReportedPostAdmin
{
    public class EditModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;

        public EditModel(Test3.Data.ApplicationDbContext context)
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

            var reportedpost =  await _context.ReportedPost.FirstOrDefaultAsync(m => m.Id == id);
            if (reportedpost == null)
            {
                return NotFound();
            }
            ReportedPost = reportedpost;
           ViewData["PostId"] = new SelectList(_context.Post, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ReportedPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportedPostExists(ReportedPost.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReportedPostExists(int id)
        {
            return _context.ReportedPost.Any(e => e.Id == id);
        }
    }
}
