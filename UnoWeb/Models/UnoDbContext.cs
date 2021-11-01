using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnoWeb.Models
{
    public class UnoDbContext : DbContext
    {
        public virtual DbSet<Game> Games { get; set; }

        public UnoDbContext(DbContextOptions<UnoDbContext> options)
            : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>(e =>
            {
                e.Property(e => e.GameRoom).HasMaxLength(15).ValueGeneratedOnAdd().IsRequired();
                e.HasIndex(e => e.GameRoom).IsUnique();
            });
        }
    }
}
