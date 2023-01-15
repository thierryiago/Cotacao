using IaraCotacoes.Models;
using Refit;

namespace IaraCotacoes.Services.Interfaces
{
    public interface IConsultaEnderecosService
    {
        [Get("/ws/{cep}/json")]
        Task<ViaCepResponse> ConsultarEnderecoAsync(string cep);
    }
}
