using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorWessing.Models;
using TaylorWessing.Persistence.Entities;

namespace TaylorWessing.Persistence
{
    public class TaylorWessingDBContext : DbContext
    {
        public TaylorWessingDBContext(DbContextOptions<TaylorWessingDBContext> options) : base(options) { }

        public DbSet<APIAudit> Audit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<APIAudit>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<APIAudit>()
            .Property(c => c.DateCreated)
            .HasDefaultValueSql("GETDATE()");
        }

    }
}
