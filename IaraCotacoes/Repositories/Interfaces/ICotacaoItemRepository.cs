using IaraCotacoes.Models;

namespace IaraCotacoes.Repositories.Interfaces
{
    public interface ICotacaoItemRepository
    {
        Task AddCotacaoItem(CotacaoItem cotacaoItem);
        Task<CotacaoItem> GetCotacaoItem(int id);
        Task<List<CotacaoItem>> GetAllCotacaoItem();
        Task<bool> DeleteCotacaoItem(int id);
        Task<bool> UpdateCotacaoItem(int id, CotacaoItem cotacaoItem);
    }
}
