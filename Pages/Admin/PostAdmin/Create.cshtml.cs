using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test3.Data;
using Test3.Models;

namespace Test3.Pages.Admin.PostAdmin
{
    public class CreateModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;

        public CreateModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; } = default!;

        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
       
        
        
        public async Task<IActionResult> OnPostAsync()
        {

            var image = UploadedImage;
            string fileName = "";

            if (image != null) 
            {
                Random rnd = new();
                fileName =  rnd.Next(0, 100000).ToString() + image.FileName;

                using (var fileStream = new FileStream("./wwwroot/userImages/" + fileName, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

            }


            Post.Image = fileName;
            Post.Date = DateTime.Now;
            Post.UserId = User.Identity.Name;
            
            _context.Post.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("/AllPosts/AllPosts");
        }
    }
}
