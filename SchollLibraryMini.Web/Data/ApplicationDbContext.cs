
using Microsoft.EntityFrameworkCore;
using SchollLibraryMini.Web.Models;

namespace SchollLibraryMini.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        
        public DbSet<BoardGame> BoardGames { get; set; }
    }
}
