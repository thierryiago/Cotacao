using IaraCotacoes.Models;
using System.Text.Json.Serialization;

namespace IaraCotacoes.Data.Dtos.CotacaoItemDto
{
    public class ReadCotacaoItemDto
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public int NumeroItem { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public string? Marca { get; set; }
        public int Unidade { get; set; }
        public int CotacaoId { get; set; }
        public Cotacao? Cotacao { get; set; }
    }
}
