using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test3.Data;
using Test3.Models;

namespace Test3.Pages.Admin.PostAdmin
{
    public class EditModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;

        public EditModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Post Post { get; set; } = default!;

        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post =  await _context.Post.FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            Post = post;
           ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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


            Post.Image = fileName;

            _context.Attach(Post).State = EntityState.Modified;

            Post.Date = DateTime.Now;
            Post.UserId = User.Identity.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(Post.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.Id == id);
        }
    }
}
