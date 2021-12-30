using System;
using Dynastic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dynastic.Architecture
{
    public class DynasticContext : DbContext
    {
        public DynasticContext() { }

        public DynasticContext(DbContextOptions<DynasticContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(p => p.FathersChildren)
                .WithOne(p => p.Father)
                .HasForeignKey(p => p.FatherId);
            modelBuilder.Entity<Person>()
                .HasMany(p => p.MothersChildren)
                .WithOne(p => p.Mother)
                .HasForeignKey(p => p.MotherId);
            modelBuilder.Entity<Relationship>()
                .HasKey(e => new
                {
                    e.PersonId,
                    e.PartnerId
                });
            modelBuilder.Entity<Relationship>()
                .HasOne(p => p.Partner)
                .WithMany()
                .HasForeignKey(e => e.PartnerId);
            modelBuilder.Entity<Relationship>()
                .HasOne(p => p.Person)
                .WithMany(p => p.Relationships)
                .HasForeignKey(e => e.PersonId);
            modelBuilder.Entity<UserDynasties>()
                .HasKey(ud => new
                {
                    Id = ud.Id,
                    DynastyId = ud.DynastyId
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Dynasty> Dynasties { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<UserDynasties> UserDynasties { get; set; }
    }
}