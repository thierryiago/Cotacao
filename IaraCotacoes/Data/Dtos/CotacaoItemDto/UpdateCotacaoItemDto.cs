using System.ComponentModel.DataAnnotations;

namespace IaraCotacoes.Data.Dtos.CotacaoItemDto
{
    public class UpdateCotacaoItemDto
    {
        [Required]
        public int Id { get; set; }
    }
}
