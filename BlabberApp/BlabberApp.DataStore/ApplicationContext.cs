using BlabberApp.Domain.Entities;
using BlabberApp.DataStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlabberApp.DataStore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            new BlabMap(modelBuilder.Entity<Blab>());
            new UserMap(modelBuilder.Entity<User>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Warning To protect potentially sensitive information in your connection string,
            // you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263
            // for guidance on storing connection strings.
            optionsBuilder.UseMySQL("server=142.93.114;database=agentdata;user=agentdata;password=letmein");
        }
    }
}