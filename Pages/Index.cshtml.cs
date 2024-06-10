using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Test3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        [BindProperty]
        public Models.Post Post { get; set; }

        public async Task OnGetAsync()
        {

        }
    }
}
