using IaraCotacoes.Data;
using IaraCotacoes.Data.Dtos.Cotacao;
using IaraCotacoes.Models;
using IaraCotacoes.Repositories.Interfaces;

namespace IaraCotacoes.Repositories
{
    public class CotacaoRepository : ICotacaoRepository
    {
        private readonly AppDbContext _context;

        public CotacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void DeleteCotacao(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Cotacao> GetAllCotacao()
        {
            return _context.Cotacao.ToList();
        }

        public Cotacao GetCotacao(Guid id)
        {
            return _context.Cotacao.FirstOrDefault(v => v.Id == id);
        }

        public void UpdateCotacao(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
