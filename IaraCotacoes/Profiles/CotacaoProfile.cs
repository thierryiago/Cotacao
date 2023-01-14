using AutoMapper;
using IaraCotacoes.Data.Dtos.Cotacao;
using IaraCotacoes.Models;

namespace IaraCotacoes.Profiles
{
    public class CotacaoProfile : Profile
    {
        public CotacaoProfile()
        {
            CreateMap<Cotacao, ReadCotacaoDto>();
            CreateMap<ReadCotacaoDto, Cotacao>();
        }
    }
}
