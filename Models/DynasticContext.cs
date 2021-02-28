using System;
using Microsoft.EntityFrameworkCore;

namespace Dynastic.Models
{
    public class DynasticContext : DbContext
    {
        public DynasticContext() { }
        public DynasticContext(DbContextOptions<DynasticContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasMany(p => p.FathersChildren).WithOne(p => p.Father).HasForeignKey(p => p.FatherId);
            modelBuilder.Entity<Person>().HasMany(p => p.MothersChildren).WithOne(p => p.Mother).HasForeignKey(p => p.MotherId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine);

        public DbSet<Person> People { get; set; }
        public DbSet<Dynasty> Dynasties { get; set; }
    }
}