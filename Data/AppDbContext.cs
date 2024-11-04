using libreria_XGVC.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace libreria_XGVC.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Book> Books { get; set; }
    }
}
