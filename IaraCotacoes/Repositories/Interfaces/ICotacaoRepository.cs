using IaraCotacoes.Models;

namespace IaraCotacoes.Repositories.Interfaces
{
    public interface ICotacaoRepository
    {
        Cotacao GetCotacao(Guid id);
        List<Cotacao> GetAllCotacao();
        void DeleteCotacao(Guid id);
        void UpdateCotacao(Guid id);
    }
}
