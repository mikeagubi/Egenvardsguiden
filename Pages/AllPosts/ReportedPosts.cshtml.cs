using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test3.Pages.AllPosts
{
    public class ReportedPostsModel : PageModel
    {

        private readonly Test3.Data.ApplicationDbContext _context;
        public ReportedPostsModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }
       
        public List<Models.Post> ReportedPosts { get; set; }
        



    }
}
