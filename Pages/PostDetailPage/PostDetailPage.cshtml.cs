using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;
using Test3.Models;

namespace Test3.Pages.PostDetailPage
{
    public class PostDetailPageModel : PageModel
    {

        private readonly Test3.Data.ApplicationDbContext _context;
        public PostDetailPageModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Post Post { get; set; }
        public List<Models.SubCategory> SubCategories { get; set; }
        public List<Models.Comment> Comments { get; set; }

        [BindProperty]
        public List<Models.ReportedPost> ReportedPosts { get; set; }

        
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Comments = await _context.Comment.ToListAsync();
            SubCategories = await _context.SubCategory.ToListAsync();
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
            Comments = await _context.Comment.Where(c => c.PostId == id).ToListAsync();
            
            ReportedPosts = await _context.ReportedPost.ToListAsync();
            return Page();

        }


        public async Task<IActionResult> OnPostAsync(int reportId)
        {


         
            var reportedPost = new ReportedPost
            {
                PostId = reportId,
                ReportedDate = DateTime.Now
            };

            _context.ReportedPost.Add(reportedPost);
            await _context.SaveChangesAsync();


            return RedirectToPage("/PostDetailPage", new { id = reportId });
        }





    }
}
