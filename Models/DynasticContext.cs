using Microsoft.EntityFrameworkCore;

namespace Dynastic.Models {
    public class DynasticContext : DbContext {
        public DynasticContext() { }
        public DynasticContext(DbContextOptions<DynasticContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Person>().HasOne(p => p.Father).WithMany(p => p.Children);
        }

        public DbSet<Person> People { get; set; }
    }
}