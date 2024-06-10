using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test3.Models;

namespace Test3.Pages.AllPosts
{
    public class AllPostsModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;
        public AllPostsModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }


        public Models.Post Post { get; set; }


        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        public List<Models.Post> Posts { get; set; }

        public List<Models.SubCategory> SubCategories { get; set; }




        public async Task OnGetAsync()
        {
            Posts = await _context.Post.ToListAsync();

            SubCategories = await _context.SubCategory.ToListAsync();
        }

        
    }
}
