using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                 .HasOne(o => o.Director)
                 .WithMany(v => v.Movies)
                 .HasForeignKey(o => o.DirectorId);

            modelBuilder.Entity<Membership>()
                .HasOne(o => o.User)
                .WithOne(v => v.Memberships)
                .HasForeignKey<Membership>(o => o.UserId);
        }
    }
}