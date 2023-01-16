using AutoMapper;
using IaraCotacoes.Data.Dtos.CotacaoItemDto;
using IaraCotacoes.Models;

namespace IaraCotacoes.Profiles
{
    public class CotacaoItemProfile : Profile
    {
        public CotacaoItemProfile()
        {
            CreateMap<CreateCotacaoItemDto, CotacaoItem>();
            CreateMap<CotacaoItem, ReadCotacaoItemDto>();
            CreateMap<ReadCotacaoItemDto, CotacaoItem>();

            CreateMap<Task<CreateCotacaoItemDto>, Task<CotacaoItem>>();
            CreateMap<Task<CotacaoItem>, Task<ReadCotacaoItemDto>>();
            CreateMap<Task<ReadCotacaoItemDto>, Task<CotacaoItem>>();

            CreateMap<Task<List<ReadCotacaoItemDto>>, Task<List<CotacaoItem>>>();
            CreateMap<Task<List<CotacaoItem>>, Task<List<ReadCotacaoItemDto>>>();

        }
    }
}
