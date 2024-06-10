using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test3.Models;

namespace Test3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Test3.Models.Category> Category { get; set; } = default!;
        public DbSet<Test3.Models.SubCategory> SubCategory { get; set; } = default!;
        public DbSet<Test3.Models.Post> Post { get; set; } = default!;
        public DbSet<Test3.Models.Comment> Comment { get; set; } = default!;
        public DbSet<Test3.Models.ReportedPost> ReportedPost { get; set; } = default!;
        public DbSet<Test3.Models.Message> Message { get; set; } = default!;
    }
}
