using AutoMapper;
using FluentResults;
using IaraCotacoes.Data.Dtos.CotacaoItemDto;
using IaraCotacoes.Models;
using IaraCotacoes.Repositories.Interfaces;
using IaraCotacoes.Services.Interfaces;

namespace IaraCotacoes.Services
{
    public class CotacaoItemService : ICotacaoItemService
    {
        private readonly IMapper _mapper;
        private readonly ICotacaoItemRepository _cotacaoItemRepository;
        private readonly ILogger<CotacaoItemService> _logger;

        public CotacaoItemService(IMapper mapper, ILogger<CotacaoItemService> logger, ICotacaoItemRepository cotacaoItemRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _cotacaoItemRepository = cotacaoItemRepository;
        }

        public async Task<ReadCotacaoItemDto> AddCotacaoItemAsync(CreateCotacaoItemDto cotacaoItemDto)
        {
            try
            {
                var cotacaoMap = _mapper.Map<CreateCotacaoItemDto, CotacaoItem>(cotacaoItemDto);
                await _cotacaoItemRepository.AddCotacaoItem(cotacaoMap);

                return _mapper.Map<CotacaoItem, ReadCotacaoItemDto>(cotacaoMap);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao adicionar Cotacao Item");
            }

            return new();
        }

        public async Task<Result> DeleteCotacaoItem(int id)
        {
            try
            {
                var deleteCotacao = await _cotacaoItemRepository.DeleteCotacaoItem(id);
                if (deleteCotacao)
                    return Result.Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao deletar Cotação");
                return Result.Fail(e.Message);
            }

            return Result.Fail("Falha ao deletar Cotação");
        }

        public async Task<List<ReadCotacaoItemDto>> GetAllCotacaoItem()
        {
            return await _mapper.Map<Task<List<ReadCotacaoItemDto>>>(_cotacaoItemRepository.GetAllCotacaoItem());
        }

        public async Task<ReadCotacaoItemDto> GetCotacaoItem(int id)
        {
            return await _mapper.Map<Task<ReadCotacaoItemDto>>(_cotacaoItemRepository.GetCotacaoItem(id));
        }

        public async Task<Result> UpdateCotacaoItem(int id, CreateCotacaoItemDto cotacaoItemDto)
        {
            try
            {
                var cotacaoMap = _mapper.Map<CreateCotacaoItemDto, CotacaoItem>(cotacaoItemDto);
                await _cotacaoItemRepository.UpdateCotacaoItem(id, cotacaoMap);

                return Result.Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao atualizar cotacao item");
                return Result.Fail(e.Message);
            }
        }
    }
}
