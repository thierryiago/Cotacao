using AutoMapper;
using FluentResults;
using IaraCotacoes.Data.Dtos.Cotacao;
using IaraCotacoes.Models;
using IaraCotacoes.Repositories.Interfaces;
using IaraCotacoes.Services.Interfaces;

namespace IaraCotacoes.Services
{
    public class CotacaoService : ICotacaoService
    {
        private readonly ILogger<CotacaoService> _logger;
        private readonly ICotacaoRepository _cotacaoRepository;
        private readonly IMapper _mapper;

        public CotacaoService(ILogger<CotacaoService> logger, ICotacaoRepository cotacaoRepository, IMapper mapper)
        {
            _logger = logger;
            _cotacaoRepository = cotacaoRepository;
            _mapper = mapper;
        }

        public ReadCotacaoDto AddCotacao(CreateCotacaoDto cotacaoDto)
        {
            try
            {
                var cotacaoMap = _mapper.Map<CreateCotacaoDto, Cotacao>(cotacaoDto);
                _cotacaoRepository.AddCotacao(cotacaoMap);

                return _mapper.Map<Cotacao, ReadCotacaoDto>(cotacaoMap);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao adicionar Cotacao");
            }

            return new();
        }

        public List<ReadCotacaoDto> GetAllCotacao()
        {
            return _mapper.Map<List<ReadCotacaoDto>>(_cotacaoRepository.GetAllCotacao());
        }

        public ReadCotacaoDto GetCotacao(int id)
        {
            return _mapper.Map<ReadCotacaoDto>(_cotacaoRepository.GetCotacao(id));
        }

        public Result UpdateCotacao(int id, CreateCotacaoDto cotacaoDto)
        {
            try
            {
                var cotacaoMap = _mapper.Map<CreateCotacaoDto, Cotacao>(cotacaoDto);
                var updateCotacao = _cotacaoRepository.UpdateCotacao(id, cotacaoMap);
                if (updateCotacao)
                    return Result.Ok();

                return Result.Fail("Falha ao atualizar Cotação");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao atualizar Cotação");
                return Result.Fail(e.Message);
            }
        }

        public Result DeleteCotacao(int id)
        {
            try
            {
                var deleteCotacao = _cotacaoRepository.DeleteCotacao(id);
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

    }
}
