using AutoMapper;
using FluentResults;
using IaraCotacoes.Data.Dtos.Cotacao;
using IaraCotacoes.Models;
using IaraCotacoes.Repositories.Interfaces;
using IaraCotacoes.Services.Interfaces;
using Refit;

namespace IaraCotacoes.Services
{
    public class CotacaoService : ICotacaoService
    {
        private readonly ILogger<CotacaoService> _logger;
        private readonly ICotacaoRepository _cotacaoRepository;
        private readonly IConsultaEnderecosService _consultaEnderecosService;
        private readonly IMapper _mapper;

        public CotacaoService(ILogger<CotacaoService> logger, ICotacaoRepository cotacaoRepository, IMapper mapper, IConsultaEnderecosService consultaEnderecosService)
        {
            _logger = logger;
            _cotacaoRepository = cotacaoRepository;
            _mapper = mapper;
            _consultaEnderecosService = consultaEnderecosService;
        }

        public async Task<ReadCotacaoDto> AddCotacaoAsync(CreateCotacaoDto cotacaoDto)
        {
            try
            {
                cotacaoDto = await ChecarEndereco(cotacaoDto);

                var cotacaoMap = _mapper.Map<CreateCotacaoDto, Cotacao>(cotacaoDto);
                await _cotacaoRepository.AddCotacao(cotacaoMap);

                return _mapper.Map<Cotacao, ReadCotacaoDto>(cotacaoMap);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao adicionar Cotacao");
            }

            return new();
        }

        public async Task<List<ReadCotacaoDto>> GetAllCotacao()
        {
            return await _mapper.Map<Task<List<ReadCotacaoDto>>>(_cotacaoRepository.GetAllCotacao());
        }

        public async Task<ReadCotacaoDto> GetCotacao(int id)
        {
            return await _mapper.Map<Task<ReadCotacaoDto>>(_cotacaoRepository.GetCotacao(id));
        }

        public async Task<Result> UpdateCotacao(int id, CreateCotacaoDto cotacaoDto)
        {
            try
            {
                cotacaoDto = await ChecarEndereco(cotacaoDto);

                var cotacaoMap = _mapper.Map<CreateCotacaoDto, Cotacao>(cotacaoDto);
                var updateCotacao = _cotacaoRepository.UpdateCotacao(id, cotacaoMap);
                if (updateCotacao.Result)
                    return Result.Ok();

                return Result.Fail("Falha ao atualizar Cotação");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao atualizar Cotação");
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result> DeleteCotacao(int id)
        {
            try
            {
                var deleteCotacao = _cotacaoRepository.DeleteCotacao(id);
                if (deleteCotacao.Result)
                    return Result.Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao deletar Cotação");
                return Result.Fail(e.Message);
            }

            return Result.Fail("Falha ao deletar Cotação");
        }

        private async Task<CreateCotacaoDto> ChecarEndereco(CreateCotacaoDto cotacaoDto)
        {
            if (string.IsNullOrEmpty(cotacaoDto.Logradouro) &&
                    string.IsNullOrEmpty(cotacaoDto.Bairro) &&
                    string.IsNullOrEmpty(cotacaoDto.Uf))
            {

                var endereco = await _consultaEnderecosService.ConsultarEnderecoAsync(cotacaoDto.Cep);
                cotacaoDto.Logradouro = endereco.Logradouro;
                cotacaoDto.Bairro = endereco.Bairro;
                cotacaoDto.Uf = endereco.Uf;

                return cotacaoDto;
            }
            else
                return new();

        }

    }
}
