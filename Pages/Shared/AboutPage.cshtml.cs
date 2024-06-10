using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test3.Pages.Shared
{
    public class AboutPageModel : PageModel
    {

        private readonly Data.ApplicationDbContext _context;




        public void OnGet()
        {
        }
    }
}
