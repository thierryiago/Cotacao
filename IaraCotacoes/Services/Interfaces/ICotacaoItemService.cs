using FluentResults;
using IaraCotacoes.Data.Dtos.CotacaoItemDto;

namespace IaraCotacoes.Services.Interfaces
{
    public interface ICotacaoItemService
    {
        List<ReadCotacaoItemDto> GetAllCotacaoItem();
        ReadCotacaoItemDto GetCotacaoItem(Guid Id);
        Result DeleteCotacaoItem(Guid Id);
        Result UpdateCotacaoItem(Guid Id);
    }
}
