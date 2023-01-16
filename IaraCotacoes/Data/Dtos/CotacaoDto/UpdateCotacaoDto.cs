using System.ComponentModel.DataAnnotations;

namespace IaraCotacoes.Data.Dtos.CotacaoDto
{
    public class UpdateCotacaoDto
    {
        [Required]
        public int Id { get; set; }
    }
}
