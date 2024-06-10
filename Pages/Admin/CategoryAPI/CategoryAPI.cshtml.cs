using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test3.DAL;
using Test3.Models;

namespace Test3.Pages.Admin.CategoryAPI
{
    public class CategoryAPIModel : PageModel
    {
        public List<Models.Category> Categories { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await DAL.CategoryManagerAPI.GetAllCategories();
            return Page();
        }
    }
}
