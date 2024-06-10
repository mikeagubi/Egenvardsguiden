using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test3.Pages
{
    public class AboutUsPageModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public void OnGet()
        {
        }
    }
}
