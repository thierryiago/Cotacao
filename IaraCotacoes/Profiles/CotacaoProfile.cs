using AutoMapper;
using IaraCotacoes.Data.Dtos.CotacaoDto;
using IaraCotacoes.Models;

namespace IaraCotacoes.Profiles
{
    public class CotacaoProfile : Profile
    {
        public CotacaoProfile()
        {
            CreateMap<CreateCotacaoDto, Cotacao>();
            CreateMap<Cotacao, ReadCotacaoDto>();
            CreateMap<ReadCotacaoDto, Cotacao>();

            CreateMap<Task<CreateCotacaoDto>, Task<Cotacao>>();
            CreateMap<Task<Cotacao>, Task<ReadCotacaoDto>>();
            CreateMap<Task<ReadCotacaoDto>, Task<Cotacao>>();
        }
    }
}
