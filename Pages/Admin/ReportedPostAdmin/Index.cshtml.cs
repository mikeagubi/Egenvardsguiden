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
    public class IndexModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;

        public IndexModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ReportedPost> ReportedPost { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ReportedPost = await _context.ReportedPost
                .Include(r => r.Post).ToListAsync();
        }
    }
}
