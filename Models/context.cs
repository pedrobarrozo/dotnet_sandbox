using Microsoft.EntityFrameworkCore;

namespace TestApi.Models
{
    public class ChoreContext : DbContext
    {
        public ChoreContext(DbContextOptions<ChoreContext> options)
            : base(options)
        {
        }

        public DbSet<ChoreItem> ChoreItems { get; set; }
    }
}