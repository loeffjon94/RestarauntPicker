using Microsoft.EntityFrameworkCore;

namespace RandomRestaraunt.Data.Models
{
    public class RandomRestarauntContext : DbContext
    {
        public RandomRestarauntContext(DbContextOptions<RandomRestarauntContext> options) : base(options)
        {
        }

        public virtual DbSet<RandomRestaraunt.Data.Models.Restaraunt> Restaraunts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
