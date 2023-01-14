using System.ComponentModel.DataAnnotations;

namespace IaraCotacoes.Data.Dtos.Cotacao
{
    public class UpdateCotacaoDto
    {
        [Required]
        public int Id { get; set; }
    }
}
