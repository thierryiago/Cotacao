using IaraCotacoes.Models;

namespace IaraCotacoes.Repositories.Interfaces
{
    public interface ICotacaoItemRepository
    {
        List<CotacaoItem> GetCotacaoItem(Guid Id);
        List<CotacaoItem> GetAllCotacaoItem();
        void DeleteCotacao(Guid Id);
        void UpdateCotacao(Guid Id);
    }
}
