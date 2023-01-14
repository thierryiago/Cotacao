using FluentResults;
using IaraCotacoes.Data.Dtos.Cotacao;

namespace IaraCotacoes.Services.Interfaces
{
    public interface ICotacaoService
    {
        ReadCotacaoDto GetCotacao(Guid id);
        List<ReadCotacaoDto> GetAllCotacao();
        Result DeleteCotacao(Guid id);
        Result UpdateCotacao(Guid id);

    }
}
