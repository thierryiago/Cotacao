using IaraCotacoes.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IaraCotacoes.Data.Dtos.CotacaoDto
{
    public class CreateCotacaoDto
    {
        public int Id { get; set; }
        [Required]
        public int CNPJComprador { get; set; }
        [Required]
        public int CNPJFornecedor { get; set; }
        [Required]
        public int NumeroCotacao { get; set; }
        [Required]
        public DateTime DataCotacao { get; set; }
        [Required]
        public DateTime DataEntregaCotacao { get; set; }
        [Required]
        public string Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Uf { get; set; }
        public string? Observacao { get; set; }
        [JsonIgnore]
        public List<CotacaoItem>? CotacaoItens { get; set; }
    }
}
