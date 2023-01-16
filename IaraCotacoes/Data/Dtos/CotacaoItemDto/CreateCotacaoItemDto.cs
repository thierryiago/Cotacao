using IaraCotacoes.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IaraCotacoes.Data.Dtos.CotacaoItemDto
{
    public class CreateCotacaoItemDto
    {
        public int Id { get; set; }
        [Required]
        public string? Descricao { get; set; }
        [Required]
        public int NumeroItem { get; set; }
        public double Preco { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public string? Marca { get; set; }
        public int Unidade { get; set; }
        public int CotacaoId { get; set; }
    }
}
