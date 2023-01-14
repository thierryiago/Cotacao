using IaraCotacoes.Models;
using Microsoft.EntityFrameworkCore;

namespace IaraCotacoes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cotacao> Cotacao { get; set; }
        public DbSet<CotacaoItem> CotacaoItem { get; set; }
    }
}
