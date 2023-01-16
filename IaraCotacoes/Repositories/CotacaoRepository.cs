using IaraCotacoes.Data;
using IaraCotacoes.Models;
using IaraCotacoes.Repositories.Interfaces;

namespace IaraCotacoes.Repositories
{
    public class CotacaoRepository : ICotacaoRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CotacaoRepository> _logger;

        public CotacaoRepository(AppDbContext context, ILogger<CotacaoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddCotacao(Cotacao cotacao)
        {
            try
            {
                await _context.Cotacao.AddAsync(cotacao);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao registrar cotação no banco de dados");
            }
        }

        public async Task<List<Cotacao>> GetAllCotacao()
        {
            var cotacaoList = _context.Cotacao.ToList();
            if (cotacaoList.Any())
                return new();

            return cotacaoList;
        }

        public async Task<Cotacao> GetCotacao(int id)
        {
            var cotacao = await _context.Cotacao.FindAsync(id);
            if (cotacao == null)
                return new();

            return cotacao;

        }

        public async Task<bool> UpdateCotacao(int id, Cotacao cotacao)
        {
            try
            {
                if (await GetCotacao(id) == null)
                    return false;
                cotacao.Id = id;

                _context.Cotacao.Update(cotacao);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao registrar cotação no banco de dados");
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteCotacao(int id)
        {
            try
            {
                var cotacao = await GetCotacao(id);
                if (cotacao == null)
                    return false;

                _context.Cotacao.Remove(cotacao);
                _context.SaveChanges();
                
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao registrar cotação no banco de dados");
                return false;
            }

            return true;
        }
    }
}
