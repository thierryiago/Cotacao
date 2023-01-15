using FluentResults;
using IaraCotacoes.Models;

namespace IaraCotacoes.Repositories.Interfaces
{
    public interface ICotacaoRepository
    {
        void AddCotacao(Cotacao cotacao);
        Cotacao GetCotacao(int id);
        List<Cotacao> GetAllCotacao();
        bool DeleteCotacao(int id);
        bool UpdateCotacao(int id, Cotacao cotacao);
    }
}
