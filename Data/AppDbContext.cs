using BookAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<KidsVideos> KidsVideos { get; set;}
        public DbSet<KidsCategory> KidsCategories { get; set; }

        public DbSet<BookKid> BookKids { get; set; }

      
    }
}
