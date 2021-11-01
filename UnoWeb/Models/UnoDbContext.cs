using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnoWeb.Models
{
    public class UnoDbContext : DbContext
    {
        // Tables go here
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerGame> PlayerGames { get; set; }

        public UnoDbContext(DbContextOptions<UnoDbContext> options)
            : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // build tables here if fluent api used
            builder.Entity<Player>(e =>
            {
                e.ToTable("Players");
                e.HasKey(p => p.Id);
                e.Property(p => p.Name).HasMaxLength(60).IsRequired(true);
            });

            builder.Entity<PlayerGame>(e =>
            {
                e.ToTable("PlayerGames");
                e.HasKey(p => p.Id);
                e.HasOne(p => p.Player)
                    .WithMany(p => p.PlayerGames)
                    .HasForeignKey(p => p.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict);
                // Add foreign key to Game here
                    
            });
        }
    }
}
