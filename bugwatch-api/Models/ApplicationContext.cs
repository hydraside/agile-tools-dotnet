using Microsoft.EntityFrameworkCore;

namespace bugwatch_api.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<AgileTask> AgileTasks => Set<AgileTask>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=applicationContext.db");
        }
    }
}
