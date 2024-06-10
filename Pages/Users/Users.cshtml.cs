using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Test3.Pages.Users
{
    public class UsersModel : PageModel
    {

        private readonly UserManager<IdentityUser> _userManager;
        public UsersModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public List<IdentityUser> Users { get; set; }

        [BindProperty]
        public IdentityUser User { get; set; }


        public async Task OnGetAsync(string id)
        {
            Users = await _userManager.Users.ToListAsync();
        }


        public async Task<IActionResult> OnPostAsync(string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            return RedirectToPage("./Users");
        }


    }
}
