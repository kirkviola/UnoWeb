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
        public virtual DbSet<Card> Cards { get; set; }

        public UnoDbContext(DbContextOptions<UnoDbContext> options)
            : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // build tables here if fluent api used
        }
    }
}
