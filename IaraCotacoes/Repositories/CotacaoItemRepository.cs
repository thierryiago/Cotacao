using IaraCotacoes.Data;
using IaraCotacoes.Models;
using IaraCotacoes.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IaraCotacoes.Repositories
{
    public class CotacaoItemRepository : ICotacaoItemRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CotacaoRepository> _logger;

        public CotacaoItemRepository(AppDbContext context, ILogger<CotacaoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddCotacaoItem(CotacaoItem cotacaoItem)
        {
            try
            {
                await _context.CotacaoItem.AddAsync(cotacaoItem);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao registrar item no banco de dados");
            }
        }

        public async Task<List<CotacaoItem>> GetAllCotacaoItem()
        {
            var cotacaoItemList = await Task.FromResult(_context.CotacaoItem.ToList());
            return cotacaoItemList;
        }

        public async Task<CotacaoItem> GetCotacaoItem(int id)
        {
            var cotacaoItem = await Task.FromResult(_context.CotacaoItem.FirstOrDefault(v => v.Id == id));
            if (cotacaoItem == null)
                return new();

            return cotacaoItem;
        }

        public async Task<bool> UpdateCotacaoItem(int id, CotacaoItem cotacaoItem)
        {
            try
            {
                if (await GetCotacaoItem(id) == null)
                    return false;
                cotacaoItem.Id = id;

                _context.CotacaoItem.Update(cotacaoItem);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao atualizar item no banco de dados");
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteCotacaoItem(int id)
        {
            try
            {
                var cotacaoItem = await GetCotacaoItem(id);
                if (cotacaoItem == null)
                    return false;

                _context.CotacaoItem.Remove(cotacaoItem);
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
