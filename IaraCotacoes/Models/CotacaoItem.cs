using System.ComponentModel.DataAnnotations;

namespace IaraCotacoes.Models
{
    public class CotacaoItem
    {
        [Key]
        public Guid Id { get; set; }
        public string? Descricao { get; set; }
        public int NumeroItem { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public string? Marca { get; set; }
        public int Unidade { get; set; }
    }
}
