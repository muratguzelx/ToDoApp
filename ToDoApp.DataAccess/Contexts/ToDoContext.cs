using Microsoft.EntityFrameworkCore;
using ToDoApp.DataAccess.Configurations;
using ToDoApp.Entities.Domains;

namespace ToDoApp.DataAccess.Contexts
{
    public   class ToDoContext: DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Work> works { get; set; }
        
    }
}
