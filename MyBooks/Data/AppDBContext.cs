using Microsoft.EntityFrameworkCore;
using MyBooks.Data.Model;

namespace MyBooks.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext( DbContextOptions<AppDBContext> options): base(options)
        {
            
        }

        public DbSet<Book>Books { get; set; }
    }
}
