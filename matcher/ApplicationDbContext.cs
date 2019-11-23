using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using matcher;

namespace matcher
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=./matcher.db;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Room>()
                .HasMany(c => c.users)
                .WithOne(e => e.room);
            builder.Entity<User>().HasOne(x => x.room).WithMany(y => y.users);

            builder.Entity<User>()
                .HasMany(c => c.preferences)
                .WithOne(e => e.user);

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }
    }
}
