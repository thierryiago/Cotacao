using FluentResults;
using IaraCotacoes.Data.Dtos.CotacaoItemDto;

namespace IaraCotacoes.Services.Interfaces
{
    public interface ICotacaoItemService
    {
        Task<ReadCotacaoItemDto> AddCotacaoItemAsync(CreateCotacaoItemDto cotacaoDto);
        Task<List<ReadCotacaoItemDto>> GetAllCotacaoItem();
        Task<ReadCotacaoItemDto> GetCotacaoItem(int id);
        Task<Result> DeleteCotacaoItem(int id);
        Task<Result> UpdateCotacaoItem(int id, CreateCotacaoItemDto cotacaoItemDto);
    }
}
