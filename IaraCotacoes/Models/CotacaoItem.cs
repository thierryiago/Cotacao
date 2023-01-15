using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IaraCotacoes.Models
{
    public class CotacaoItem
    {
        [Key]
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public int NumeroItem { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public string? Marca { get; set; }
        public int Unidade { get; set; }
        public int CotacaoId { get; set; }
        public virtual Cotacao Cotacao { get; set; }
    }
}
