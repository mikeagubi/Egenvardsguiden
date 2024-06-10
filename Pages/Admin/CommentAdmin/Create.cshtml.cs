using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test3.Data;
using Test3.Models;

namespace Test3.Pages.Admin.CommentAdmin
{
    public class CreateModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;

        public CreateModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int PostId { get; set; }

        [BindProperty]
        public Comment Comment { get; set; } = default!;

        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        public async Task OnGetAsync(int postId)
        {
            PostId = postId;  
        }

        
        
        
        
        public async Task<IActionResult> OnPostAsync()
        {
            var image = UploadedImage;
            string fileName = "";

            if (image != null)
            {
                Random rnd = new();
                fileName = rnd.Next(0, 100000).ToString() + image.FileName;

                using (var fileStream = new FileStream("./wwwroot/userImages/" + fileName, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            Comment.Image = fileName;
            Comment.Date = DateTime.Now;
            Comment.UserId = User.Identity.Name;
            Comment.PostId = PostId;

            _context.Comment.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("/PostDetailPage/PostDetailPage", new { id = PostId });
        }
    }
}
