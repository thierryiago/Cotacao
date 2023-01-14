using AutoMapper;
using FluentResults;
using IaraCotacoes.Data.Dtos.Cotacao;
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

        public Result DeleteCotacao(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ReadCotacaoDto> GetAllCotacao()
        {
            return _mapper.Map<List<ReadCotacaoDto>>(_cotacaoRepository.GetAllCotacao());
        }

        public ReadCotacaoDto GetCotacao(Guid id)
        {
            return _mapper.Map<ReadCotacaoDto>(_cotacaoRepository.GetCotacao(id));
        }

        public Result UpdateCotacao(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
