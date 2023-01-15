using FluentResults;
using IaraCotacoes.Data;
using IaraCotacoes.Data.Dtos.Cotacao;
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

        public void AddCotacao(Cotacao cotacao)
        {
            try
            {
                _context.Cotacao.Add(cotacao);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao registrar cotação no banco de dados");
            }
        }

        public List<Cotacao> GetAllCotacao()
        {
            var cotacaoList = _context.Cotacao.ToList();
            if (cotacaoList.Any())
                return new();

            return cotacaoList;
        }

        public Cotacao GetCotacao(int id)
        {
            var cotacao = _context.Cotacao.FirstOrDefault(v => v.Id == id);
            if (cotacao == null)
                return new();

            return cotacao;

        }

        public bool UpdateCotacao(int id, Cotacao cotacao)
        {
            try
            {
                if (GetCotacao(id) == null)
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

        public bool DeleteCotacao(int id)
        {
            try
            {
                var cotacao = GetCotacao(id);
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
