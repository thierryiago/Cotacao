using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IaraCotacoes.Models
{
    public class Cotacao
    {
        [Key]
        [Required]
        public int Id { get; set; }
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
        [JsonIgnore]
        public virtual List<CotacaoItem>? CotacaoItens { get; set; }
    }
}
