using Microsoft.EntityFrameworkCore;
namespace mvcProjectvs.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}

