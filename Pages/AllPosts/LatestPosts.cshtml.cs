using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Test3.Pages.AllPosts
{
    public class LatestPostsModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;
        public LatestPostsModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Models.Post> Posts { get; set; }
        public List<Models.SubCategory> SubCategories { get; set; }
        
        
        
        public async Task OnGetAsync()
        {
            Posts = await _context.Post.OrderByDescending(p => p.Date).Take(12).ToListAsync();

            SubCategories = await _context.SubCategory.ToListAsync();
        }


    }
}
