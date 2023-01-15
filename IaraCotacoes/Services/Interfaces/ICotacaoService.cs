using FluentResults;
using IaraCotacoes.Data.Dtos.Cotacao;

namespace IaraCotacoes.Services.Interfaces
{
    public interface ICotacaoService
    {
        ReadCotacaoDto AddCotacao(CreateCotacaoDto cotacaoDto);
        ReadCotacaoDto GetCotacao(int id);
        List<ReadCotacaoDto> GetAllCotacao();
        Result DeleteCotacao(int id);
        Result UpdateCotacao(int id, CreateCotacaoDto cotacaoDto);

    }
}
