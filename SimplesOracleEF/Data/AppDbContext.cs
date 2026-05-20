using Microsoft.EntityFrameworkCore;
using SimplesOracleEF.Models;
using System.Reflection.Emit;

namespace SimplesOracleEF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Vendedor)
                .WithMany(f => f.Produtos)
                .HasForeignKey(p => p.VendedorId);
        }
    }
}
