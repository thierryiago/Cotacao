using IaraCotacoes.Models;
using IaraCotacoes.Services.Interfaces;
using Refit;
using System.Text.Json;

namespace IaraCotacoes.Services
{
    public class ConsultaEnderecosService : IConsultaEnderecosService
    {
        public async Task<ViaCepResponse> ConsultarEnderecoAsync(string cep)
        {
            var request = RestService.For<IConsultaEnderecosService>("http://viacep.com.br");
            var endereco = await request.ConsultarEnderecoAsync(cep);

            return endereco;
        }
    }
}
