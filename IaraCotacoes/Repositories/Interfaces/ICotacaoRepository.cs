using FluentResults;
using IaraCotacoes.Models;

namespace IaraCotacoes.Repositories.Interfaces
{
    public interface ICotacaoRepository
    {
        Task AddCotacao(Cotacao cotacao);
        Task<Cotacao> GetCotacao(int id);
        Task<List<Cotacao>> GetAllCotacao();
        Task<bool> DeleteCotacao(int id);
        Task<bool> UpdateCotacao(int id, Cotacao cotacao);
    }
}
