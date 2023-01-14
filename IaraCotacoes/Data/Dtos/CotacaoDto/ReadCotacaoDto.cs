using IaraCotacoes.Models;

namespace IaraCotacoes.Data.Dtos.Cotacao
{
    public class ReadCotacaoDto
    {
        public int CNPJComprador { get; set; }
        public int CNPJFornecedor { get; set; }
        public int NumeroCotacao { get; set; }
        public DateTime DataCotacao { get; set; }
        public DateTime DataEntregaCotacao { get; set; }
        public string Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Uf { get; set; }
        public string? Observacao { get; set; }
        public List<CotacaoItem>? CotacaoItens { get; set; }
    }
}
