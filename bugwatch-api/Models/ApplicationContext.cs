using Microsoft.EntityFrameworkCore;

namespace bugwatch_api.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<AgileTask> AgileTasks => Set<AgileTask>();
        public DbSet<Workspace> Workspaces => Set<Workspace>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=/Stash/applicationContext.db");
        }
    }
}
