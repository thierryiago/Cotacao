using FluentResults;
using IaraCotacoes.Data.Dtos.CotacaoDto;

namespace IaraCotacoes.Services.Interfaces
{
    public interface ICotacaoService
    {
        Task<ReadCotacaoDto> AddCotacaoAsync(CreateCotacaoDto cotacaoDto);
        Task<ReadCotacaoDto> GetCotacao(int id);
        Task<List<ReadCotacaoDto>> GetAllCotacao();
        Task<Result> DeleteCotacao(int id);
        Task<Result> UpdateCotacao(int id, CreateCotacaoDto cotacaoDto);

    }
}
