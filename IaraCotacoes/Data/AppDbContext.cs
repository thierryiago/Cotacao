using IaraCotacoes.Models;
using Microsoft.EntityFrameworkCore;

namespace IaraCotacoes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cotacao>()
                .HasMany(x => x.CotacaoItens)
                .WithOne(c => c.Cotacao)
                .HasForeignKey(v => v.CotacaoId);
        }

        public DbSet<Cotacao> Cotacao { get; set; }
        public DbSet<CotacaoItem> CotacaoItem { get; set; }
    }
}
