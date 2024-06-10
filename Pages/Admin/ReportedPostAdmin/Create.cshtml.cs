using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test3.Data;
using Test3.Models;

namespace Test3.Pages.Admin.ReportedPostAdmin
{
    public class CreateModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;

        public CreateModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int PostId { get; set; }

        [BindProperty]
        public ReportedPost ReportedPost { get; set; } = default!;
        [BindProperty]
        public Models.Post Post { get; set; }

        public async Task OnGetAsync(int postId)
        {
            PostId = postId;
        }

       


        public async Task<IActionResult> OnPostAsync(int postId)
        {
            

            ReportedPost.PostId = postId;
            ReportedPost.ReportedDate = DateTime.Now;


            _context.ReportedPost.Add(ReportedPost);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
