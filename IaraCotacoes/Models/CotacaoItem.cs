namespace IaraCotacoes.Models
{
    public class CotacaoItem
    {
        public CotacaoItem(int id, string descricao, int numeroItem, int quantidade)
        {
            Id = id;
            Descricao = descricao;
            NumeroItem = numeroItem;
            Quantidade = quantidade;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int NumeroItem { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public string? Marca { get; set; }
        public int Unidade { get; set; }
    }
}
