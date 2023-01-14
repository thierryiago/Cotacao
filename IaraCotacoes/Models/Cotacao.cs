namespace IaraCotacoes.Models
{
    public class Cotacao
    {
        public Cotacao(int id, int cnpjComprador, int cnpjFornecedor, int numeroCotacao, 
            DateTime dataCotacao, DateTime dataEntregaCotacao, string cep)
        {
            Id = id;
            CNPJComprador = cnpjComprador;
            CNPJFornecedor = cnpjFornecedor;
            NumeroCotacao = numeroCotacao;
            DataCotacao = dataCotacao;
            DataEntregaCotacao = dataEntregaCotacao;
            Cep = cep;
        }

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
        public List<CotacaoItem>? CotacaoItens { get; set; }
    }
}
